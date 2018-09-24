using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SnakeBrain : MonoBehaviour
{
    //Länge der Schlange erweitert.
    //public int anzahl = 4;

    //Nummerierung der Tailstücke.
    //int anzahlN = 0;

    float time = 0;
    Vector3 nextPosition;
    Vector3 lastPostion;


    public List<Transform> TailParts = new List<Transform>();

    public float space = 0.3f;
    public float speed = 1;
    public float RotationDriveMode = 20;

    public GameObject body;

    private float distance;
    private Transform curTailPart;
    private Transform prevTailPart;

    /* Kopf der Schlange
    int head = 0;

    //Bereit zum generieren der Tails
    public bool ready = false;

    //Abstand zwischen den Blöcken.
    public float space = 0.50f;

    //Array für die Blöcke die hinzugefügt werden.
    //public GameObject[] array;

    //Schnelligkeit in Sekunden.
    public float speed = 8f;

    //Zeitstempel damit wir die Snake Bewegungen controllieren können.
    float timeStamp = 0f;

    //Welche Richtung soll die Schlange sich bewegen.
    //int whichDirection = 1;

    //Schrittezähler damit er nach einer Anzahl die Richtung wechselt.
    int stepCount = 0;
    */

    public int beginnSize = 1;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < beginnSize - 1; i++)
        {
            //wenn True wird die Schlange erst erweitert.
            //GenerateTail();
            StartCoroutine(GenerateTail());
            Debug.Log("Snake build");
        }
        //if (ready)
        //{
        


        //        }
    }


    // Der Kopf soll geclonet werden um eine bestimmte Zahl 
    //und an den Kopf angehängt werde, sie darf die gesamt Anzahl 
    //nicht überschreiten. 
    private IEnumerator GenerateTail()
    //void Generate()
    {
        /*
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
            */

        Transform newTailPart = (Instantiate(body, TailParts[TailParts.Count - 1].position,
                    TailParts[TailParts.Count - 1].rotation) as GameObject).transform;

        newTailPart.SetParent(transform);
        Debug.Log("Created");
        TailParts.Add(newTailPart);
        yield return new WaitForSeconds(0.3f);
    }

    // Update is called once per frame
    void Update()
    {

            if (TailParts == null)
            {
                time = Mathf.Clamp(time +Time.deltaTime,0,1);
                float distanceToNext= Vector3.Distance(transform.position,nextPosition);
                
                if(distanceToNext > 0)
                {
                    transform.position = Vector3.Lerp(lastPostion,nextPosition,time);
                }
                else
                {
                    lastPostion = nextPosition;
                    nextPosition = body.transform.position;
                    time = 0;
                }
            }
         
    }

    void Move()
    {
        float currenSpeed = speed;
        
        TailParts[0].Translate(TailParts[0].forward * currenSpeed * Time.smoothDeltaTime);
       /* for (int i = 1; i < TailParts.Count; i++)
        {
            curTailPart = TailParts[i];
            prevTailPart = TailParts[i - 1];

            //distance = Vector3.Distance(prevTailPart.position,curTailPart.position);

            Vector3 newPosition = prevTailPart.position ;

            newPosition.y = TailParts[0].position.y;

            //curTailPart.position = Vector3.Slerp
        }*/
    }

}