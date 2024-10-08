using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class L1MovingBus : MonoBehaviour
{

    
    private bool canEnter = true;

    [SerializeField]
    private Transform corner;

    private NavMeshAgent agent;

    private const string FINALCORNER = "Corner";

    private int index = 0;

    [SerializeField]
    private List<Transform> corners = new List<Transform>();

    private const string FINALTRAFFICLAMB = "TrafficLamb";

    private bool isMove=true;

    private const string FINALBUSSTOP = "BusStop";

    private bool shouldStop=false;

    private const string FINALPLAYER = "Player";
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public void live()
    {
        Transform player = null;
        player = GameObject.Find("Player").transform;
        player.position = new Vector3(player.position.x + 20f, player.position.y, player.position.z);
        player.GetComponent<L1Player>().enabled = true;
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.parent = null;
    }

    public void enter()
    {
        enabled = true;
        Transform player = null;
        player = GameObject.Find("Player").transform;
        player.SetParent(transform);
        Transform playerPosition = transform.GetChild(2);
        player.localPosition = playerPosition.localPosition;
        player.localRotation = Quaternion.identity;
        player.GetComponent<L1Player>().enabled = false;
        player.GetComponent<CapsuleCollider>().enabled = false;
        shouldStop = false;
        canEnter=false;
        GetComponent<BoxCollider>().enabled = false;
        Invoke(nameof(activateCollider), 3f);
        go();
    }

    public bool CanEnter
    {
        get { return canEnter; }
        set { canEnter = value; }
    }

    private void move()
    {
        if(isMove)
        {
            agent.SetDestination(corner.position);
            agent.velocity = agent.desiredVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALCORNER)
        {
            index++;
            index = index % corners.Count;
            gObject.transform.localPosition = corners[index].localPosition;
            agent.velocity = Vector3.zero;
        }
        else if(gObject.tag==FINALTRAFFICLAMB)
        {
            isMove = false;
            agent.enabled = false;
            Invoke(nameof(go), 2f);
        }
        else if (gObject.tag == FINALBUSSTOP)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag == FINALPLAYER)
                {
                    shouldStop = true;
                    break;
                }
            }

            if (shouldStop)
            {
                isMove = false;
                agent.enabled = false;
                Invoke(nameof(go), 5f);
            }
            else
            {
                Invoke(nameof(go), 2f);
            }
        }
    }

    private void go()
    {
        agent.enabled = true;
        isMove = true;
    }

    public bool ShouldStop
    {
        get
        {
            return shouldStop;
        }

        set
        {
            shouldStop = value;
        }
    }

    private void activateCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

}
