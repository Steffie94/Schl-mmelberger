using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public GameObject deatheffect;
    SpielerSteuerung player;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);

            Instantiate(deatheffect, transform.position, transform.rotation);
            FindObjectOfType<SpielerSteuerung>().BounceOnCommand();
            Destroy(transform.parent.gameObject, 0.5f);

  
        }
    }
}
