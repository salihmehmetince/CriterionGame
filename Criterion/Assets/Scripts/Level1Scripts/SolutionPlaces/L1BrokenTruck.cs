using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1BrokenTruck : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALCHARACTER = "Character";

    private CharacterController characterController;

    private bool canMove = true;

    private float moveSpeed = 10f;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        transform.GetComponent<Rigidbody>().freezeRotation = true;
        transform.GetComponent<Rigidbody>().isKinematic = true;

    }
    private void OnTriggerStay(Collider other)
    {
        Transform gObject = other.transform;
        if (gObject.tag == FINALPLAYER || gObject.tag == FINALCHARACTER)
        {
            CharacterController playerCharacterController=gObject.GetComponent<CharacterController>();
            if(playerCharacterController.velocity!=Vector3.zero)
            {
                if(canMove)
                {
                    characterController.Move(-Vector3.forward *moveSpeed* Time.deltaTime);
                }
            }
        }
    }

    public bool CanMove
    {
        set
        {
            canMove = value;
        }
    }

}
