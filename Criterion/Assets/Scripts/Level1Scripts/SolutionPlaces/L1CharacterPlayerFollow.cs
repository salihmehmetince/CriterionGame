using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1CharacterPlayerFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float followSpeed = 60f;
    private const string FINALISWALKING = "IsWalking";

    private bool isFollow = false;
    private Animator animator;

    private float minDistance = 30f;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    private void Update()
    {
        if (isFollow)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            Debug.Log(distance);
            if(distance>minDistance)
            {
                followPlayer();
            }

        }
        else
        {
            visualStop();
        }
    }

    private void followPlayer()
    {
        CharacterController playerCharacterController = player.GetComponent<CharacterController>();
        if (playerCharacterController.velocity != Vector3.zero)
        {
            visualStop();
        }
        else
        {
            float distance = Vector3.Distance(transform.position, player.position);
            Debug.Log(distance);
            if (distance > minDistance)
            {
                visualWalk();
                transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            }
            else
            {
                visualStop();
            }

        }

        transform.LookAt(player);
    }

    private void visualWalk()
    {
        animator.SetBool(FINALISWALKING, true);
    }

    private void visualStop()
    {
        animator.SetBool(FINALISWALKING, false);
    }

    public bool IsFollow
    {
        set
        {
            isFollow = value;
        }
    }
}
