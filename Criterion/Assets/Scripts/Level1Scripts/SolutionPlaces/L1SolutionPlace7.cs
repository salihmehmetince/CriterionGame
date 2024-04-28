using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace7 : MonoBehaviour
{
    private const string FINALHARDWORKÝNGCAR = "HardworkingCar";

    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if(gObject.transform.parent!=null)
        {
            if(gObject.transform.parent.tag==FINALHARDWORKÝNGCAR)
            {
                Transform player = gObject.transform.GetChild(4);
                gObject.GetComponent<L1Car>().liveCar();
                gObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                gObject.transform.localPosition = new Vector3(-702f,0f,-650);
                Transform problemBox = character.transform.GetChild(3);
                problemBox.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                enabled = false;
            }
        }
    }
}
