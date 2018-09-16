using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leben : MonoBehaviour {

    public int maxLeben;
    public int momLeben;

    public SpielerSteuerung derSpieler;

    public float unverwundbarkeitsDauer;
    public float unverwundbarkeitZaehler;

    //Hilfe um auf den Renderer des Spielers zuzugreifen
    public Renderer spielerRenderer;
    private float flashZaehler;
    private float flashDauer = 0.1f;

    private bool istRespawnt;
    private Vector3 respawnPunkt;
    public float respawnDauer;

    public GameObject respawnEffect;

    // Use this for initialization
    void Start ()
    {
        unverwundbarkeitsDauer = 1.0f;
        respawnDauer = 1.0f;
        momLeben = maxLeben;
        derSpieler = FindObjectOfType<SpielerSteuerung>();

        //Der Punkt ist immer dort wo der Spieler ´gerade ist
        respawnPunkt = derSpieler.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Wenn man unverwundbar ist
		if(unverwundbarkeitZaehler > 0)
        {
            unverwundbarkeitZaehler -= Time.unscaledDeltaTime;
            flashZaehler -= Time.unscaledDeltaTime;

            //Lässt den Spieler Blinken
            if(flashZaehler <= 0)
            {
                spielerRenderer.enabled = !spielerRenderer.enabled;
                flashZaehler = flashDauer;
            }

            //Sorgt dafür das am ende der Spieler aufjedenfall sichtbar ist
            if(unverwundbarkeitZaehler <= 0)
            {
                spielerRenderer.enabled = true;
            }
        }
	}

    public void schadenSpieler(int schaden, Vector3 richtung)
    {
        //Wenn man nicht unverwundbar ist
        if (unverwundbarkeitZaehler <= 0)
        {
            momLeben -= schaden;
            FindObjectOfType<SpieleManager>().hurtHealth(schaden);
            if (momLeben <= 0)
            {
                Respawn();
            }
            else
            { 
                derSpieler.Rückstoß(richtung);
                unverwundbarkeitZaehler = unverwundbarkeitsDauer;

                //Sorgt dafür das der Spieler nicht mehr sichtbar ist
                spielerRenderer.enabled = false;

                flashZaehler = flashDauer;
            }
        }

    }

    public void Respawn ()
    {
        if(!istRespawnt)
        {
            StartCoroutine("RespawnCo");
        }
        
    }

    public IEnumerator RespawnCo()
    {
        istRespawnt = true;
        derSpieler.gameObject.SetActive(false);
        Instantiate(respawnEffect, derSpieler.transform.position, derSpieler.transform.rotation);
        yield return new WaitForSeconds(respawnDauer);
        istRespawnt = false;
        derSpieler.gameObject.SetActive(true);
        derSpieler.transform.position = respawnPunkt;
        momLeben = maxLeben;
        FindObjectOfType<SpieleManager>().AddHealth(maxLeben);


        unverwundbarkeitZaehler = unverwundbarkeitsDauer;
        //Sorgt dafür das der Spieler nicht mehr sichtbar ist
        spielerRenderer.enabled = false;

        flashZaehler = flashDauer;
    }

    public void heileSpieler (int heilung)
    {
        momLeben += heilung;

        //Verhindert das man mehr Leben als Maximal haben kann
        if(momLeben > maxLeben)
        {
            momLeben = maxLeben;
        }

    }
}
