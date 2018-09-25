using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    public bool aktivDialog;

	// Use this for initialization
	void Start ()
    {
        dBox.SetActive(false);
        aktivDialog = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (aktivDialog && Input.GetKeyDown(KeyCode.Mouse1))
        {
            dBox.SetActive(false);
            aktivDialog = false;
        }
	}

    public void zeigeDialog(string text)
    {
        dBox.SetActive(true);
        aktivDialog = true;
        dText.text = text;
    }

    public void wegDialog()
    {
        dBox.SetActive(false);
        aktivDialog = false;
    }
}
