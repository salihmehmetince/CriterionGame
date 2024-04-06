using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Toolbox : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private bool canTake = true;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        
        if(gObject.tag==FINALPLAYER)
        {
            if(canTake)
            {
                transform.SetParent(gObject.transform);
                canTake = false;
                enabled = false;
            }
        }
    }
}
