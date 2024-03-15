using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Character : MonoBehaviour
{
    private const string FINALPLAYER = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == FINALPLAYER)
        {
            Debug.Log("ok");
        }
    }
}
