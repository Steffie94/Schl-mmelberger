using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class MovingEnemy : MonoBehaviour {

    public Vector3 punktA;
    public Vector3 punktB;
    public Vector3 speed = new Vector3(3,0,0);

    //Distance die der Enemy horizontal sich beweget
    public Vector3 moveDistance = new Vector3(6, 0, 0);
 
    //Enemy geschwindigkeit - default : immer an
    public int direction = 1;
    // 1 nach rechts -1 nach links bewegen

    // Damit der Enemy auch in die richtige Richtung schaut
    public Quaternion lookLeft = Quaternion.Euler(0,0,0);
    public Quaternion lookRight = Quaternion.Euler(0, 180, 0);

    void Start()
    {
        punktA = this.GetComponent<Rigidbody>().position;
        punktB = punktA + moveDistance;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
		if(GetComponent<Rigidbody>().position.x >= punktB.x && direction == 1)
        {
            direction = -direction;
            transform.rotation = lookRight;
        }
        else if(GetComponent<Rigidbody>().position.x < punktA.x && direction == -1)
        {
            direction = -direction;
            transform.rotation = lookLeft;
        }

        this.GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * speed) * Time.deltaTime);
	}
}
