using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schaden : MonoBehaviour {

    public int schadensWert = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Schaut ob der Spieler den Trigger berührt
        if(other.gameObject.tag == "Player")
        {
            //Ermittelt die Rückstoßrichtung
            Vector3 schadensRichtung = other.transform.position - transform.position;

            //Limitiert die Werte maximal 1 in jeder Richtung
            schadensRichtung = schadensRichtung.normalized;

            //Verletzt den Spieler
            FindObjectOfType<Leben>().schadenSpieler(schadensWert, schadensRichtung);

        }
    }
}
