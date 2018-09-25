using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Schweinchen : MonoBehaviour {
   
    private GameObject schweinkopf;
    private GameObject schwein;
    private GameObject auge;
    private GameObject sw;
    private GameObject pig;

    // Use this for initialization
    void Start (){
        
        Creater();
        
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            DestroyObject();
        }
	}

    void Creater()
    {
        sw = GameObject.Find("Schwein");
        pig = GameObject.Find("Pig");

        //Schweine Kopf & Körper
        schweinkopf =GameObject.CreatePrimitive(PrimitiveType.Cube);
        schweinkopf.name = "Körper";
        //Material
        schweinkopf.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f);
        schweinkopf.transform.parent = sw.transform;
        
       
        

        //Beide Augen
        auge = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        auge.name = "AugeL";
        auge.GetComponent<Renderer>().material.color = new Color(0f,0f,0f); // Material
        auge.transform.Translate(0.256f, 0.172f, 0.457f);//Position
        auge.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);//Form & Größe
        auge.transform.parent = schweinkopf.transform;
        

        auge = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        auge.name = "AugeR";
        auge.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f); // Material
        auge.transform.Translate(-0.233f, 0.172f, 0.457f);//Position
        auge.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);//Form & Größe
        auge.transform.parent = schweinkopf.transform;
        
        //Nase
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "Nase";
        schwein.transform.Translate(0.012f, -0.097f, 0.503f);//Position
        schwein.transform.localScale = new Vector3(0.35f,0.35f,0.35f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
        
        //Nasenloch
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "NLochR";
        schwein.transform.Translate(-0.055f, -0.097f, 0.676f);//Position
        schwein.transform.localScale = new Vector3(0.05f, 0.19f, 0.03f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f); // Material
        schwein.transform.parent = schweinkopf.transform;
        
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "NLochL";
        schwein.transform.Translate(0.095f, -0.097f, 0.676f);//Position
        schwein.transform.localScale = new Vector3(0.05f, 0.19f, 0.03f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f); // Material
        schwein.transform.parent = schweinkopf.transform;
       
        //Beine
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "BeinVL";
        schwein.transform.Translate(0.314f, -0.541f, -0.265f);//Position
        schwein.transform.localScale = new Vector3(0.12f,0.1f, 0.18f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
       
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "BeinVR";
        schwein.transform.Translate(0.314f, -0.541f, 0.286f);//Position
        schwein.transform.localScale = new Vector3(0.12f, 0.1f, 0.18f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
       
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "BeinHR";
        schwein.transform.Translate(-0.298f, -0.541f, 0.265f);//Position
        schwein.transform.localScale = new Vector3(0.12f, 0.1f, 0.18f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
        
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "BeinHL";
        schwein.transform.Translate(-0.298f, -0.541f, -0.286f);//Position
        schwein.transform.localScale = new Vector3(0.12f, 0.1f, 0.18f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.71f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
       
        //Ohr
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "OhrL";
        schwein.transform.Translate(0.42f,0.019f,-0.015f);//Position
        schwein.transform.localScale = new Vector3(0.65f, 0.67f, 0.65f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.Rotate(-29.06f, 90f, -0.351f);// Rotation
        schwein.transform.parent = schweinkopf.transform;
        
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "OhrR";
        schwein.transform.Translate(-0.42f,0.019f,-0.015f);//Position
        schwein.transform.localScale = new Vector3(0.65f, 0.67f, 0.65f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.Rotate(29.06f, 90f, 0.351f);// Rotation
        schwein.transform.parent = schweinkopf.transform;
       
        //Tail
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "Tail1";
        schwein.transform.Translate(-0.018f,-0.304f, -0.527f);//Position
        schwein.transform.localScale = new Vector3(0.075f,0.06f,0.065f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
       
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "Tail2";
        schwein.transform.Translate(-0.002f,-0.304f,-0.595f);//Position
        schwein.transform.localScale = new Vector3(0.107f,0.059f,0.075f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
        
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "Tail3";
        schwein.transform.Translate(0.087f,-0.245f,-0.594f);//Position
        schwein.transform.Rotate(90,0,0);// Rotation
        schwein.transform.localScale = new Vector3(0.075f,0.076f,0.178f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
        
        schwein = GameObject.CreatePrimitive(PrimitiveType.Cube);
        schwein.name = "Tail4";
        schwein.transform.Translate(0.039f,-0.13f,-0.594f);//Position
        schwein.transform.localScale = new Vector3(0.171f, 0.06f, 0.075f);//Form & Größe
        schwein.GetComponent<Renderer>().material.color = new Color(1f, 0.64f, 0.65f); // Material
        schwein.transform.parent = schweinkopf.transform;
        sw.transform.parent = this.transform;
        sw.transform.position = new Vector3(0,0,0);
        schweinkopf.transform.position = new Vector3(0, 0, 0);
    }

    void DestroyObject()
    {
        Destroy(schwein);
    }


}
