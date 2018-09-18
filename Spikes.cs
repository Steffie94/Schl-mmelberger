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
            //Benutzt die Funktion SchadenSpieler mit neuen Parametern
            // Erste Parameter reduziert das Leben bei Verletzung
            //Zweite Parameter wird der Vector hinzugefügt und die Position y * die höhe genommen in der sie hoch geschleudert werden soll.
            //FindObjectOfType<SpielerSteuerung>().BounceOnComment();
        }
    }
}