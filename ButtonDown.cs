using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDown : MonoBehaviour {
    
    public Vector3 button;

    //Animation
     Animator anim;

    //Um zu sehen ob die Animation läuft.
    bool playAnimation =  false;
    
    // Animation hinzufügen
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();   
    }

    //Animation soll laufen wenn true sonst soll die Animation nicht laufen.
    void Update() 
    {
        if (playAnimation == true)
        {
            anim.Play("MoveButton");
        }
    }

    //Wenn auf Button Parent, Animation und die Box auftauchen lassen.
    void OnTriggerEnter( Collider col)
    {
            if (col.gameObject.tag == "Player")
                {
                col.transform.parent = gameObject.transform;
                playAnimation = true;
                FindObjectOfType<BoxActive>().Pushed(true);
            }
     }

    //Wenn Button verlassen Parent, Animation und die Box nicht mehr verwenden.
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
            playAnimation = false;
            FindObjectOfType<BoxActive>().Pushed(false);
        }       
    }   
}