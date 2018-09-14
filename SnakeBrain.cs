using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBrain : MonoBehaviour
{
    //Länge der Schlange erweitert.
    public int anzahl = 4;
    
    //Nummerierung der Tailstücke.
    int anzahlN = 0;

    // Kopf der Schlange
    int head = 0;
    
    //Bereit zum generieren der Tails
    public bool ready = false;
    
    //Abstand zwischen den Blöcken.
    public float space = 0.50f;

    //Array für die Blöcke die hinzugefügt werden.
    public GameObject[] array;

    //Schnelligkeit in Sekunden.
     public float speed = 8f;

    //Zeitstempel damit wir die Snake Bewegungen controllieren können.
    float timeStamp = 0f;

    //Welche Richtung soll die Schlange sich bewegen.
    int whichDirection = 1;

    //Schrittezähler damit er nach einer Anzahl die Richtung wechselt.
    int stepCount = 0;


    // Use this for initialization
    void Start()
    {
        //wenn True wird die Schlange erst erweitert.
        if (ready)
        {
            GenerateTail();
        }
    }


    // Der Kopf soll geclonet werden um eine bestimmte Zahl 
    //und an den Kopf angehängt werde, sie darf die gesamt Anzahl 
    //nicht überschreiten. 
    void GenerateTail()
    {
        ready = false;
        array = new GameObject[anzahl];

        //Wir starten bei 1, damit auf dem Kopf 
        //kein zweiter Teil der Snake auf der selben Stelle gebaut wird.
        array[0] = this.gameObject;

        for (int zahl = 1; zahl < anzahl; zahl++)
        {
            GameObject hinten = GameObject.CreatePrimitive(PrimitiveType.Cube);

            // Damit sie nach hinten ausgerichtet sind und nicht aufeinander.
            hinten.transform.position = this.transform.position;
            hinten.transform.Translate(this.transform.forward * -zahl * space);

            array[zahl] = hinten;  

        }
        //Was war das letze Teil im Array
            anzahlN = array.Length - 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeStamp > speed)
         {
            timeStamp = Time.time;
            Move();

            if (stepCount == 2)//Länge von Snake
            {
                Debug.Log("Ich wechsle meine Richtung !");
                CheckDirection();
            }
         }
    }

    void CheckDirection()
    {
        //Nach dem man die Anzahl 4 erreicht hat 
        stepCount = 0;
        //Nach einer 
        whichDirection = (int)(Random.Range(1, 6));
        Debug.Log("Neue Richtung " + whichDirection);

    }

    void Move()
    {
        // Anzahl N in ausgewählte Richtung bewegen.
        array[anzahlN].transform.position = array[head].transform.position;

        //Neuen Kopf in ausgewählter Richtung bewegen.
        if (whichDirection == 1)
        {   //Gerade
            array[anzahlN].transform.Translate(array[anzahlN].transform.forward * space);
        }
        else if (whichDirection == 2)
        {   //Links
            array[anzahlN].transform.Translate(array[anzahlN].transform.right * -space);
        }
        else if(whichDirection == 3)
        {   //
            array[anzahlN].transform.Translate(array[anzahlN].transform.right * space);
        }
        else if (whichDirection == 4)
        {   //Hoch
            array[anzahlN].transform.Translate(array[anzahlN].transform.up * space);
        }
        else if (whichDirection == 5)
        {   //Runter
            array[anzahlN].transform.Translate(array[anzahlN].transform.up * -space);
        }

        //Klarstelen was unser Head und Tail ist.
        head = anzahlN;
        anzahlN = anzahlN-1;

        if (anzahlN == -1)
        {
            anzahlN = array.Length - 1;
        }
        //Snake hat sich Bewegt.
        stepCount++;

    }

}