using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderCamera : MonoBehaviour
{
    public Transform headTransform;
    
    public float rotSpeed = 1.0f;
    
    private string mouseX = "Mouse Y";
    private float rotX = 0.0f;

    private float maxRotClamp = 50.0f;
    private float minRotClamp = -30.0f;

    private void Update()
    {
        transform.position = headTransform.position + transform.forward * 0.3f;

        //Debug.Log(transform.localPosition + ", " + headTransform.localPosition);
        
        rotX += -Input.GetAxis(mouseX) * rotSpeed;

        rotX = Mathf.Clamp(rotX, minRotClamp, maxRotClamp);

        //transform.localEulerAngles = new Vector3(rot, 0.0f, 0.0f);
        //transform.Rotate(new Vector3(rot, 0.0f, 0.0f));
        transform.localRotation = Quaternion.Euler(new Vector3(rotX, 0.0f, 0.0f));

    }


}
