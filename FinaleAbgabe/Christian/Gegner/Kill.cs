using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour {

    public GameObject deatheffect;
    private int leben;
    public int bounce = 10;
    public AudioSource sound;

    // Use this for initialization
    void Start ()
    {
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        leben = FindObjectOfType<SpieleManager>().AnzahlLeben();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && leben > 0)
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);

            Instantiate(deatheffect, transform.position, transform.rotation).transform.parent = this.transform;
            FindObjectOfType<SpielerSteuerung>().BounceOnCommand(bounce);
            sound.Play();
            Destroy(transform.parent.gameObject, 0.8f);
        }
    }
}
