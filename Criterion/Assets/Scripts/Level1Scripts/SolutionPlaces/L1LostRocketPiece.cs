using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1LostRocketPiece : MonoBehaviour
{
    private Rigidbody rgBody;

    private const string FINALPLAYER = "Player";

    // Start is called before the first frame update
    void Start()
    {
        rgBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Random.Range(-30, 30f);
        float z = Random.Range(-30f, 30f);
        Vector3 force = new Vector3(x,10f,z);
        rgBody.AddForce(force,ForceMode.Impulse);
        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x,-500f,500f),10f, Mathf.Clamp(transform.localPosition.z, -500f, 500f));
    }

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
