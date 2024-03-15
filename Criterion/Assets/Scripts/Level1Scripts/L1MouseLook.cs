using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1MouseLook : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 100f;

    [SerializeField]
    private Transform playerBody;

    private float rotationX = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX=Mathf.Clamp(rotationX,-90f,90f);

        transform.localRotation=Quaternion.Euler(rotationX,0f,0f);

        playerBody.Rotate(Vector3.up*mouseX);
    }
}
