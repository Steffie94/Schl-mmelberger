using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentingPlayer : MonoBehaviour {

    //Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = other.transform;
            Debug.Log("nach trigger Platform enter");

        }
    }

    //Wenn der PLayer die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = null;
        }
    }
}
