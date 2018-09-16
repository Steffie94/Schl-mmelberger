using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemycontroller : MonoBehaviour {

    [SerializeField]

    public float lookRadius = 10f;

    public Transform target;
    NavMeshAgent agent;


	// Use this for initialization
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent = this.GetComponent<NavMeshAgent>();

            if (agent == null)
            {
                Debug.Log("Fehler" + gameObject.name);
            }
            else
            {
                SetDestination();
            }
        }
	}
	
    // Zeigt den Radius in dem er Reagiert
    private void SetDestination()
    {
        if(target != null)
        {
            Vector3 targetVector = target.transform.position;
            agent.SetDestination(targetVector);
        }
    }
}
