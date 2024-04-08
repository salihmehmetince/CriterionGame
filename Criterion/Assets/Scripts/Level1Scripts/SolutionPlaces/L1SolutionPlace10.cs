using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace10 : MonoBehaviour
{
    private const string FINALWATERSFLOOR = "WatersFloor";

    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.gameObject.transform;

        if (gObject.tag == FINALWATERSFLOOR)
        {
            Transform waters = gObject.parent;
            Debug.Log("Görev tamamlandý");
            waters.SetParent(transform);
            waters.localPosition = new Vector3(2f, 56f, -2f);
            waters.localRotation = Quaternion.identity;
            Transform player = GameObject.Find("Player").transform;
            Debug.Log(player.name);
            Transform problemBox = character.GetChild(3);
            problemBox.gameObject.SetActive(false);
            character.GetComponent<L1Character>().IsMissionOver = true;
            enabled = false;
        }
    }
}
