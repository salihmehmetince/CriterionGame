using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace2 : MonoBehaviour
{
    private const string FINALWOODSTRUCK = "WoodsTruck";

    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.gameObject.transform;
        Transform parenGObject = gObject.parent;
        if (parenGObject != null)
        {
            if (parenGObject.tag == FINALWOODSTRUCK)
            {
                Debug.Log("Görev tamamlandý");
                gObject.SetParent(transform);
                gObject.localPosition = new Vector3(0.8f, 1f, -2f);
                gObject.localRotation = Quaternion.identity;
                Transform player = gObject.GetChild(gObject.childCount - 1);
                Debug.Log(player.name);
                gObject.GetComponent<L1Car>().liveCar();
                gObject.GetComponent<L1Car>().enabled = false;
                GameObject character = player.GetComponent<L1Player>().getmissions()[0].MissionCharacter;
                Transform problemBox = character.transform.GetChild(3);
                problemBox.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                enabled = false;
            }
            else
            {
            }
        }
    }
}
