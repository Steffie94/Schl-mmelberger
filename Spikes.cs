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
            //Nimmt den Vector Null
            Vector3 altposition = Vector3.zero;
            //Benutzt die Funktion SchadenSpieler mit neuen Parametern
            // Erste Parameter reduziert das Leben bei Verletzung
            //Zweite Parameter wird der Vector hinzugefügt 
            //und da er Null ist wird er nicht weggeschleudert.
        }
    }
}