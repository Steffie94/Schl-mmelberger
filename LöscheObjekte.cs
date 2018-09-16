using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LöscheObjekte : MonoBehaviour {

    public float lebensSpanne;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Zerstört ein GameObject wenn die lebensSpanne 0 wird
        Destroy(gameObject, lebensSpanne);
    }
}
