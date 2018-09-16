using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSteuerung : MonoBehaviour {

    public GameObject ziel;
    public Vector3 offset;
    public bool useOffsetValues;
    public float rotationsGeschwindigkeit;

    //Ein Gameobject das man nicht sehen kann und sich immer beim Spieler befindet. Es ist eine Hilfe um die Kamera zu bedienen
    public GameObject pivot;

    //Maximale Höhe der Kamera
    public float max;

    //Minimale Höhe der Kamera
    public float min;

    //Invertierung der Mausrichtung ja nein
    public bool invertY;

    // Use this for initialization
    void Start ()
    {
        //Versteckt den Mauszeiger
        Cursor.lockState = CursorLockMode.Locked;

        rotationsGeschwindigkeit = 5.0f;

        ziel = GameObject.Find("Spieler");
        pivot = GameObject.Find("Pivot");

        pivot.transform.position = ziel.transform.position;
        //pivot.transform.parent = ziel.transform;
        //Verändert die Eltern Objekte nicht mit
        pivot.transform.parent = null;

        if (!useOffsetValues)
        {
           offset = ziel.transform.position - transform.position;
        }
    }
	
	// Damit es nach Spieler Update ausgeführt wird
	void LateUpdate ()
    {
        //Macht das der Pivot Punkt sicher immer mit dem Spieler bewegt
        pivot.transform.position = ziel.transform.position;

        //Holt die X Position der Maus und Rotiert den Pivot Punkt. Verhindert das der Spieler sich mit der Kamera dreht
        float horizontal = Input.GetAxis("Mouse X") * rotationsGeschwindigkeit;
        pivot.transform.Rotate(0, horizontal,0);

        //Y Position der Maus holen und den Pivot drehen
        float vertical = Input.GetAxis("Mouse Y") * rotationsGeschwindigkeit;
        //pivot.transform.Rotate(vertical, 0, 0);
        
        if(invertY)
        {
            pivot.transform.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.transform.Rotate(-vertical, 0, 0);
        }

        //Limit oben/unten für Kamera
        if(pivot.transform.rotation.eulerAngles.x > max && pivot.transform.rotation.eulerAngles.x < 180f)
        {
            pivot.transform.rotation = Quaternion.Euler(max, 0, 0);
        }

        if (pivot.transform.rotation.eulerAngles.x > 180 && pivot.transform.rotation.eulerAngles.x < 360f + min)
        {
            pivot.transform.rotation = Quaternion.Euler(360f + min, 0, 0);
        }   
        //Bewegt die Kamera nach der momentanen Rotation des Pivots und des offsets
        float desiredYAngle = pivot.transform.eulerAngles.y;
        float desiredXAngle = pivot.transform.eulerAngles.x;

        Quaternion drehung = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = ziel.transform.position - (drehung * offset);

        //Verhinder das die Kamera durch den Boden geht
        if(transform.position.y < ziel.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ziel.transform.position.y, transform.position.z);
        }
        //Schaut immer auf das Ziel
        transform.LookAt(ziel.transform);
	}
}
