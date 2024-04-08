using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Waters : MonoBehaviour
{
    private const string FINALHEL�COPTER = "Helicopter";
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject=other.transform;
        if(gObject.tag==FINALHEL�COPTER)
        {
            transform.SetParent(gObject);
            enabled = false;
        }
    }
}
