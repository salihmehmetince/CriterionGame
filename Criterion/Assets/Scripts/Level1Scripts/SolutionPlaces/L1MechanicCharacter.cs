using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1MechanicCharacter : L1InteractableSideCharacters
{
    [SerializeField]
    private Transform player;

    private const string FINALISWALKING = "IsWalking";

    private float followSpeed = 30f;
    private void Update()
    {
        if(base.IsRightChoice)
        {
            followPlayer();
        }
    }

    private void followPlayer()
    {
        CharacterController playerCharacterController=player.GetComponent<CharacterController>();
        if(playerCharacterController.velocity!=Vector3.zero)
        {
            visualStop();
        }
        else
        {
            float distance = Vector3.Distance(transform.position,player.position);
            Debug.Log(distance);
            if(distance>20f)
            {
                visualWalk();
                transform.position = Vector3.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            }
            else
            {
                visualStop();
            }

        }

        transform.LookAt(player);
    }

    private void visualWalk()
    {
        base.getAnimator().SetBool(FINALISWALKING, true);
    }

    private void visualStop()
    {
        base.getAnimator().SetBool(FINALISWALKING, false);
    }
}
