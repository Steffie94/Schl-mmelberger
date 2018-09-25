using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schild : MonoBehaviour {

    public string text;
    public DialogManager dMan;
    public AudioSource lesen;

    // Use this for initialization
    void Start ()
    {
        dMan = FindObjectOfType<DialogManager>();
        lesen = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                lesen.Play();
                dMan.zeigeDialog(text);
                
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        lesen.Pause();
        dMan.wegDialog();
    }
}
