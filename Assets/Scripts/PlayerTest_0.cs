using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest_0 : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public Transform cameraParent;

    private float mouseRotSpeed = 30.0f;

    float hor;
    float ver;

    float mouseAxisX;
    float mouseAxisY;


    private Vector3 vec;

    private void Start()
    {
        StartCoroutine(CameraMove());
    }

    private IEnumerator CameraMove()
    {
        while (true)
        {
            mouseAxisY += Input.GetAxis("Mouse X") * mouseRotSpeed;
            mouseAxisX += -Input.GetAxis("Mouse Y") * mouseRotSpeed;

            transform.rotation = Quaternion.Euler(0.0f, mouseAxisY, 0.0f);
            cameraParent.rotation = Quaternion.Euler(mouseAxisX, 0.0f, 0.0f);



            yield return null;
        }
    }

    private void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        vec = new Vector3(hor, 0.0f, ver).normalized;

        transform.Translate(vec * moveSpeed * Time.deltaTime);
    }
}
