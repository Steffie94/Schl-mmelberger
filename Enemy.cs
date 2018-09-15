using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //Schadenswert
    public int hurt = 1;
    public bool stomp ;
    Leben live;

    void Start()
    {
        live = GameObject.FindGameObjectWithTag("Player").GetComponent<Leben>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!stomp)
        {
            if (other.gameObject.tag == "Player")
            {
                Vector3 damageDirection = other.transform.position - transform.position;
                damageDirection = damageDirection.normalized;

                FindObjectOfType<Leben>().schadenSpieler(hurt, damageDirection * (transform.position.y * 2.0f));
            }
        }
    }

}