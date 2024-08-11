using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SkyPart : MonoBehaviour
{
    private bool directionRight = true;
    private float speed = 5f;
    private float boundary = 2000f;

    void Start()
    {

    }



    void Update()
    {
        Move();
    }

    private void Move()
    {
        float targetX = directionRight ? boundary : -boundary;

        // Hedefe do�ru hareket ettir
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(targetX, transform.localPosition.y, transform.localPosition.z), speed * Time.deltaTime);

        // E�er hedefe ula��ld�ysa, hareket y�n�n� tersine �evir
        if (Mathf.Abs(transform.localPosition.x - targetX) < 0.01f)
        {
            directionRight = !directionRight;
        }
    }

}
