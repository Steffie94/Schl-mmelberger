using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    //Ist dafür da das wir wissen ob unser Player auf der Platte ist oder nicht.
    //Der Player ist zu Beginn nicht auf der Platte deshalb false.
    bool isFalling = false;
    public int fall = 1;

    //Mit welcher Geschwindigkeit die Platte fällt.
    float downspeed = 0;
    
	
	// Wird aufgerufen wenn der Player auf die Platte ist. 

    //Wird einmal per Frame aufgerufen, sodass die Platte runter fällt. 
    void Update()
    {
        //Wenn isFalling true fällt die Platte erst.
        if (isFalling) 
        {
            downspeed += Time.deltaTime / 20; 
            // Diese Rechnung zeigt einem wie schnell die Platte fallen soll.
            transform.position = new Vector3(transform.position.x,
                transform.position.y - downspeed, transform.position.z);
            //Die Platte soll nach unten fallen deshalb ziehen wir y die Geschwindigkeit ab.
                
            //Damit die PLatte nicht unendlich fällt.
            // Destroy(gameObject, fall);
        }
    }

    //Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isFalling = true;
            //Damit die PLatte nicht unendlich fällt.

            //Player Parent setzen.
            other.transform.parent = transform;
            
        }
    }

    //Wenn der PLayer die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
