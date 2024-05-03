using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace16 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] problemPlaces=new GameObject[2];
    private const string FINALCAR = "Car";

    [SerializeField]
    private Transform strandedCharacter;

    [SerializeField]
    private Transform strandedSideCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.transform;
        if(gObject.tag==FINALCAR)
        {
            bool didTake = checkDidTakes();
            if(didTake)
            {
                Transform problemBox = strandedCharacter.transform.GetChild(3);
                problemBox.gameObject.SetActive(false);
                strandedCharacter.GetComponent<L1StrandedCharacter>().IsMissionOver = true;
                strandedCharacter.SetParent(transform);
                strandedSideCharacter.SetParent(transform);
                strandedCharacter.localPosition = new Vector3(0f,0f,0f);
                strandedSideCharacter.localPosition = new Vector3(0f, 0f, 5f);
                enabled = false;
            }
        }
    }

    private bool checkDidTakes()
    {
        for(int i=0;i<problemPlaces.Length;i++)
        {
            bool didTake = problemPlaces[i].GetComponent<L1StrandedPlace>().DidTake;
            if (!didTake)
            {
                return false;
            }

        }

        return true;
    }
}
