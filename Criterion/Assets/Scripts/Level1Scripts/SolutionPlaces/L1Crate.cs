using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class L1Crate : MonoBehaviour
{
    private bool isFull = false;

    [SerializeField]
    private GameInput gameInput;

    private int fruitAmount=0;
    private int maxFruitAmount=9;

    private bool canCollect = false;

    private const string FINALPLAYER = "Player";

    private const string FINALFRUITTRUCK = "FruitTruck";

    private const string FINALFRUIT = "Fruit";

    private int fruitOnTruck = 0;

    private int fruitColumn = 7;

    private Vector3 firstFruitPositionOnTruck=new Vector3(-1,1.55f,1);

    private int maxFruitOnTruck = 2;

    [SerializeField]
    private GameObject fruitTruck;
    // Start is called before the first frame update
    void Start()
    {
        gameInput.onWork += onWorked;
    }

    private void onWorked(object sender, EventArgs e)
    {
        
        if(transform.parent!=null)
        {
            if(transform.parent.tag==FINALPLAYER)
            {
                canCollect = true;
            }
        }
        if(canCollect)
        {
            if (fruitAmount < maxFruitAmount)
            {
                fruitAmount++;
                if (fruitAmount >= maxFruitAmount)
                {
                    isFull = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsFull
    {
        get
        {
            return isFull;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform gObject = other.transform;
        if (gObject.parent != null)
        {
            if (gObject.parent.tag == FINALFRUITTRUCK)
            {
                emptyCrate(gObject);
            }
        }
    }

    private void emptyCrate(Transform fruitTruck)
    {
        fruitAmount = 0;
        isFull = false;
        List<Transform> fruits = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).tag == FINALFRUIT)
            {
                Transform fruit=transform.GetChild(i);
                fruit.SetParent(fruitTruck);
                fruitOnTruck++;
                placeFruitOnTruck(fruit);
            }
        }
        Debug.Log("empty");
    }

    private void placeFruitOnTruck(Transform fruit)
    {
        int fruitRow = fruitOnTruck / fruitColumn;
        int fruitCol = fruitOnTruck % fruitColumn;

        float fruitPositionX = firstFruitPositionOnTruck.x + (fruitCol * 0.3f);
        float fruitPositionZ = firstFruitPositionOnTruck.z - (fruitRow * 0.3f);
        fruit.transform.localPosition = new Vector3(fruitPositionX, firstFruitPositionOnTruck.y, fruitPositionZ);

        if(fruitOnTruck>=maxFruitOnTruck)
        {
            fruitTruck.GetComponent<L1FruitTruck>().IsFull = true;
        }
    }

}
