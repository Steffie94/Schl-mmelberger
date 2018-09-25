using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    Rigidbody rb;
    public float bulletSpeed;
    public float Intervall;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, bulletSpeed, ForceMode.Impulse);
        // Zerstört die Bullet nach ablauf des Intervalls
        Destroy(gameObject, Intervall);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
