using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
    Knoten[] pathNode;
    GameObject [] snake;
    public float speed;
   
    float timer;
    int currentNode;

    static Vector3 currentPosition;

    // Use this for initialization
    void Start () {
        snake = GameObject.FindGameObjectsWithTag("Snake");
        pathNode = GetComponentsInChildren<Knoten>();
        CheckKnoten();
	}

    void CheckKnoten()
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

        foreach (GameObject snakeTail in snake)
        {

                if (snakeTail.transform.position != currentPosition)
                {
                    snakeTail.transform.position = Vector3.Lerp(snakeTail.transform.position, currentPosition, timer);
                    
                }
                else
                {
                    if (currentNode < pathNode.Length - 1)
                    {
                        currentNode++;
                        CheckKnoten();
                    }
                }
            
        }
    }

    /*Sorgt dafür das der Player wenn er auf der Platform springt zum Kind von der Platform wird.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player Parent setzen.
            other.transform.parent = transform;

        }
    }

    //Wenn der PLayer die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }*/
}
