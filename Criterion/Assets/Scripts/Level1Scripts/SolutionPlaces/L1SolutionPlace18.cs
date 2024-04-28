using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace18 : MonoBehaviour
{
    private const string FINALSENDHELICOPTER = "SendHelicopter";

    [SerializeField]
    private GameObject character;

    [SerializeField]
    private GameObject character2;

    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.gameObject.transform;
        Transform parenGObject = gObject.parent;
        if (parenGObject != null)
        {
            if (parenGObject.tag == FINALSENDHELICOPTER)
            {
                Debug.Log("G�rev tamamland�");
                gObject.SetParent(transform);
                gObject.localPosition = new Vector3(0f, 0f, 0f);
                gObject.localRotation = Quaternion.identity;
                Transform player = GameObject.Find("Player").transform;
                Debug.Log(player.name);
                gObject.GetComponent<L1Helicopter>().liveHelicopter();
                gObject.GetComponent<L1Helicopter>().enabled = false;
                Transform problemBox = character.transform.GetChild(3);
                Transform problemBox2 = character2.transform.GetChild(3);
                problemBox.gameObject.SetActive(false);
                problemBox2.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                character2.GetComponent<L1Character>().IsMissionOver = true;
                enabled = false;
            }
            else
            {
            }
        }
    }
}
