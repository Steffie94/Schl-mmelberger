using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRespawn : MonoBehaviour {

    //Anfangs Position festhalten zum Respawn.
    public Vector3 startPosition;

    //Nach dieser Zeit taucht die Platte wieder auf.
    public float time = 2f;

    //Sagt Bescheid ob die Platte gefallen ist.
    //Zu Beginn soll sie nicht fallen erst wenn der Player drauf springt.
    bool isFalling = false;

    //Sagt mit welcher Geschwindigkeit die Platte fallen soll.
    float downspeed = 0;

    // Bestimmt wie Langsam sie fällt, da dieser Wert durch gerechnet wird.
    public float speed = 20;

    //Start Position merken.
    void Start()
    {
        startPosition = transform.position;
    }

    //Diese Methode überprüft ob die Platte gefallen ist 
    //und dann greift sie auf eine andere Methode, damit diese die Platte zurücksetzen kann. 
    void Respawn()
    {
        if (isFalling == true)
        {
            StartCoroutine(RespawnCo());
        }
    }

    //Diese Methode ist damit die Platte auftaucht in Ursprungsposition.
    //Desweiteren setzt sie die Anfangswerte wieder auf null damit sie wieder fallen kann.
    private IEnumerator RespawnCo()
    {
        //Is die Platte schon gefallen.
        if (isFalling == true)
        {
            //Warte die Zeit ab.
            yield return new WaitForSeconds(time);
            //Setze Werte zurück und die Platte.
            isFalling = false;
            this.transform.position = startPosition;
            downspeed = 0;
        }
    }

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
            //Nach dem die Platte gefallen ist soll sie wiederhergestellt werden deshalb Respawn.
            Respawn();
        }
    }
}
