using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1BusStop : MonoBehaviour
{

    private bool shouldStop=false;

    private const string FINALPLAYER = "Player";

    [SerializeField]
    private Transform bus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject=other.gameObject;
        if(gObject.tag==FINALPLAYER)
        {
            bus.GetComponent<L1MovingBus>().ShouldStop = true;
            bus.GetComponent<L1MovingBus>().CanEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
        {
            bus.GetComponent<L1MovingBus>().ShouldStop = false;
            bus.GetComponent<L1MovingBus>().CanEnter = false;
        }
    }

    
}
