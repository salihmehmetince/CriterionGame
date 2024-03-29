using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Toolbox : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        
        if(gObject.tag==FINALPLAYER)
        {
            transform.SetParent(gObject.transform);
            enabled = false;
        }
    }
}
