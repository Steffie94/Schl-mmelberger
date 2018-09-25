using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour {

    //Weg hinzufügen.
    public Transform pathNode;
    //Platte hinzufügen
    public Transform platte;

    int index;

    //Die Geschwindigkeit der Bewegung der Platten.
    public float speed = 0.3f;

    //Damit man den aktuelle Punkt, wo die Platte ist bekommt. 
    int currentNode;

    //Damit wir die aktuelle Ste
    static Vector3 currentPosition;

    // Zu beginn wird der Platte der Path mit seinen Punkten(Index) übergeben.
    void Start () {
        index = 0;
        //Die erste Knoten wird zugewiesen.
        platte = pathNode.GetChild(index);
    }

    // Update is called once per frame
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, platte.position, speed * Time.deltaTime);

        //Fürs wechseln zum nächsten Punkt.
        //Wenn die distance der vom jetzigen Punkt bis zum Zielpunkt weniger als 0.1 beträgt geh rein 
        if(Vector3.Distance(transform.position,platte.position) < 0.1f)
        {
            //Nächsten Punkt zuweisen in dem man index um eins erhöht
            index++;
            index %= pathNode.childCount;
            platte = pathNode.GetChild(index);
        }
    }
}
