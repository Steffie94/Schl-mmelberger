using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySnake : MonoBehaviour {

    GameObject[] snake;

    public int tails;

    void Start()
    {

        snake = new GameObject[tails];

        for (int i = 1; i < tails; i++)
        {
            snake[i] = GameObject.FindWithTag("Snake");
            snake[i].SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Player Parent setzen.
            col.transform.parent = gameObject.transform;

            for (int i = 1; i < snake.Length; i++)
            {
                Destroy(snake[i]);
            }
        }
    }

    //Wenn der PLayer die Platform wieder verlässt ist kein Kind mehr. 
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

