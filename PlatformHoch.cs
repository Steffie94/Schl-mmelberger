using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHoch : MonoBehaviour {

    public Transform bewegendePlatform;
    public Transform positionA;
    public Transform positionB;
    public Vector3 neuePosition;

    public string momentanerStatus;
    public float smooth;
    public float zeitZuruecksetzen;

    // Use this for initialization
    void Start ()
    {
	// Zu Beginn soll diese Methode ausgeführt werden.
        Zielverändern();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
		//Damit sie sich geschmeidig bewegt und die Position der Platte bekannt ist 
        bewegendePlatform.position = Vector3.Lerp(bewegendePlatform.position, neuePosition, smooth * Time.deltaTime);

    }

    public void Zielverändern()
    {
        if (momentanerStatus == "Moving 1")
        {
		//Bewegt sich von a nach b
            momentanerStatus = "Moving 2";
            neuePosition = positionB.position;
        }
        else if(momentanerStatus == "Moving 2")
        {
		//bewegt sich von b nach a (Startposition)
            momentanerStatus = "Moving 1";
            neuePosition = positionA.position;
        }
        else if(momentanerStatus == "")
        {
	// Ansonsten soll sie sich zur neuen Position also B bewegen.
            momentanerStatus = "Moving 2";
            neuePosition = positionB.position;
        }
	    
        Invoke("Zielverändern", zeitZuruecksetzen);
    }


    //Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent =transform;

        }
    }

    //Wenn der PLayer die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent= null;
        }
    }
}
