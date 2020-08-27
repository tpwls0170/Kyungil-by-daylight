using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) == true)
        {
            anim.SetBool("isWalk", true);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            anim.SetBool("isWalk", true);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            anim.SetBool("isWalk", true);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            anim.SetBool("isWalk", true);
        }

        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            anim.SetBool("isRun", true);
        }

        if (Input.GetKey(KeyCode.Q) == true)
        {
            anim.SetBool("isInjured", true);
        }
        if (Input.GetKey(KeyCode.E) == true)
        {
            anim.SetBool("isDeath", true);
        }
    }
}
