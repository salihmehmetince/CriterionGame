using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace15 : MonoBehaviour
{
    private const string FINALBROKENTRUCK = "BrokenTruck";

    private const string FINALCAR = "Car";

    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.transform;

        if (gObject.tag == FINALCAR)
        {
            Transform parent = gObject.transform.parent;
            if (parent != null)
            {
                if (parent.tag == FINALBROKENTRUCK)
                {
                    gObject.SetParent(transform);
                    gObject.localPosition = Vector3.zero;
                    gObject.localRotation = Quaternion.Euler(0f, 180f, 0f);
                    gObject.GetComponent<L1BrokenTruck>().CanMove = false;
                    Transform problemBox = character.GetChild(3);
                    problemBox.gameObject.SetActive(false);
                    character.GetComponent<L1Character>().IsMissionOver = true;
                    character.GetComponent<L1CharacterPlayerFollow>().IsFollow = false;
                    enabled = false;
                }
            }

        }
    }
}
