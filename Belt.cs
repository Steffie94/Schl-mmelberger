using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Belt : MonoBehaviour
{
    public GameObject belt;
    public Transform endpoint;
    //Schnelligkeit des Laufbandes.
    public float speed = 1f;

    //Dafür da dass wenn ein Objekt auf das Laufband ist etwas passiert sonst nichts.
    void OnTriggerStay(Collider other)
    {
            other.transform.position = Vector3.MoveTowards(other.transform.position,endpoint.position, speed * Time.deltaTime);
     
    }
}