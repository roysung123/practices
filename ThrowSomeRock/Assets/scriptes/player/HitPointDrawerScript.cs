using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPointDrawerScript : MonoBehaviour
{
    MeshFilter mf;
    MeshRenderer mr;
    Mesh hitpoint;
    GameObject[] tis;
    // Start is called before the first frame update
    void Start()
    {
        mf = gameObject.AddComponent<MeshFilter>();
        mr = gameObject.AddComponent<MeshRenderer>();
        hitpoint = new Mesh();
        mf.mesh = hitpoint;
        //mr.material = :
    }

    // Update is called once per frame
    void Update()
    {
        tis = GameObject.FindGameObjectsWithTag("ti");
        foreach (GameObject ti in tis)
        {
            if (ti.GetComponent<throwableitemScript>().beencarry_flag)
            {
                Debug.Log("!");
                Vector3[] ver = new Vector3[3] { new Vector3(0, 1, 0), new Vector3(1, 1, 0), new Vector3(0, 1, 1) };//ti.transform.position, ti.transform.position + Vector3.forward*5, ti.transform.position + Vector3.right*5 };
                int[] tri = new int[3] { 0, 1, 2 };
                Vector3[] nor = new Vector3[3] { Vector3.up, Vector3.up, Vector3.up };
                Vector2[] uv = new Vector2[3] { new Vector2 ( 0, 0 ), new Vector2 ( 0, 1 ), new Vector2 ( 1, 0 ) };
                hitpoint.vertices = ver;
                hitpoint.triangles = tri;
                hitpoint.normals = nor;
                hitpoint.uv = uv;
            }
            
        }
    }
}
