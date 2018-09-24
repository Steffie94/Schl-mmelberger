using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpikes : MonoBehaviour {

    //Schnelligkeit der Spikes festlegen.
    public float speed = 5f;
    //Wie hoch die Spikes gehen sollen.
    public float height = 0.1f;
    // Nach welchem Zeitabstand die Spikes die Bewegung durch führen.
    private IEnumerator delayTime;

    // Damit wir das Leben vom Spieler benutzen können
    Leben live;
    //Wie viel Leben er verliert, wenn er verletzt wird.
    public int hurt = 1;

    void Start()
    {
        //Zugriff auf Players Leben Script und erhalte Leben.
        live = GameObject.FindGameObjectWithTag("Player").GetComponent<Leben>();
    }

    // Die Spikes werden hier animiert sich hoch und runter in einem Loop zu bewegen.
    void Update () {

        //Die aktuelle Position der Spikes wird hier in einer Variabe gespeichert,
        //sodass wir diese später wieder verwenden können.
        Vector3 pos = transform.position;
        
        //Berechnet was die neue Position sein wird.
        float newY = Mathf.Sin(Time.time * speed);
        
        //Setzt die Spikes auf die neu berechnete Position von Y.
        transform.position = new Vector3(pos.x, newY * height, pos.z);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {            
            //Nimmt den Vector Null
            Vector3 altposition = Vector3.zero;
            //Benutzt die Funktion SchadenSpieler mit neuen Parametern
            // Erste Parameter reduziert das Leben bei Verletzung
            //Zweite Parameter wird der Vector hinzugefügt 
            //und da er Null ist wird er nicht weggeschleudert.
            FindObjectOfType<Leben>().schadenSpieler(1, altposition);
        }
    }
}
