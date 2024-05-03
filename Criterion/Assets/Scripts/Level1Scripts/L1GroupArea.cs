using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1GroupArea : MonoBehaviour
{
    [SerializeField]
    private List<Transform> groupMembers = new List<Transform>();

    [SerializeField]
    private Transform player;

    private float chaseDistance = 400f;

    private const string FINALPLAYER = "Player";


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Transform gObject = other.gameObject.transform;

        if(gObject.tag==FINALPLAYER)
        {
            forwardMembers();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Transform gObject = other.gameObject.transform;

        if (gObject.tag == FINALPLAYER)
        {
            returnmembers();
        }
    }

    private void forwardMembers()
    {
        for (int i = 0; i < groupMembers.Count; i++)
        {
            float distance = Vector3.Distance(groupMembers[i].position, player.position);
            if (distance <= chaseDistance)
            {
                groupMembers[i].GetComponent<L1GroupMember>().IsChase = true;
            }
            else
            {
                groupMembers[i].GetComponent<L1GroupMember>().IsChase = false;
            }

        }
    }

    private void returnmembers()
    {
        for (int i = 0; i < groupMembers.Count; i++)
        {
            groupMembers[i].GetComponent<L1GroupMember>().IsChase = false;
        }
    }

}
