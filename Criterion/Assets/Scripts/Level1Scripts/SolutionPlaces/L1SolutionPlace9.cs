using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace9 : MonoBehaviour
{
    private const string FINALFACTORYMECHANIC = "FactoryMechanic";

    private const string FINALISWALKING = "IsWalking";

    [SerializeField]
    private Transform specialCar;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.gameObject.transform;
        Transform parenGObject = gObject.parent;
        if (parenGObject != null)
        {
            if (parenGObject.tag == FINALFACTORYMECHANIC)
            {
                Debug.Log("Görev tamamlandý");
                gObject.SetParent(transform);
                gObject.localPosition = new Vector3(2f, 1f, -2f);
                gObject.localRotation = Quaternion.identity;
                Transform player = gObject.GetChild(gObject.childCount - 1);
                Debug.Log(player.name);
                Transform character = gObject.GetComponent<L1MechanicCharacter>().getMainCharacter();
                gObject.GetComponent<L1MechanicCharacter>().getAnimator().SetBool(FINALISWALKING,false);
                gObject.GetComponent<L1MechanicCharacter>().enabled = false;
                Transform problemBox = character.GetChild(3);
                problemBox.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                specialCar.GetComponent<L1SpecialCar>().CanDriveSpecialCar = true;
                enabled = false;
            }
            else
            {
            }
        }
    }
}
