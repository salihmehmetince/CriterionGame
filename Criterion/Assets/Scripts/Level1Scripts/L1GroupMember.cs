using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1GroupMember : MonoBehaviour
{
    private Animator animator;

    private const string FINALISRUNNING = "IsRunning";

    private CharacterController characterController;

    private float followSpeed = 70f;

    [SerializeField]
    private Transform player;

    private bool isChase = false;

    private float minimumFollowDistance = 10f;

    private Vector3 firstposition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        firstposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChase)
        {
            chasePlayer();
        }
        else
        {
            returnFirstPosition();
        }
    }

    private void chasePlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > minimumFollowDistance)
        {
            Vector3 playerPosition = player.position;
            runTo(playerPosition);
        }
        else
        {
            stop();
        }
        transform.LookAt(player);
    }

    private void runTo(Vector3 target)
    {
        visualRun();
        Vector3 targetPosition=new Vector3(target.x,0f,target.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

    }

    private void stop()
    {
        visualStop();
    }

    private void visualRun()
    {
        animator.SetBool(FINALISRUNNING, true);
    }

    private void visualStop()
    {
        animator.SetBool(FINALISRUNNING, false);
    }

    public bool IsChase
    {
        get { return isChase; }
        set { isChase = value; }
    }

    private void returnFirstPosition()
    {
        float distance = Vector3.Distance(transform.position, firstposition);

        if (distance > 0f)
        {
            runTo(firstposition);
        }
        else
        {
            stop();
        }
        transform.LookAt(firstposition);
    }
}
