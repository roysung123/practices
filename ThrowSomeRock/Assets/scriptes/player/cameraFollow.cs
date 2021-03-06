﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 70.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    private float sensitivityX = 3.0f;
    private float sensitivityY = 3.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + new Vector3(0, 2, 0) + rotation * dir;
        camTransform.LookAt(lookAt.position + new Vector3(0, 2, 0));
    }
}
