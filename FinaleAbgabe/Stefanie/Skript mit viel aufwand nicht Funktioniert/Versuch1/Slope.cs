using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    public float velocity = 5;
    public float turnSpeed = 10;
    public float height = 0.5f;
    public float heightPadding = 0.05f;
    public LayerMask ground;
    public float maxGroundAngle = 120;
    public bool debug;
    Vector2 input;
    float angle;
    float groundAngle;
    Quaternion tragetRotation;
    Transform cam;
    Vector3 forward;
    RaycastHit hitInfo;
    bool grounded;
    public Animator anim;
    public SpielerSteuerung spieler;
    /*private float slopeThreshold;
    private float steepSlopeAngle;
    private float slopeRayHeight;
    Vector3 wunschGeschwindigkeit;
    public Transform player;
    private CharacterController controller;
    private SphereCollider collider;*/

    // Use this for initialization
    void Start()
    {

       // controller = GetComponent<CharacterController>();
        //wunschGeschwindigkeit.Set(wunschGeschwindigkeit.x, controller.velocity.y, wunschGeschwindigkeit.z);
    }

    // Update is called once per frame
    void Update()
    {/*
        //filtere das y aus, so dass es nur vorwärts prüft ... könnte sonst mit dem Kosinus unordentlich werden.
        if (checkMoveableTerrain(player.position, new Vector3(wunschGeschwindigkeit.x, 0, wunschGeschwindigkeit.z), 10f))
        {
            //controller.velocity= wunschGeschwindigkeit;
            controller.velocity.Set(wunschGeschwindigkeit.x, wunschGeschwindigkeit.y, wunschGeschwindigkeit.z);
        }*/
    }


   /* bool checkMoveableTerrain(Vector3 position, Vector3 desiredDirection, float distance)
    {
        // Wirf einen Ray von der Position unseres gameObject in unsere gewünschte Richtung. 
        //Fügen Sie dem Parameter Y den Parameter slopeRayHeight hinzu.
        Ray myRay = new Ray(position, desiredDirection);

        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, distance))
        {
            if (hit.collider.gameObject.tag == "Ground") // Unser Ray ist auf den Boden gefallen
            {
                // Hier erhalten wir den Winkel zwischen dem Up-Vektor und der Normalen der Wand, 
                //gegen die wir suchen: 90 für gerade Wände, 0 für ebenen Boden.
                float slopeAngle = Mathf.Deg2Rad * Vector3.Angle(Vector3.up, hit.normal);
                // slopeRayHeight ist der Y-Versatz vom Boden, aus dem du deinen Strahl werfen möchtest.
                float radius = Mathf.Abs(slopeRayHeight / Mathf.Sin(slopeAngle));
                float steepSlopeAngle = 45;
                if (slopeAngle >= steepSlopeAngle * Mathf.Deg2Rad) // Sie können "steepSlopeAngle" auf einen beliebigen Winkel einstellen.
                {
                    float slopeThreshold = 0.01f; 
                    // Magischer Kosinus. So erfahren wir, wie nahe wir dem Hang sind, wenn wir am Hang stehen. Wenn wir aus der Mitte des Colliders werfen, müssen wir den Kolliderradius entfernen.
                    // Der slopeThreshold hilft, einige Fehler zu beseitigen. (z. B. Kosinus ist 0 bei 90 ° -Wänden) 0,01 war eine gute Zahl für mich hier
                    if (hit.distance - collider.radius > Mathf.Abs(Mathf.Cos(slopeAngle) * radius) + slopeThreshold)
                    {
                        return true; // true zurück, wenn wir noch weit vom Hang entfernt sind
                    }

                    return false; // false zurückgeben, wenn wir sehr nah sind / auf der Piste && die Steigung ist steil
                }

                return true; // true zurück, wenn die Steigung nicht steil ist

            }
        }
        return true;
    }*/
}
