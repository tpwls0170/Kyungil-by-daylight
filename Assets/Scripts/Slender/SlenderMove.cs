using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlenderMove : MonoBehaviour
{
    private string horAxis = "Horizontal";
    private string verAxis = "Vertical";
    private string mouseY = "Mouse X";

    private Animator anim;

    private float hor;
    private float ver;
    private float rotY;

    private float defaultSphereColl;
    private float maxSphereColl;

    public Transform spineTrans;
    private CapsuleCollider sphereCollider;
    private Rigidbody rigidbody;

    public Transform testVec;

    public float moveSpeed = 8.0f;
    public float rotSpeed = 1.0f;
    public float gizmosRadius = 1.0f;
    public float jumpPower = 100.0f;

    private bool isMove;
    private bool isAttack;
    private bool isCollDown;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        sphereCollider = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

        isMove = true;
        isAttack = false;
        isCollDown = false;

        //sphereCollider.center = new Vector3(0.0f, spineTrans.position.y - 0.4f, 0.0f);

        defaultSphereColl = sphereCollider.center.y;
        maxSphereColl = 5.0f;
    }

    private void FixedUpdate()
    {
        Debug.Log(testVec.position);


        if (isMove)
        {
            hor = Input.GetAxisRaw(horAxis);
            ver = Input.GetAxisRaw(verAxis);

            transform.Translate(new Vector3(hor, 0.0f, ver).normalized * moveSpeed * Time.deltaTime);

            if (hor != 0 || ver != 0)
            {
                anim.SetBool("IsRun", true);
            }
            else if (hor == 0 && ver == 0)
            {
                anim.SetBool("IsRun", false);
            }
        }
        
        //충돌체 위치 변화
        sphereCollider.center = new Vector3(0, spineTrans.position.y - 0.4f, 0);
        
        // 회전
        rotY += Input.GetAxis(mouseY) * rotSpeed;
        transform.localRotation = Quaternion.Euler(new Vector3(0.0f, rotY, 0.0f));

        // 어택

        if (isAttack == false && Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("IsAttack");
            isAttack = true;

            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    public void IsAnimAttackCheck()
    {
        isAttack = false;
    }

    public void CollDownTrue()
    {
        isCollDown = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(0.0f, spineTrans.position.y, 0.0f), gizmosRadius);
    }
}
