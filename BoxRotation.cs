using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRotation : MonoBehaviour {
    
    public float speed = 10f;
    public bool status;
    public float time = 2f;
    
    //Generates number between 1 & 2
    int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(0, 3);

        if (randomNumber > 1)
        {

            status = true;
        }
        else
        {
            status = false;
        }
    }

    void Update()
    {
        if (status)
        {
            //Left
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        { //Left
            transform.rotation = Quaternion.Euler (0f, -90f, 0f);
        }
    }
}
