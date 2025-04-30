using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public float rotationSpeed = 8f;

    void Update()
    {
        RotateCamera();
    //    ZoomCamera();
    }

    private void RotateCamera()
    {
        if (Input.GetMouseButton(1))
            {          
                float xRotation = rotationSpeed * Input.GetAxis("Mouse X");
                float yRotation = rotationSpeed * Input.GetAxis("Mouse Y");
                float xAngle = transform.eulerAngles.x%360f;
                float newAngle = ((xAngle + yRotation));
                    
                if (Math.Cos(newAngle/360)<=0f)
                    yRotation = 0;
                
               var angle = new Vector3(transform.eulerAngles.x + yRotation, transform.eulerAngles.y + xRotation, 0);
                transform.SetPositionAndRotation(transform.position,Quaternion.Euler(angle.x,angle.y,0));
            }
    }

    void ZoomCamera()
    {
        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollFactor != 0)
        {
            transform.localScale = transform.localScale * (1f - scrollFactor);
        }
    }
}
