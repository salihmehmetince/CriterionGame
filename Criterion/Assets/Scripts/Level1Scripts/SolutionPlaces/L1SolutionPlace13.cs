using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class L1SolutionPlace13 : MonoBehaviour
{
    private const string FINALGASTRUCK = "GasTruck";

    private const string FINALCAR = "Car";

    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        
        if(gObject.tag==FINALCAR)
        {
            Transform parent = gObject.transform.parent;
            if(parent!=null)
            {
                if(parent.tag==FINALGASTRUCK)
                {
                    if(gObject.GetComponent<L1GasTruck>().HasGas)
                    {
                        gObject.transform.SetParent(transform);
                        gObject.transform.localPosition = Vector3.zero;
                        gObject.transform.localRotation = Quaternion.identity;
                        gObject.GetComponent<L1GasTruck>().liveCar();
                        gObject.GetComponent<L1GasTruck>().enabled = false;
                        Transform problemBox = character.GetChild(3);
                        problemBox.gameObject.SetActive(false);
                        character.GetComponent<L1Character>().IsMissionOver = true;
                        enabled = false;
                    }
                }
            }

        }
    }
}
