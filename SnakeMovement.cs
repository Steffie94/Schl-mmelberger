using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement  : MonoBehaviour
{   
    public Transform positionA;
    public Transform positionB;
    public Vector3 newTarget;
    public string momentanerStatus;
    int lastachse;

    public float zeitZuruecksetzen;
    
    //Soll sich bewegen wenn TRUE
    bool moveNow = false;

    //Länge der Schlange erweitert.
    int anzahl = 6;

    //Nummerierung der Tailstücke.
    int anzahlN = 0;

    // Kopf der Schlange
    int head = 0;

    //Bereit zum generieren der Tails
    bool ready = true;

    //Abstand zwischen den Blöcken.
    public float space = 0.90f;

    //Array für die Blöcke die hinzugefügt werden.
    public GameObject[] array;

    //Schnelligkeit in Sekunden.
    public float speed = 20f;

    //Zeitstempel damit wir die Snake Bewegungen controllieren können.
    float timeStamp = 0f;

    //Welche Richtung soll die Schlange sich bewegen.
    int whichDirection = 1;

    //Schrittezähler damit er nach einer Anzahl die Richtung wechselt.
    int stepCount = 0;

    void Start()
    {
        ChangeTarget();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (ready)
            {
                StartCoroutine(GenerateTail());
            }
        }
    }

    // Der Kopf soll geclonet werden um eine bestimmte Zahl 
    //und an den Kopf angehängt werde, sie darf die gesamt Anzahl 
    //nicht überschreiten
    private IEnumerator GenerateTail()
    {
        ready = false;
        array = new GameObject[anzahl];

        //Wir starten bei 1, damit auf dem Kopf 
        //kein zweiter Teil der Snake gebaut wird und der Kopf mit zieht.
        array[0] = this.gameObject;

        for (int zahl = 1; zahl < anzahl; zahl++)
        {
            GameObject hinten = GameObject.CreatePrimitive(PrimitiveType.Cube);
            hinten.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
 
            // Damit sie nach hinten ausgerichtet sind und nicht aufeinander.
            hinten.transform.position = this.transform.position;
            if (Time.timeScale == 1f)
            {
                hinten.transform.Translate(this.transform.forward *space * speed* Time.timeScale);
                array[zahl] = hinten;
            }
            yield return new WaitForSeconds(0.01f);
        }

        //Was war das letze Teil im Array
        anzahlN = array.Length-2 ;
        moveNow = true;
    }

    void Update()
    {
        // wenn Zeit verbraucht dann move 
        if (Time.time - timeStamp > speed && moveNow == true)
        {
           
            timeStamp = Time.time;
            Debug.Log(timeStamp);
            //FEHLER WEGEN MOVE geht 2 zurück ??
            Move();

            if (stepCount == 6)//Länge von Snake
            {
                stepCount = 0;
                //Wenn Target ein Tag hat soll er zu ihm gehn.
                ChaseTarget();
            }
        }
    }

    public void ChangeTarget()
    {
        if (momentanerStatus == "Moving 1")
        {
            momentanerStatus = "Moving 2";
            newTarget = positionB.position;
        }
        else if (momentanerStatus == "Moving 2")
        {
            momentanerStatus = "Moving 1";
            newTarget = positionA.position;
        }
        else if (momentanerStatus == "")
        {
            momentanerStatus = "Moving 2";
            newTarget = positionB.position;   
        }

        Invoke("ChangeTarget", zeitZuruecksetzen);

    }

    void ChaseTarget()
    {//Eine Random Nummer wählen zwischen 1-3 und diese mit der anderen Seite des Würfel Multiplizieren.
        //x--1+6,y--2+5,z--3+4 Dies tun wir damit wir entscheiden welche Achse man verwendet.
        int achse = (int)Random.Range(1, 4);
        if (achse != lastachse){
            lastachse = achse; }else{
           achse = Random.Range(1,4);
           Debug.Log("Meine Neueachsennummer" + achse);
           lastachse = achse ;
        }
        //Richtungswechsel zum Target hin
        switch (achse)
        { case 1:
                if (this.transform.position.x < newTarget.x)
                {
                    whichDirection = 3; // Rechts
                }else if (this.transform.position.x > newTarget.x)
                {
                    whichDirection = 4;//Links
                }else {
                    whichDirection = 1;//Vorwärts
                }
                break;
             case 2:
                    if (this.transform.position.y < newTarget.y) {
                        whichDirection = 2; //Hoch
                    } else if (this.transform.position.y > newTarget.y)
                    {
                        whichDirection = 5;//Unten
                    } else {
                        whichDirection = 1;//Vorwärts
                    }
                    break;
                case 3:
                if (this.transform.position.z < newTarget.z){
                        whichDirection = 1;//Vorwärts
                } else if (this.transform.position.z > newTarget.z)
                    {
                        whichDirection = 5;//Hinten
                } else {
                        whichDirection = 3;//Rechts
                    }
                break;
        }
        RotateSnake();
    }
    
    //Rotate in der angegebenen Richtung
    void RotateSnake()
    {
        //Rotatation der Snake
        switch (whichDirection)
        {
            // 1-7 Alle Würfel Seiten müssen 7 ergeben 1+6;2+5;3+4
            case 1:
                //Gerade
                array[anzahlN].transform.eulerAngles = new Vector3(0f, 0f, 0f);
                break;
            case 2:
                //Hoch
                array[anzahlN].transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                break;
            case 3:
                //Right
                array[anzahlN].transform.eulerAngles = new Vector3(0f, 90f, 0f);
                break;
            case 4:
                //Left
                array[anzahlN].transform.eulerAngles = new Vector3(0f, -90f, 0f);
                break;
            case 5:
                //Runter
                array[anzahlN].transform.eulerAngles = new Vector3(90f, 0f, 0f);
                break;
            case 6:
                //Hinten
                array[anzahlN].transform.eulerAngles = new Vector3(0f, 180f, 0f);
                break;
        }

        //Damit die Taile mit der Rotation Änderrung mit ziehen
        for (int i = 1; i <= array.Length; i++)
        {
            array[i].transform.rotation = array[anzahlN].transform.rotation;
        }

    }

    void Move()
    {
            // Anzahl N in ausgewählte Richtung bewegen.
            array[anzahlN].transform.position = array[head].transform.position;
            //Neuen Kopf in ausgewählter Richtung bewegen.

            array[anzahlN].transform.Translate(Vector3.forward * space * speed);

            //Klarstelen was unser Head und Tail ist.
            head = anzahlN;

            anzahlN = anzahlN - 1;

            if (anzahlN == -1)
            {
                anzahlN = array.Length - 1;
            }
            //Snake hat sich Bewegt.
            stepCount++;
    }
}