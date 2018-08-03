using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public ParticleSystem particles;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.GetComponent<ResetObject>().Checkpoint();
            particles.startColor = Color.green;
        }
    }
}
