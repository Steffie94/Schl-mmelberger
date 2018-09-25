using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAufheben : MonoBehaviour {

    public int wert;
    public GameObject pickupEffect;
    public AudioSource sammeln;

    // Use this for initialization
    void Start ()
    {
        sammeln = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<SpieleManager>().AddGold(wert);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject,0.1f);
            sammeln.Play();
        }
    }

}
