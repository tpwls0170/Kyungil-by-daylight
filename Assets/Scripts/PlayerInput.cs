using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool interact { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {
        interact = Input.GetMouseButtonDown(0);
    }
}
