using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    // Damit wir das Leben vom Spieler benutzen können.
    private Leben live;

    public int hurt = 1;

    void Start ()
    {
        // Mit Hilfe des Tags Player können wir auf Leben zugreifen.
            live = GameObject.FindGameObjectWithTag("Player").GetComponent<Leben>();
    }

    void OnTriggerEnter(Collider col)
    {
        // Wenn das Object mit dem Tag Player die Spikes in Kontakt kommt.
        
            if (col.CompareTag("Player"))
            {
                // In welche Richtung der Spieler geschleudert wird.
                Vector3 direction = col.transform.position - transform.position;
                direction = direction.normalized;
                
                //Aufruf einer Funktion vom Script Leben die das Leben reduziert.
                FindObjectOfType<Leben>().schadenSpieler(hurt, direction);

            }
    }
}
