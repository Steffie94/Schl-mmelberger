using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    //Die Position des Ziels.
    public Transform target;
    public Vector3 newTarget;

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
    GameObject[] array;

    //Schnelligkeit in Sekunden.
    public float speed = 20f;

    //Zeitstempel damit wir die Snake Bewegungen controllieren können.
    float timeStamp = 0f;

    //Welche Richtung soll die Schlange sich bewegen.
    int whichDirection = 1;

    //Schrittezähler damit er nach einer Anzahl die Richtung wechselt.
    int stepCount = 0;

    //Wenn der Player auf Startplatte sprint soll er sich generieren.
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            //Wenn ready true ist dann soll er sie generieren.
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
        //Generiert nicht noch mehr.
        ready = false;
        //Snake größe hinzufügen.
        array = new GameObject[anzahl];

        //Wir starten bei 1, damit auf dem Kopf 
        //kein zweiter Teil der Snake gebaut wird und der Kopf mit zieht.
        array[0] = this.gameObject;
        
        for (int zahl = 1; zahl < anzahl; zahl++)
        {   
            //Die Generierung der Tails mit Cubes.
            GameObject hinten = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            //Die Größe der Snaketails festgelegt und die Position merken.
            hinten.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            hinten.transform.position = this.transform.position;

            // Als nächstes sollen sich die Tails nach vorne ausgerichtet sein und nicht aufeinander gestappelt sein. Damit dies auch passiert nimmt man den Abstand mal.
            //Die Zeit in der sich die Tails bilden soll mit berechnet werden und damit es schnell geht benutzt man TimeScale und Speed. 
            if (Time.timeScale == 1f)
            {
                hinten.transform.Translate(this.transform.forward * space * speed * Time.timeScale);
                array[zahl] = hinten;
            }
            // Damit die Tails sich nach einem Zeitabbstand bilden.
            yield return new WaitForSeconds(0.01f);
        }

        //Was war das letze Teil im Array
        anzahlN = array.Length - 2;
        // Jetzt darf er sich bewegen.
        moveNow = true;
    }

    //  Sorgt däfür dass die Snake sich bewegt und die Richtung ändert aufgerufen wird und sie sich bewegt.
    void Update()
    {
        //Starte wenn moveNow true gesetzt wird und der Zeitstempel höher als Speed ist.
        if (Time.time - timeStamp > speed && moveNow == true)
        {
            timeStamp = Time.time;
            Move();
            
            //Soll wenn StapCount 6 ist die Richtung wechseln.
            if (stepCount == 3)
            {
                stepCount = 0;
                ChaseTarget();
            }
        }
    }

    //Festlegen der Ziel position.
    public void ChangeTarget()
    {
        newTarget = target.position;
    }

    //Zum Target gehen.
    void ChaseTarget()
    {
        int achse = 1;
        switch (achse)
        {
            case 1:
                //Wenn die Position der Snake vom Target kleiner ist geh rechts 
                if (this.transform.position.x < newTarget.x)
                {
                    //Rechts
                    whichDirection = 2;
                }
                break;
        }
        //Rotiere wenn der Weg entschieden ist.
        RotateSnake();
    }

    //Rotate in der angegebenen Richtung
    void RotateSnake()
    {
        //Rotatation der Snake Rechts und Gerade wenn einmal gedreht raus werfen.
        switch (whichDirection)
        {
            case 1:
                //Right
                array[anzahlN].transform.eulerAngles = new Vector3(0f, 90f, 0f);
                break;
        }
        //Damit die Taile mit der Rotation Änderrung mit ziehen
        for (int i = 1; i < array.Length; i++)
        {
            array[i].transform.rotation = array[anzahlN].transform.rotation;
        }
    }

    //Bewegung der Snake.
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