using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerSteuerung : MonoBehaviour {

    private Vector3 bewegungsRichtung;

    public CharacterController controller;
    public float bewegungsGeschwindigkeit;
    public float sprungKraft;
    public float rotationsGeschwindigkeit;
    public float gravityScale;
    public float rueckstoß;
    public float rueckstoßZeit;
    private float rueckstoßZaehler;
    public bool springen = false;
    public Animator anim;
    public TimeSlow timeslow;

    //Ein Gameobject das man nicht sehen kann und sich immer beim Spieler befindet. Es ist eine Hilfe um die Kamera zu bedienen
    public GameObject pivot;
    public GameObject spielerModel;
    //Cooldown
    private float cooldownZeit = 3;
    private float nutzZeit = 0;

    public AudioSource sprung;

    // Use this for initialization
    void Start ()
    {
        //Holt sich den ChracterController
        controller = GetComponent<CharacterController>();
        timeslow = GetComponent<TimeSlow>();
        pivot = GameObject.Find("Pivot");

        //Setzt die bewegungsGeschwindigkeit des Spielers
        bewegungsGeschwindigkeit = 10.0f;

        //Setzt die sprungKraft des Spielers
        sprungKraft = 19.0f;

        gravityScale = 5.0f;

        rueckstoß = 15.0f;

        rueckstoßZeit = 0.5f;

}

// Update is called once per frame
void Update ()
    {
        if (Time.time > nutzZeit)
        {
            if (Input.GetButtonDown("z"))
            {
                timeslow.BulletTime();
                nutzZeit = Time.time + cooldownZeit;
            }
        }

        //Wenn der Spieler nicht zurück gestoßen wird
        if (rueckstoßZaehler <= 0)
        {
            //Speichert den Wert von bewegungsRichtung auf der Y Achse
            float yStore = bewegungsRichtung.y;

            //Lässt den Spieler in beide Richtungen gleichzeitig laufen transform.forward * Input.GetAxis("Vertical")) + 
            bewegungsRichtung = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"));

            //Verhindert das man schneller wird wenn man beide Knöpfe gleichzeitig drückt
            bewegungsRichtung = bewegungsRichtung.normalized * bewegungsGeschwindigkeit;

            //Setzt den Wert wieder zurück
            bewegungsRichtung.y = yStore;

            //Überprüft ob der Spieler auf dem Boden ist
            if (controller.isGrounded)
            {
                springen = false;
                //Zurück setung des Y Wertes. Sonst komisch wenn man von Kanten fällt wegen der Gravitation
                bewegungsRichtung.y = 0f;

                //Überprüft ob die Sprung Taste gedrückt wird
                if (Input.GetButtonDown("Jump"))
                {
                  // Der Y Wert bei der bewegungsRichtung bekommt die Sprungkraft zugewiesen
                  bewegungsRichtung.y = sprungKraft;
                  sprung.Play();
                }
            }
        }
        else
        {
            //Der Zähler wird verringert sich nach der Zeit
            rueckstoßZaehler -= Time.unscaledDeltaTime;
        }

            // Der Y Wert der bewegungsRichtung wird nochmal durch die Game Physics verändert
            bewegungsRichtung.y = bewegungsRichtung.y + (Physics.gravity.y * gravityScale * Time.unscaledDeltaTime);

            //Spieler bewegt sich wie es die bewegungsRichtung angibt mit abhängigkeit von der Zeit
            controller.Move(bewegungsRichtung * Time.unscaledDeltaTime);

            //Bewegt den Spieler in Verschiedene Richtungen basierend darauf in welche Richtung die Kamera schaut
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, pivot.transform.rotation.eulerAngles.y, 0f);
                Quaternion neueRotation = Quaternion.LookRotation(new Vector3(bewegungsRichtung.x, 0f, bewegungsRichtung.z));
                //Slerp für die Richtige Rotations bewegung
                spielerModel.transform.rotation = Quaternion.Slerp(spielerModel.transform.rotation, neueRotation, rotationsGeschwindigkeit * Time.unscaledDeltaTime);
            }

            //Setzt den Wert für den Animator auf true solange der Spiele am Boden ist
            anim.SetBool("AmBoden", controller.isGrounded);
            //Erhöht den Speed Wert für den Animator
            anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
        
    }

    //Pro 10 Gold springt der Spieler etwas höher
    public void setzeSprungkraft(int momGold)
    {
        sprungKraft = 20.0f + (1 *(momGold % 20));
    }

    public void Rückstoß (Vector3 richtung)
    {
        rueckstoßZaehler = rueckstoßZeit;

        bewegungsRichtung = richtung * rueckstoß;

        //Ist dafür da das man aufjedenfall vom Rückstoß in die Luft geschleudert wird
        bewegungsRichtung.y = rueckstoß;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
            if (!controller.isGrounded && hit.normal.y < 0.1f)
            {
                if (Input.GetButtonDown("Jump") && springen == false)
                {
                    bewegungsRichtung.y = sprungKraft;
                    //bewegungsRichtung = hit.normal * bewegungsGeschwindigkeit;
                    springen = true;
                }
            }
    }

    public void BounceOnCommand (int bounce)
    {
        bewegungsRichtung.y = bounce;
    }
}
