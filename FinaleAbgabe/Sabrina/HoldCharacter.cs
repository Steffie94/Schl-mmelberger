using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    { 
            other.transform.parent = gameObject.transform;
            //Object Parent setzen.
    }
    private void OnTriggerExit(Collider other)
    {
            other.transform.parent = null;
            //Object soll kein Parent mehr sein
    }
}
