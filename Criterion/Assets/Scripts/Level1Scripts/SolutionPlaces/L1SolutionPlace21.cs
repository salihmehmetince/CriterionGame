using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace21 : MonoBehaviour
{
    private const string FINALFRUITTRUCK = "FruitTruck";

    [SerializeField]
    private GameObject character;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.gameObject.transform;
        Transform parenGObject = gObject.parent;
        if (parenGObject != null)
        {
            if (parenGObject.tag == FINALFRUITTRUCK)
            {
                Debug.Log("G�rev tamamland�");
                gObject.SetParent(transform);
                gObject.localPosition = new Vector3(0.8f, 1f, -2f);
                gObject.localRotation = Quaternion.identity;
                Transform player = GameObject.Find("Player").transform;
                Debug.Log(player.name);
                gObject.GetComponent<L1Car>().liveCar();
                gObject.GetComponent<L1Car>().enabled = false;
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