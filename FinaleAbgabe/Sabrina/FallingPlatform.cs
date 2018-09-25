using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    //Sagt Bescheid ob die Platte gefallen ist.
    //Zu Beginn soll sie nicht fallen erst wenn der Player drauf springt.
    bool isFalling = false;

    //Sagt mit welcher Geschwindigkeit die Platte fallen soll.
    float downspeed = 0;

    // Bestimmt wie Langsam sie fällt, da dieser Wert durch gerechnet wird.
    public float speed = 20;

    // Wird aufgerufen wenn der Player auf der Platte ist. 
    //Wird einmal per Frame aufgerufen, sodass die Platte runter fällt. 
    void Update()
    {
        //Wenn isFalling true ist fällt die Platte erst.
        if (isFalling) 
        {
            downspeed += Time.deltaTime / speed;

            // Dies zeigt einem an wie schnell die Platte fallen soll.

            //Die Platte soll nach unten fallen deshalb ziehen wir y die Geschwindigkeit ab
            //und die Platte bekommt eine neue Position mit einem neuen Y wert.

            transform.position = new Vector3(transform.position.x,
                transform.position.y - downspeed, transform.position.z);
            
        }
    }

    //Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    //Desweiteren  sorgt sie dafür das sieFaellt true wird und die Platte so nach unten fallen kann.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isFalling = true;
            //Jetz kann die Platte runter fallen.

            //Player Parent setzen.
            other.transform.parent = gameObject.transform;
            
        }
    }

    //Wenn der Spieler die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
