using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1StrandedPlace : MonoBehaviour
{
    [SerializeField]
    private Transform strandedCharacter;

    private float minimumWalkDistance = 20f;

    private float walkSpeed = 10f;

    private const string FINALISWALKING = "IsWalking";

    private bool didTake = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private const string FINALCAR = "Car";

    private float maxsimumSpeed = 50f;
    private void OnTriggerStay(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALCAR)
        {
            float speed = gObject.GetComponent<L1Car>().Speed;
            if (speed < maxsimumSpeed)
            {
                walkToCar(gObject.transform);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALCAR)
        {
            stop();
        }

    }

    private void getInCar(Transform car)
    {
        strandedCharacter.SetParent(car);
        strandedCharacter.localPosition = new Vector3(0f, 0f, 0f);
    }

    private void walkToCar(Transform car)
    {
        float distance = Vector3.Distance(strandedCharacter.position, car.position);

        if (distance > minimumWalkDistance)
        {
            runToPlayer(car);
        }
        else
        {
            stop();
            getInCar(car);
            didTake = true;
        }

        transform.LookAt(car);

    }

    private void runToPlayer(Transform car)
    {
        visualRun();
        Vector3 targetPosition = new Vector3(car.position.x, 0f, car.position.z);
        strandedCharacter.position = Vector3.MoveTowards(strandedCharacter.position, targetPosition, walkSpeed * Time.deltaTime);
    }

    private void stop()
    {
        visualStop();
    }

    private void visualRun()
    {
        strandedCharacter.GetComponent<Animator>().SetBool(FINALISWALKING, true);
    }

    private void visualStop()
    {
        strandedCharacter.GetComponent<Animator>().SetBool(FINALISWALKING, false);
    }

    public bool DidTake
    {
        get { return didTake;}
    }
}
