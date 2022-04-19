using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    public Transform[] moveSpots;
    public int randomSpot;
    public float speed;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        randomSpot = Random.Range(1, moveSpots.Length);
    }


    void FixedUpdate()
    {
        //Vector3 moveDirecrion = new Vector3(transform.position.x - moveSpots[randomSpot].position.x, rb.velocity.y, transform.position.z - moveSpots[randomSpot].position.z);
        //Vector3 lookDirection = moveDirecrion + transform.position;

        //transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        //transform.LookAt(new Vector3(moveSpots[randomSpot].position.x, 2000, moveSpots[randomSpot].position.z));

        //if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 4f)
        //{
        //    if (randomSpot == 0)
        //    {
        //        randomSpot = Random.Range(1, moveSpots.Length);
        //    }
        //    else
        //    {
        //        randomSpot = 0;
        //    }
        //}
    }
}
