using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxActive : MonoBehaviour {
    public GameObject box;
    public bool visibal;

    void Start()
    {
        visibal = false;
        //box.SetActive(false);

    }

    public void Pushed ( bool active)
    {
	    if(visibal == active)
        {
            box.SetActive(true);
        }
        else
        {
            box.SetActive(false);
        }
	}
}
