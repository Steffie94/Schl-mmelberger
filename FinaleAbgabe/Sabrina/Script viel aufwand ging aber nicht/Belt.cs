using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public Rigidbody rb;
    //Schnelligkeit des Laufbandes.
    public float speed = 2f;

    //Dafür da dass wenn ein Objekt auf das Laufband ist etwas passiert sonst nichts.
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody>();
        rb.position -= transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + transform.forward *speed*Time.deltaTime);
    }
}