using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class L1SelfFlyingHelicopter : MonoBehaviour
{
    private Vector3 destination;

    private float speed = 200f;

    private float wingTurnSpeed = 2f;


    private Transform wings;

    private Transform frontWing;

    private Transform backWing;

    private CharacterController characterController;

    private const string FINALSKYPART = "SkyPart";

    [SerializeField]
    private Transform[] skyParts;

    private int skyPartIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        wings = transform.GetChild(1);
        frontWing = wings.GetChild(0);
        backWing = wings.GetChild(1);
        characterController = GetComponent<CharacterController>();
        destination = chooseDestination();
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        goDestination(destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALSKYPART)
        {
            float randomState = Random.Range(0f, 1f);
            if(randomState < 0.25f)
            {
                destination = chooseDestination();

            }
            else
            {
                gameObject.SetActive(false);
                Invoke(nameof(activate),30f);
            }
        }
    }

    private void goDestination(Vector3 destination)
    {
        frontWing.Rotate(new Vector3(0f, 360f * wingTurnSpeed, 0f) * Time.deltaTime, Space.Self);
        backWing.Rotate(new Vector3(0f, 0f, 360f * wingTurnSpeed) * Time.deltaTime, Space.Self);
        Vector3 direction = (destination - transform.position).normalized;
        transform.LookAt(skyParts[skyPartIndex]);
        transform.Rotate(0f, -90f, 0f, Space.Self);
        characterController.Move(direction * speed * Time.deltaTime);
    }

    private Vector3 chooseDestination()
    {
        int randomIndex = Random.Range(0, skyParts.Length);
        while (skyPartIndex == randomIndex)
        {
            randomIndex = Random.Range(0, skyParts.Length);
        }
        Vector3 destination = skyParts[randomIndex].position;
        skyPartIndex = randomIndex;
        return destination;
    }

    private void activate()
    {
        gameObject.SetActive(true);
        destination = chooseDestination();
    }
}
