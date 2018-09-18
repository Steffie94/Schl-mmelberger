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
        Zielverändern();

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        bewegendePlatform.position = Vector3.Lerp(bewegendePlatform.position, neuePosition, smooth * Time.deltaTime);

    }

    public void Zielverändern()
    {
        if (momentanerStatus == "Moving 1")
        {
            momentanerStatus = "Moving 2";
            neuePosition = positionB.position;
        }
        else if(momentanerStatus == "Moving 2")
        {
            momentanerStatus = "Moving 1";
            neuePosition = positionA.position;
        }
        else if(momentanerStatus == "")
        {
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
