using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Transform belt;
    public Transform endPunkt;
    public float speed;

    void Start()
    {
        
    }

    // Alles was auf der Platte ist bewegt sich nach vorne, dies wird solange ausgeführt bis es von der Platte ist.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            belt.Translate(other.transform.forward * Time.deltaTime);
        }
        
    }
}