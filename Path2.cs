using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path2 : MonoBehaviour {

    public Transform pathNode;
    public Transform snake;
    int index;
    public float speed = 0.3f;
    
    public float speedrotation;
    Vector3 distance;

    int currentNode;
    Quaternion neueRotation;
    static Vector3 currentPosition;

    // Use this for initialization
    void Start () {

        index = 0;
        snake = pathNode.GetChild(index);
        
    }

    void OnDrawGizmos()
    {
        Vector3 start;
        Vector3 end;

        for (int i = 0; i < pathNode.childCount;i++)
        {
            start = pathNode.GetChild(i).position;
            end = pathNode.GetChild((i+1)%pathNode.childCount).position;
            Gizmos.DrawLine(start,end);

        }
    }

    // Update is called once per frame
    void Update () {
        Rotate();
        transform.position = Vector3.MoveTowards(transform.position, snake.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position,snake.position) < 0.1f)
        {
            index++;
            index %= pathNode.childCount;
            snake = pathNode.GetChild(index);
        }
    }

    void Rotate()
    {
        distance = transform.position - snake.position;
        neueRotation = Quaternion.LookRotation(distance, transform.forward);
        neueRotation.x = 0;
        neueRotation.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, neueRotation, speedrotation * Time.deltaTime);
    }

}
