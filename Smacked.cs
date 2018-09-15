using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smacked : MonoBehaviour {
    public float destroyTime = 0.5f;
    public Enemy enemy;

    void Start()
    {
    }

    void OnTriggerEnter (Collider col) {

        //Wenn das Object mit Tag Player es berührt
        if (col.tag == "Player")
        {

            //Damage Script nicht mehr funktioniert, sodass man keinen Schaden mehr nimmt
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            Debug.Log("hier");
            //FindObjectOfType<Enemy>().OnEnemy(true);

            FindObjectOfType<SpielerSteuerung>().setzeSprungkraft(10);
           
        }
	}

    void OnTriggerExit(Collider col)
    {
       Destroy(transform.parent.gameObject);
    }

}
