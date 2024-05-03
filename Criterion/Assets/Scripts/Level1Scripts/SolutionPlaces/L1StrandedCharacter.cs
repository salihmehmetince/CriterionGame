using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1StrandedCharacter : L1Character
{
    [SerializeField]
    private GameObject[] problemPlaces=new GameObject[2];

    protected override void startMission()
    {
        exclamationbox.gameObject.SetActive(true);
        solutionPlace.SetActive(true);
        for(int i=0;i<problemPlaces.Length;i++)
        {
            problemPlaces[i].gameObject.SetActive(true);
        }
    }

}
