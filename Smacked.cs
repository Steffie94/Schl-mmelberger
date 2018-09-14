using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smacked : MonoBehaviour {

	void OnTriggerEnter (Collider col) {

        //Wenn das Object mit Tag Player es berührt
        if (col.gameObject.tag == "Player")
        {
            //Damage Script funktioniert nicht mehr
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);


            FindObjectOfType<SpielerSteuerung>().setzeSprungkraft(200);
            //Objekt wird zerstörrt in 2 sec
            Destroy(transform.parent.gameObject,2.0f);
        }

	}
}
