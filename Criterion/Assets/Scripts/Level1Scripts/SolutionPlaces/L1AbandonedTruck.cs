using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1AbandonedTruck : MonoBehaviour
{
    private Transform abandonedSign;

    private const string FINALPLAYER="Player";

    private const string FINALJERRYCAN="JerryCan";
    // Start is called before the first frame update
    void Start()
    {
        abandonedSign = transform.GetChild(4);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if(gObject.tag==FINALPLAYER)
        {
            abandonedSign.gameObject.SetActive(true);
        }
        else if(gObject.tag==FINALJERRYCAN)
        {
            gObject.transform.SetParent(transform);
            gObject.transform.localPosition = new Vector3(0f,1.5f,-0.7f);
            gObject.transform.localRotation = Quaternion.Euler(0f,90,0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
        {
            abandonedSign.gameObject.SetActive(false);
        }
    }
}
