using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public GameObject belt;
    public Transform endPunkt;
    public float speed;
    public CharacterController controller;

    void Start()
    {
        FindObjectOfType<CharacterController>();
        controller = GetComponent<CharacterController>();
    }

    // Alles was auf der Platte ist bewegt sich nach vorne, dies wird solange ausgeführt bis es von der Platte ist.
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.Translate(other.transform.forward*Time.deltaTime);
        }

            // other.transform.position = Vector3.MoveTowards(other.transform.position,endPunkt.position, speed * Time.deltaTime);
            //controller.Move(endPunkt.position*Time.deltaTime);
        }
    /*
    void OnTriggerEnter(Collider col)
    {
        //Wenn der Spieler drauf soll er ein Child von der Platform werden.
        if (col.tag == "Player")
        {
            col.transform.parent = transform;

        }
    }

    //Wenn der Spieler die Bouncing Platform verlässt ist er kein Kind mehr von der Platte. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }*/
}