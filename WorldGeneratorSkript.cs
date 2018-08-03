using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneratorSkript : MonoBehaviour {

    //Array für die Objekte die in der Welt gespawnend werden
    [SerializeField]
    private GameObject[] trees;
    [SerializeField]
    private GameObject[] stones;

    [SerializeField]
    private GameObject[] terrain;

    private int stoneChanceAmt = 5; // Steinmenge

    //Marker Objekte (meine Markierungen)
    [SerializeField]
    private GameObject blMarker;
    [SerializeField]
    private GameObject trMarker;

    //Variablen zur Steuerung der Weltgröße (Spawing Gitterwerte):
    private Vector3 currentPos;
    private Vector3 worldObjectsStartPos;
    private Vector3 terrainStartPos;

    private float groundWidth;

    private float worldObjectIncAmt; // Variable für die Distanz der WorldObjecte
    private float terrainIncAmt; // Variable für die Distanz der Terrain Objecte

    private float worldObjectRandAmt;
    private float terrainRandAmt;

    //Die Werte für die Spawn-Schleife durch das Gitter
    [SerializeField]
    private int worldObjectRowsAndCols; // Variable die sagt wie Nah die Objekte spawnen
    [SerializeField]
    private int terrainRowsAndCols;

    [SerializeField]
    private int repeatPasses;
    private int currentPass;

    [SerializeField]
    private float worldObjectSphereRad;
    [SerializeField]
    private float terrainSphereRad;


    //Masken der einzelnen Ebenen
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private LayerMask terrainLayer;
    [SerializeField]
    private LayerMask worldObjectsLayer;

    // Use this for initialization
    void Start () {
        StartCoroutine("SpawnWorld");
	}
    //Hier wird "SpawnWorld" definiert
    IEnumerator SpawnWorld()
    {
        groundWidth = trMarker.transform.position.x - blMarker.transform.position.x; // Die Breite unseres Bodens ist die Entfernung der beiden Objekte

        worldObjectIncAmt = groundWidth / worldObjectRowsAndCols;
        worldObjectRandAmt = worldObjectIncAmt / 2f;

        terrainIncAmt = groundWidth / terrainRowsAndCols;
        terrainRandAmt = terrainIncAmt / 2f;

        //Wie bewegen wir uns von der Startposition aus
        worldObjectsStartPos = new Vector3(blMarker.transform.position.x - (worldObjectIncAmt/2f), blMarker.transform.position.y, blMarker.transform.position.z + (worldObjectIncAmt/2f));
        terrainStartPos = new Vector3(blMarker.transform.position.x -(terrainIncAmt /2f), blMarker.transform.position.y,blMarker.transform.position.z+(terrainIncAmt / 2f));

        //Die Spawn-Schleife
        for (int rp = 0; rp <= repeatPasses; rp++)
        {
            currentPass = rp; //Variable die den aktuellen Durchlauf speichert

            if (currentPass == 0)
            {
                currentPos = terrainStartPos; //Die aktuelle Position soll der Startposition des Terains entsprechen

                //Durchlaufen Zeile und Spalte
                for (int rows = 1; rows <= terrainRowsAndCols; rows++) 
                {
                    for (int cols = 1; cols <= terrainRowsAndCols; cols++)
                    {
                        // Die Aktuelle Position bekommt jedes mal ein Neuen Vektor desen X Position sich erhöht
                        currentPos = new Vector3(currentPos.x + terrainIncAmt, currentPos.y, currentPos.z);

                        //Das Objekt das gespawned werden soll
                        GameObject newSpawn = terrain[Random.Range(0, terrain.Length)]; // Random Objekt zwischen 0 und Terrain länge

                        // Sobald wir ein Objekt definiert haben soll es gespawnd werden
                        SpwanHere(currentPos, newSpawn, terrainSphereRad, true);//True bei einem Terrainobjekt

                        // Gibt Wartezeit zurück
                        // es soll ein wenig warten bevor er zum nächsten Objekt geht
                        yield return new WaitForSeconds(0.01f);
                    }
                    // Wenn wir am Ende des Gitters angekommen sind müssen wir es auf den Beginn zurück setzen und eine Gitterzeile weiter rücken
                    currentPos = new Vector3(terrainStartPos.x, currentPos.y, currentPos.z + terrainIncAmt);
                }
            }
            else if (currentPass > 0)
            {   
                currentPos = worldObjectsStartPos; // Die aktuelle Position soll die Startposition der Worldobjekte bekommen

                //Durchlaufe Zeile und Spalten
                for (int cols = 1; cols <= worldObjectRowsAndCols; cols++)
                {
                    for (int rows = 1; rows <= worldObjectRowsAndCols; rows++)
                    {
                        // Die Aktuelle Position bekommt jedes mal ein Neuen Vektor desen X Position sich erhöht
                        currentPos = new Vector3(currentPos.x + worldObjectIncAmt, currentPos.y,currentPos.z);

                        //Damit Steine nicht so oft spawnen wie Bäume
                        //deswegen eine Varianble die die Reichweite zwischen 1 und 5 festgelegt ist
                        int SpawnChance = Random.Range(1, stoneChanceAmt +1);

                        if (SpawnChance == 1)
                        {
                            // Sollten wie eine SpawnChance bekommen machen wir Sie zu einem GameObject (eine Stein)
                            GameObject newSpawn = stones[Random.Range(0, stones.Length)];
                            SpwanHere(currentPos, newSpawn, worldObjectSphereRad, false);//False bei einem Weltobjekt

                            // Gibt Wartezeit zurück
                            // es soll ein wenig warten bevor er zum nächsten Objekt geht
                            yield return new WaitForSeconds(0.01f);
                        }
                        else
                        {
                            // ansonsten sollen Bäume gespawnd werden
                            GameObject newSpawn = trees[Random.Range(0, trees.Length)];
                            SpwanHere(currentPos, newSpawn, worldObjectSphereRad, false);//False bei einem Weltobjekt

                            // Gibt Wartezeit zurück
                            // es soll ein wenig warten bevor er zum nächsten Objekt geht
                            yield return new WaitForSeconds(0.01f);
                        }
                    }
                    // Wenn wir am Ende des Gitters angekommen sind müssen wir es auf den Beginn zurück setzen und eine Gitterzeile weiter rücken
                    currentPos = new Vector3(worldObjectsStartPos.x,currentPos.y, currentPos.z + worldObjectIncAmt);
                }
            }
        }
        // Soll eine Nachticht ausgeben wenn sie fertig ist
        WorldGenDone();
    }

    void SpwanHere(Vector3 newSpawnPos, GameObject objectToSpawn, float radiusOfSphere, bool isObjectTerrain)
    {
        //Wenn es ein Terrainobjekt ist dann...
        if (isObjectTerrain == true)
        {
            //eine Variable mit Random Punktebereichen aber darauf aufpasst das sie noch im Randbereich liegen (ob wie noch im Gitter uns befinden)
            Vector3 randPos = new Vector3(newSpawnPos.x + Random.Range(-terrainRandAmt, terrainRandAmt + 1), 0, newSpawnPos.z + Random.Range(-terrainRandAmt, terrainRandAmt + 1));

            //Wir werfen ein Raycast um zu sehen ob unten oder oben Boden ist
            //Variable für Raycast ob es hoch oder runter gehen soll
            Vector3 rayPos = new Vector3(randPos.x, 10, randPos.z);

            if (Physics.Raycast(rayPos, -Vector3.up, Mathf.Infinity, groundLayer))//Es soll nach unten gehen(also ist unter uns Boden)
            {
                // es soll nur kollidieren wen wir überhalb vom Boden sind also wenn wir über dem Rand der Welt sind
                //Es könnten mehrere Objekte sein die wir treffen könnten deswegen ein Array
                //Wir werfen ein Radius von einer Kugel zum überprüfen von Überlappungen
                Collider[] objectsHit = Physics.OverlapSphere(randPos, radiusOfSphere, terrainLayer);

                if (objectsHit.Length == 0)// wenn das Array leer sein sollte (also wenn wir nichts getroffen haben)
                {
                    // wir erschaffen ein neues GameObjekt, instanziieren Objekte zum spawnen und referenzieren es als Terrainobjekt
                    GameObject terrainObject = (GameObject)Instantiate(objectToSpawn, randPos, Quaternion.identity);
                    //Random die Objekte routieren lassen
                    terrainObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
                }
            }
        }
        else
        {
            Vector3 randPos = new Vector3(newSpawnPos.x + Random.Range(-worldObjectRandAmt, worldObjectRandAmt + 1), newSpawnPos.y, newSpawnPos.z + Random.Range(-worldObjectRandAmt, worldObjectRandAmt + 1));
            Vector3 rayPos = new Vector3(randPos.x, 20, randPos.z);

            RaycastHit hit;

            if (Physics.Raycast(rayPos, -Vector3.up, out hit, Mathf.Infinity, groundLayer))
            {
                randPos = new Vector3(randPos.x, hit.point.y, randPos.z);

                Collider[] objectsHit = Physics.OverlapSphere(randPos, radiusOfSphere, worldObjectsLayer);//übeprüft Kollisionen 

                if (objectsHit.Length == 0)
                {
                    // wir erschaffen ein neues GameObjekt, instanziieren Objekte zum spawnen und referenzieren es als Worldobjekt
                    GameObject worldObject = (GameObject)Instantiate(objectToSpawn, randPos, Quaternion.identity);
                    // Worldobjekte ein wenig ausrichten
                    worldObject.transform.position = new Vector3(worldObject.transform.position.x, worldObject.transform.position.y + (worldObject.GetComponent<Renderer>().bounds.extents.y*0.7f),
                    worldObject.transform.position.z);
                    //Random die Objekte routieren lassen
                    worldObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, Random.Range(0, 360), transform.eulerAngles.z);
                }
            }
        }
    }
    void WorldGenDone()
    { print("Welt ist generiert!"); }
}
