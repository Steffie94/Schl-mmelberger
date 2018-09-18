using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    // Damit wir das Leben vom Spieler benutzen können
    Leben live;
    SpielerSteuerung spiel;

    public int hurt = 1;

    void Start ()
    {
            live = GameObject.FindGameObjectWithTag("Player").GetComponent<Leben>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //Zieht der alten position die neue ab und fügt diese dem neuem Vector hinzu.
            Vector3 altposition = (transform.position - other.transform.position).normalized;
            //Aufruf der Funktion BounceOnComment vom Script SpielerSteuerung, damit der Spieler weggeschleudert wird.
            FindObjectOfType<SpielerSteuerung>().BounceOnComment();
        }
    }
}
