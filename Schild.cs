using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schild : MonoBehaviour {

    public string text;
    public DialogManager dMan;

	// Use this for initialization
	void Start ()
    {
        dMan = FindObjectOfType<DialogManager>();
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
                dMan.zeigeDialog(text);
                
            }
        }
    }
}
