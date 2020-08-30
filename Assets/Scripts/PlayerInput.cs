using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string verticalAxisName = "Vertical";
    public string horizontalAxisName = "Horizontal";
    public string jumpButtonName = "Jump";
    public string interatButtonName = "Interact";
    public string cameraRotationXName = "Mouse X";
    public string cameraRotationYName = "Mouse Y";

    public float moveHorizontal { get; private set; }
    public float moveVertical { get; private set; }
    public bool jump { get; private set; }
    public float interact { get; private set; }
    public float cameraRotationX { get; private set; }
    public float cameraRotationY { get; private set; }

    private void Update()
    {
        moveHorizontal = Input.GetAxis(verticalAxisName);
        moveVertical = Input.GetAxis(horizontalAxisName);
        jump = Input.GetButton(jumpButtonName);
        interact = Input.GetAxis(interatButtonName);
        cameraRotationX = Input.GetAxis(cameraRotationXName);
        cameraRotationY = -Input.GetAxis(cameraRotationYName);
    }
}
