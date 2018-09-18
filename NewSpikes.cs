using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpikes : MonoBehaviour {

    //Schnelligkeit der Spikes festlegen.
    public float speed = 5f;
    //Wie hoch die Spikes gehen sollen.
    public float height = 0.5f;
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
            //Zieht der alten position die neue ab und fügt diese dem neuem Vector hinzu.
            Vector3 altposition = (transform.position - other.transform.position).normalized;
            
            //Aufruf der Funktion BounceOnComment vom Script SpielerSteuerung, damit der Spieler weggeschleudert wird.
            FindObjectOfType<SpielerSteuerung>().BounceOnComment( );
        }
    }
}
