using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class L1SolutionPlace12 : MonoBehaviour
{
    private const string FINALKEY = "Key";

    private const string FINALPLAYER = "Player";

    private bool hasKey=false;

    [SerializeField]
    private Transform character;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.transform;

        if(gObject.tag==FINALPLAYER)
        {
            for (int i = 0; i < gObject.transform.childCount; i++)
            {
                if (gObject.transform.GetChild(i).tag == FINALKEY)
                {
                    Destroy(gObject.transform.GetChild(i).gameObject);
                    hasKey = true;
                    break;
                }
            }

            if(hasKey)
            {
                Transform problemBox = character.GetChild(3);
                problemBox.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                enabled = false;
            }
        }
    }
    
}
