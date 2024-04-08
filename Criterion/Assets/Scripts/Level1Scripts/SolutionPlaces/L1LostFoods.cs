using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1LostFoods : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALFOODS = "Foods";

    private bool hasFoods = false;

    private Transform foods;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
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
                transform.SetParent(foods.transform);
            }
            else
            {
                GameObject pieces = new GameObject();
                pieces.name = "Foods";
                pieces.tag = "Foods";
                pieces.transform.SetParent(gObject.transform);
            }
        }
    }
}
