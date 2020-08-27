using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
<<<<<<< HEAD
    public string moveAxisName = "Vertical";
    public string rotateAxisName = "Horizontal";
    public string fireButtonName = "Fire1";
=======
    public bool interact { get; private set; }
>>>>>>> 2900294537ad35b8ebf07b6387a9fd8e23c69e0e

    public float move { get; private set; }
    public float rotate { get; private set; }
    public float fire { get; private set; }

    private void Update()
    {
        move = Input.GetAxis(moveAxisName);
        rotate = Input.GetAxis(rotateAxisName);
        fire = Input.GetAxis(fireButtonName);
    }
}
