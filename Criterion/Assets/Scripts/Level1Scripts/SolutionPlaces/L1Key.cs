using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class L1Key : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.transform;

        if (gObject.tag == FINALPLAYER)
        {
            transform.SetParent(gObject);
            enabled = false;
        }
    }

}
