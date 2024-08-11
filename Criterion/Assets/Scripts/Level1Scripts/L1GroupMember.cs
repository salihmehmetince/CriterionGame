using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class L1GroupMember : MonoBehaviour
{
    private Animator animator;

    private const string FINALISRUNNING = "IsRunning";

    private float followSpeed = 70f;

    [SerializeField]
    private Transform player;

    private bool isChase = false;

    private float minimumFollowDistance = 10f;

    private Vector3 firstposition;

    
    private NavMeshAgent agent;

    private GameObject speechBox;

    private Quaternion initialRotation;

    private string []messages = { "Hey","Can you stop?","Stop please","Who are you?"};
    private float timer = 0f;
    private float timerMax = 5f;

    private const string FINALISJUMPING = "IsJumping";
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(FINALISRUNNING, false);
        firstposition = transform.position;
        agent=GetComponent<NavMeshAgent>();
        speechBox = transform.GetChild(2).gameObject;
        speechBox.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        speechBox.GetComponent<RectTransform>().localPosition = new Vector3(-5f,-8f,-6f);
        
    }

    // Update is called once per frame
    void Update()
    {
        chase();
        if(isChase)
        {
            if (timer < timerMax)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0f;
                talkWithPlayer();
            }
        }

        focusSpeechBox();

        
    }

    private void chase()
    {
        if (isChase)
        {
            chasePlayer();
        }
        else
        {
            if (transform.position != firstposition)
            {
                returnFirstPosition();
            }
        }
        transform.rotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);

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
        agent.velocity = agent.desiredVelocity;
    }

    private void runTo(Vector3 target)
    {
        visualRun();
        Vector3 targetPosition=new Vector3(target.x,0f,target.z);
        agent.destination=targetPosition;
        if (agent.isOnOffMeshLink)
        {
            animator.SetBool(FINALISRUNNING, false);
            animator.SetTrigger(FINALISJUMPING);
        }
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

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
        if (distance > 4f)
        {
            runTo(firstposition);
        }
        else
        {
            stop();
        }
        transform.LookAt(firstposition);
    }

    private void talkWithPlayer()
    {
        Invoke(nameof(talk), 3f);
    }

    private void talk()
    {
        speechBox.GetComponent<TextMeshPro>().text =messages[Random.Range(0, messages.Length)];
        Invoke(nameof(stopTalk), 3f);
    }

    private void stopTalk()
    {
        speechBox.GetComponent<TextMeshPro>().text = "";

    }

    private void focusSpeechBox()
    {
        speechBox.transform.LookAt(player);
    }
}
