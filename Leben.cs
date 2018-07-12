using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leben : MonoBehaviour {

    public int maxLeben;
    public int momLeben;

	// Use this for initialization
	void Start ()
    {
        momLeben = maxLeben;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void schadenSpieler(int schaden)
    {
        momLeben -= schaden;
    }

    public void heileSpieler (int heilung)
    {
        momLeben += heilung;

        //Verhindert das man mehr Leben als Maximal haben kann
        if(momLeben > maxLeben)
        {
            momLeben = maxLeben;
        }

    }
}
