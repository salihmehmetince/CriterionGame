using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMCursorMovement : MonoBehaviour
{


    private const string FinalPlane = "Plane";

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag==FinalPlane)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }

}
