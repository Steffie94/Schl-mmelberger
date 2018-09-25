using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeController : MonoBehaviour
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
   

    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        GetInput();
        CalculateDirection();
        CalculateForward();
        CalculateGroundAngle();
        CheckGround();
        ApplyGravity();
        DrawDebugLines();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;

        Rotate();
        Move();
    }
    //Die Eingabe basiert auf horizontalen (a, d, <,>) und vertikalen (w, s, ^, v) Tasten
    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
    //Richtung relativ zur Kameradrehung
    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }
    //In Richtung des berechneten Winkels drehen
    void Rotate()
    {
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    //Dieser Spieler bewegt sich nur entlang seiner eigenen Vorwärtsachse
    void Move()
    {
        if (groundAngle >= maxGroundAngle) return;
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
    //Wenn der Spieler nicht geerdet ist, wird Vorwärts gleich vorwärts transformiert
    //Verwenden Sie ein Kreuzprodukt, um den neuen Vorwärtsvektor zu bestimmen
    void CalculateForward()
    {
        //if (!grounded)
        if(grounded)
        {
            
            forward = transform.forward;
            return;
        }
        forward = Vector3.Cross(hitInfo.normal, -transform.right);
    }
    //Verwenden Sie einen vector3 Winkel zwischen der Grundnormalen und der Vorwärtstransformation, um die Neigung des Bodens zu bestimmen
    void CalculateGroundAngle()
    {
        //if (!grounded)
        if (grounded)
        {
            groundAngle = 90;
            return;
        }
        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }
    //Verwendet einen Raycast um die Höhen länge festzustellen, ob der Player geerdet ist oder nicht
    void CheckGround()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightPadding, ground))
        {
            if (Vector3.Distance(transform.position, hitInfo.point) < height)
            { transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height, 5 * Time.deltaTime); }
            grounded = true;
           
        }
        else
        {
            grounded = false;
        }
    }
    //wenn nicht geerdet, sollte der Spieler fallen
    void ApplyGravity()
    {
        if (!grounded)
        {
            transform.position += Physics.gravity * Time.deltaTime;
        }

    }
    //Zeichnet debug Lines um die Erdung zu prüfen
    //...für die Höhe
    //...und die Höhen Polsterung
    void DrawDebugLines()
    {
        if (!debug) return;
        Debug.DrawLine(transform.position, transform.position + forward * height * 2, Color.blue);
        Debug.DrawLine(transform.position, transform.position - Vector3.up * height, Color.green);
    }


}