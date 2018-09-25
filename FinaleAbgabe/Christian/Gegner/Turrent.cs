using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour {

    Transform player;
    public Transform gunEnd;
    public GameObject bullet;
    public float Schussgeschwindigkeit;
    Vector3 position;
    public AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update () {
        position = player.transform.position;

        transform.LookAt(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sound.Pause();
            StopCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        sound.Play();
        while (true)
        {
            Instantiate(bullet, gunEnd.position, gunEnd.rotation);
            yield return new WaitForSeconds(Schussgeschwindigkeit);
        }
    }
}
