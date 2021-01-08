using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public Transform playerCam;

    // Update is called once per frame
    void Start()
    {
        playerCam = GameObject.Find("Main Camera").transform;
    }
    void Update()
    {
        transform.LookAt(transform.position + playerCam.forward);
        //Debug.Log(playerCam.forward);
    }
}
