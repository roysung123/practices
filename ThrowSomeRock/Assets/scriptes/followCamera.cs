using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform camera;

    // Update is called once per frame
    void Start()
    {
        camera = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + camera.forward);
        //Debug.Log(camera.forward);
    }
}
