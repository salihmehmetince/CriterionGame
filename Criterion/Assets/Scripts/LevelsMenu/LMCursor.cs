using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMCursor : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 30f * Time.deltaTime, 0f, Space.Self);
    }
}
