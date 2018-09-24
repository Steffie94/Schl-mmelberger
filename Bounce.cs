using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    public int high;
    // Wie hoch sollen wir springen

    bool jumping = false;

    public void Update()
    {
        if (jumping)
        {
            FindObjectOfType<SpielerSteuerung>().BounceOnCommand(high);
        }
    }

    void OnCollisionEnter (Collision col) {
        //Wenn der Spieler drauf soll er ein Child von der Platform werden.
        if (col.gameObject.tag == "Player")
        {
  
            col.transform.parent = gameObject.transform;
            jumping = true;
        }
	}

    //Wenn der Spieler die Bouncing Platform verlässt ist er kein Kind mehr von der Platte. 
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
            jumping = false;
        }
    }
}
