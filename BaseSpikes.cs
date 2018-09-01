using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpikes : MonoBehaviour {
    //Sorgt dafür das der Player wenn er auf der Base ist nicht verletzt wird nur wenn er die Spikes trifft.
    //Indem er zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        //Player wird ein Kind von der Base.
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    //Wenn der PLayer die Base wieder verlässt ist er kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
