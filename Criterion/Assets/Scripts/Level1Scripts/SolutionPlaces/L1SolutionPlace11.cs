using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace11 : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALFOODS = "Foods";

    private bool hasFoods = false;

    private Transform foods;

    [SerializeField]
    private Transform character;

    private int foodAmount = 3;
    private void OnTriggerEnter(Collider other)
    {
        Transform gObject=other.transform;

        if(gObject.tag==FINALPLAYER)
        {
            for (int i = 0; i < gObject.transform.childCount; i++)
            {
                if (gObject.transform.GetChild(i).tag == FINALFOODS)
                {
                    foods = gObject.transform.GetChild(i);
                    hasFoods = true;
                    break;
                }
            }

            if (hasFoods)
            {
                if (foods.childCount >= foodAmount)
                {

                    foods.SetParent(transform);
                    Transform problemBox = character.transform.GetChild(3);
                    problemBox.gameObject.SetActive(false);
                    character.GetComponent<L1Character>().IsMissionOver = true;
                    enabled = false;
                    Debug.Log("success");
                }
                else
                {
                    Debug.Log("olmadý");
                }
            }
        }
    }
}
