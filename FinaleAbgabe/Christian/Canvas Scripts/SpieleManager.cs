using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpieleManager : MonoBehaviour {

    public int momGold;
    public int momHealth = 3;
    public Text goldText;
    public Text lebenText;
    public AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddGold(int goldtoAd)
    {
        momGold += goldtoAd;
        goldText.text = "Gold:" + momGold+"";

        if(momGold > 19)
        {
            FindObjectOfType<SpielerSteuerung>().setzeSprungkraft(goldtoAd);
        }
    }

    public void AddHealth(int healthtoAd)
    {
        momHealth += healthtoAd;
        lebenText.text = "Leben: " + momHealth + "";
    }

    public void hurtHealth(int hurttoAd)
    {
        momHealth -= hurttoAd;
        lebenText.text = "Leben: " + momHealth + "";
        sound.Play();
    }
    //Gibt die momentanen Leben zurück
    public int AnzahlLeben()
    {
        return momHealth;
    }
}
