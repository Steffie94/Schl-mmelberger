using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysikPlayer : MonoBehaviour {

    public float schieben;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate () {

        rb.AddForce(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))*schieben,ForceMode.Acceleration);
        
	}
}
