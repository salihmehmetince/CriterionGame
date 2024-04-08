using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Waters : MonoBehaviour
{
    private const string FINALHELÝCOPTER = "Helicopter";
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject=other.transform;
        if(gObject.tag==FINALHELÝCOPTER)
        {
            transform.SetParent(gObject);
            enabled = false;
        }
    }
}
