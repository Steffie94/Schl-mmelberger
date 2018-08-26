using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    // Damit wir das Leben vom Spieler benutzen können
    private Leben live;

    public int hurt = 1;

    void Start ()
    {
            live = GameObject.FindGameObjectWithTag("Player").GetComponent<Leben>();
    }

    void OnTriggerEnter(Collider col)
    {
            if (col.CompareTag("Player"))
            {
                Vector3 direction = col.transform.position - transform.position;
                direction = direction.normalized;

                FindObjectOfType<Leben>().schadenSpieler(hurt, direction);

            }
    }
}