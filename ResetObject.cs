using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour {

    Vector3 pos;
    Quaternion rotat;

	// Use this for initialization
	void Start () {
        Checkpoint();
	}
    public void ResetingMe()
    {
        transform.position = pos;
        transform.rotation = rotat;
    }

    public void Checkpoint()
    {
        pos = transform.position;
        rotat = transform.rotation;
    }
}
