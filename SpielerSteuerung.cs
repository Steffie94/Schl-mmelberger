using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerSteuerung : MonoBehaviour {

    private Vector3 bewegungsRichtung;

    public float bewegungsGeschwindigkeit;
    public float sprungKraft;
    public CharacterController controller;
    public float gravityScale;

    public Animator anim;

	// Use this for initialization
	void Start ()
    {
        //Holt sich den ChracterController
        controller = GetComponent<CharacterController>();

        //Setzt die bewegungsGeschwindigkeit des Spielers
        bewegungsGeschwindigkeit = 10.0f;

        //Setzt die sprungKraft des Spielers
        sprungKraft = 20.0f;

        gravityScale = 5.0f; 

}

// Update is called once per frame
void Update ()
    {
        //Übergibt jedes Frame einen neuen Vector3 an bewgungsRichtung. Wo bei sich die X und Z Werte ändern bei Bewegung und Y nur bei einem Sprung
        //bewegungsRichtung = new Vector3(Input.GetAxis("Horizontal") * bewegungsGeschwindigkeit, bewegungsRichtung.y, Input.GetAxis("Vertical") * bewegungsGeschwindigkeit);

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
            //Zurück setung des Y Wertes. Sonst komisch wenn man von Kanten fällt wegen der Gravitation
            bewegungsRichtung.y = 0f;

            //Überprüft ob die Sprung Taste gedrückt wird
            if (Input.GetButtonDown("Jump"))
            {
                // Der Y Wert bei der bewegungsRichtung bekommt die Sprungkraft zugewiesen
                bewegungsRichtung.y = sprungKraft;
            }

        }

        // Der Y Wert der bewegungsRichtung wird nochmal durch die Game Physics verändert
        bewegungsRichtung.y = bewegungsRichtung.y + (Physics.gravity.y * gravityScale * Time.deltaTime);

        //Spieler bewegt sich wie es die bewegungsRichtung angibt mit abhängigkeit von der Zeit
        controller.Move(bewegungsRichtung * Time.deltaTime);

        //Setzt den Wert für den Animator auf true solange der Spiele am Boden ist
        anim.SetBool("AmBoden", controller.isGrounded);
        //Erhöht den Speed Wert für den Animator
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical"))+ Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
