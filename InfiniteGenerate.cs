using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tile
{
    public GameObject theTile;
    public float creationTime;

    public Tile(GameObject t, float ct)
    {
        theTile = t;
        creationTime = ct;
    }
}

public class InfiniteGenerate : MonoBehaviour
{

    public GameObject plane;
    public GameObject player;

    int planeSize = 10;
    int halfTilesX = 5;
    int halfTilesZ = 5;

    Vector3 startPos;

    Hashtable tiles = new Hashtable();

    // Use this for initialization
    void Start()
    {
        this.gameObject.transform.position = Vector3.zero;
        startPos = Vector3.zero;

        float updateTime = Time.realtimeSinceStartup;

        for (int x = -halfTilesX; x < halfTilesX; x++)
        {
            for (int z = -halfTilesZ; z < halfTilesZ; z++)
            {
                Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);

                string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                t.name = tilename;
                Tile tile = new Tile(t, updateTime);
                tiles.Add(tilename, tile);
            }
        }
    }
    /*
     * Die Landschaft generiert sich immer weiter 
    // Update is called once per frame
    void Update()
    {
        //Bestimmen Sie, wie weit sich der Spieler seit dem letzten Geländeupdate bewegt hat
        int xMove = (int)(player.transform.position.x - startPos.x);
        int zMove = (int)(player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= planeSize || Mathf.Abs(zMove) >= planeSize)
        {
            float updateTime = Time.realtimeSinceStartup;

            //erzwinge eine ganzzahlige Position und renne zur nächsten Kachelgröße
            int playerX = (int)(Mathf.Floor(player.transform.position.x / planeSize) * planeSize);
            int playerZ = (int)(Mathf.Floor(player.transform.position.z / planeSize) * planeSize);

            for (int x = -halfTilesX; x < halfTilesX; x++)
            {
                for (int z = -halfTilesZ; z < halfTilesZ; z++)
                {
                    Vector3 pos = new Vector3((x * planeSize + startPos.x), 0, (z * planeSize + startPos.z));
                    string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();

                    if (!tiles.ContainsKey(tilename))
                    {
                        GameObject t = (GameObject)Instantiate(plane, pos, Quaternion.identity);
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles.Add(tilename, tile);
                    }
                    else
                    {
                        (tiles[tilename] as Tile).creationTime = updateTime;
                    }
                }
            }
            //zerstöre alle nicht neu erstellten oder mit der Zeit aktualisierten Kacheln
            //lege neue Kacheln und Kacheln in die neue Hashtabelle
            Hashtable newTerrain = new Hashtable();
            foreach (Tile tls in tiles.Values)
            {
                if (tls.creationTime != updateTime)
                { //delete gameobject
                    Destroy(tls.theTile);
                }
                else
                {
                    newTerrain.Add(tls.theTile.name, tls);
                }
            }
            //Kopiert die neue Hash-Tabelleninhalte in die arbeitende Hashtabelle
            tiles = newTerrain;
            startPos = player.transform.position;
        }
    }*/
}

