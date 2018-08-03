using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pyramide : MonoBehaviour {

    public Vector3 vertLeftFront = new Vector3(-1,1,1);
    public Vector3 vertRightFront = new Vector3(1,1,1);
    public Vector3 vertRightBack = new Vector3(1,1,-1);
    public Vector3 vertLeftBack = new Vector3(-1,1,-1);

    private readonly float waitN = 3f;
    private readonly float waitD = 3f;
    public int shapeN = 0;

    // Use this for initialization
    void Start () {
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = mf.mesh;

        //Vertices
        Vector3[] vertices = new Vector3[]
        {
            //Vorderseite
            vertLeftFront, //linke vordere Front,0
            vertRightFront,//rechte vordere Front,1
            new Vector3(-1,-1,1),//linke hintere front,2
            new Vector3(1,-1,1),//rechte hintere front,3

            //Rückseite
             vertRightBack,
             vertLeftBack,
             new Vector3(1,-1,-1),
             new Vector3(-1,-1,-1),

             //Linkeseite
             vertLeftBack,
             vertLeftFront,
             new Vector3(-1,-1,-1),
             new Vector3(-1,-1,1),

             //Rechteseite
             vertRightFront,
             vertRightBack,
             new Vector3(1,-1,1),
             new Vector3(1,-1,-1),

             //Obereseite (Deckel)
             vertLeftBack,
             vertRightBack,
             vertLeftFront,
             vertRightFront,

             //Untereseite (Grund)
             new Vector3(-1,-1,1),
             new Vector3(1,-1,1),
             new Vector3(-1,-1,-1),
             new Vector3(1,-1,-1),
        };

        // Dreieck
        int[] triangles = new int[]
         {
             //Vorderseite
             0,2,3, //erstes triangles
             3,1,0, //zweites triangles

              //Rückseite
             4,6,7, //drittes triangles
             7,5,4, //viertes triangles

              //Linkeseite
             8,10,11, //fünftes triangles
             11,9,8, //sechstes triangles

              //Rechteseite
             12,14,15, //siebtes triangles
             15,13,12, //achtes triangles

              //Obereseite (Deckel)
             16,18,19, //neuntes triangles
             19,17,16, //zehntes triangles

              //Untereseite (Grund)
             20,22,23, //elftes triangles
             23,21,20 //zwelftes triangles
         };

        //UVs
        Vector2[] uvs = new Vector2[]
        {
            //Vorderseite
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            //Rückseite
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            //Linkeseite
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            //Rechteseite
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            //Obereseite (Deckel)
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0),

            //Untereseite (Grund)
            new Vector2(0,1),
            new Vector2(0,0),
            new Vector2(1,1),
            new Vector2(1,0)
        };

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        MeshUtility.Optimize(mesh);
        mesh.RecalculateNormals();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
