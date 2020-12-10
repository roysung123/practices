using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class playerMove : MonoBehaviour
{
    public Transform CameraLook;
    public Rigidbody rb;
    public GameObject nestitem;

    private float movedir = 0;
    private float movesp = 5;
    private float jumpsp = 5;
    private float turnsp = 10;
    private float vm = 0;
    private float hm = 0;
    private float[,] dirArray = new float[,] { { -135, 180, 135 }, { -90, -1, 90 }, { -45, 0, 45 } };
    //private nearest_item ni;
    bool inAir()
    {
        RaycastHit h;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out h, 0.7f))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vm = Input.GetAxis("Vertical");
        hm = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                hm = 0;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                vm = 0;
            }
        }
        float ms = Math.Max(0,Math.Min(Math.Abs(vm)+Math.Abs(hm),1)) * movesp * Time.deltaTime;
        movedir = dirArray[Math.Sign(vm) + 1, Math.Sign(hm) + 1];
        if (Input.GetKeyDown(KeyCode.Space) && !inAir())
        {
            rb.AddForce(0, jumpsp, 0, ForceMode.VelocityChange);
        }
        transform.Translate(0, 0, ms);
        //ni = GetComponent<nearest_item>();
        //nestitem = ni.FindClosestEnemy(transform.position, GameObject.FindGameObjectsWithTag("ti"));
        //Debug.Log(nestitem + "|" + vm + "|" + hm);
    }

    void LateUpdate()
    {
        Vector3 Cz = new Vector3(CameraLook.forward.x, 0, CameraLook.forward.z);
        float Cangle = Vector3.SignedAngle(transform.forward, Cz, Vector3.up);
        if (movedir!=-1)
        {
            if (Cangle + movedir > 180)
            {
                transform.Rotate(0, (Cangle + movedir - 360) * turnsp * Time.deltaTime, 0);
            }
            else if (Cangle + movedir < -180)
            {
                transform.Rotate(0, (360 + Cangle + movedir) * turnsp * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, (Cangle + movedir) * turnsp * Time.deltaTime, 0);
            }
        }
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position,0.5f, transform.TransformDirection(Vector3.forward), 3).OrderBy(h => h.distance).ToArray();
        if (hits.Length > 2)
        {
            Debug.DrawLine(transform.position, hits[2].transform.position, Color.red, 0.1f, true);
            nestitem = hits[2].transform.gameObject;
            Debug.Log(nestitem.ToString());
        }
        else
        {
            nestitem = null;
        }
        //Debug.Log(nestitem);
    }
}
