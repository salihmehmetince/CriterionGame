using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1CollectableTree : L1WorkObject
{
    [SerializeField]
    private GameObject fruit;

    private bool canCollect = false;

    private const string FINALITEM = "Item";

    [SerializeField]
    private Transform crate;

    private int fruitAmount = 0;

    private int maxFruitAmount = 9;

    private int column = 3;

    private Vector3[] fruitPositions = { new Vector3(4, 1, 3), new Vector3(4, 1, 0), new Vector3(4, 1, -3), new Vector3(0, 1, 3), new Vector3(0, 1, 0), new Vector3(0, 1, -3), new Vector3(-4, 1, 3), new Vector3(-4, 1, 0), new Vector3(-4, 1, -3) };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void work()
    {
        haveCrate();
        if(canCollect)
        {
            if(!crate.GetComponent<L1Crate>().IsFull)
            {
                Debug.Log(crate.GetComponent<L1Crate>().IsFull);
                if (fruitAmount < maxFruitAmount)
                {
                    GameObject Ifruit = Instantiate(fruit);
                    fruitAmount++;
                    Ifruit.transform.SetParent(crate);
                    Ifruit.transform.localPosition = Vector3.zero;
                    Ifruit.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    placeFruit(Ifruit.transform);
                    Debug.Log("work");
                }
            }
        }
    }

    private void haveCrate()
    {
        Transform player = GameObject.Find("Player").transform;
        for (int i = 0; i < player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).tag == FINALITEM)
            {
                crate= player.transform.GetChild(i);
                canCollect = true;
                break;
            }
        }
    }

    private void placeFruit(Transform fruit)
    {
        fruit.localPosition = fruitPositions[fruitAmount - 1];
        fruit.localScale = new Vector3(15f,15f,15f);

    }

}
