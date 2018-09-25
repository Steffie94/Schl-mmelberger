using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karussel : MonoBehaviour {

    //Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player Parent setzen.
            other.transform.parent = gameObject.transform;

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
