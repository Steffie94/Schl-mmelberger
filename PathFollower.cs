using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
    Knoten[] pathNode;
    public GameObject snake;
    public float speed;
    float timer;
    int currentNode;
    static Vector3 currentPosition;

    // Use this for initialization
    void Start () {
        pathNode = GetComponentsInChildren<Knoten>();
        CheckNode();
	}

    void CheckNode()
    {
        if (currentNode<pathNode.Length-1)
        {
            timer = 0;
            currentPosition = pathNode[currentNode].transform.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(currentNode);
        timer += Time.deltaTime * speed;

        if(snake.transform.position != currentPosition)
        {
            snake.transform.position = Vector3.Lerp(snake.transform.position,currentPosition,timer);
        }
        else
        {
            if (currentNode < pathNode.Length - 1)
            {
                currentNode++;
                CheckNode();
            }
        }
    }
}
