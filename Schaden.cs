using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schaden : MonoBehaviour {

    private Vector3 bewegungsRichtung;
    public float rueckstoß;
    public float rueckstoßZeit;
    private float rueckstoßZaehler;

    public void Rückstoß(Vector3 richtung)
    {
        rueckstoßZaehler = rueckstoßZeit;

        bewegungsRichtung = richtung * rueckstoß;

        //Ist dafür da das man aufjedenfall vom Rückstoß in die Luft geschleudert wird
        bewegungsRichtung.x = rueckstoß;

    }
}
