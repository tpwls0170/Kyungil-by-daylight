using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    Animator anim;
    bool walk;
    PlayerInput playerInput;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;

        anim = GetComponent<Animator>();
        walk = false;

        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        Move();
        CameraRotate();
        Rotate();
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            //float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            //float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            Vector3 curSpeedX = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S))
                curSpeedX = canMove ? speed * (forward) : new Vector3(0, 0, 0);


            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            
            // moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            moveDirection = curSpeedX;//+ (right * curSpeedY);

            //if (Input.GetButton("Jump") && canMove)
            //{
            //    moveDirection.y = jumpSpeed;
            //}

            // 애니메이션
            //if (curSpeedX != 0f || curSpeedY != 0f)
            if (curSpeedX != new Vector3(0, 0, 0) || curSpeedY != 0f)
            {
                if (!walk)
                {
                    anim.SetBool("isRun", true);
                    walk = true;
                }
            }
            else
            {
                if (walk)
                {
                    anim.SetBool("isRun", false);
                    walk = false;
                }
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Rotate()
    {
     
    }

    private void CameraRotate()
    {
        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, transform.rotation.y + rotation.y);
            Vector3 temprotation = new Vector3(0,0,0);

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, -45, 0);
                temprotation = new Vector3(0, 45, 0);
               
            }

            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 45, 0);
                temprotation = new Vector3(0, -45, 0);

            }

            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 225, 0);
                temprotation = new Vector3(0, -225, 0);

            }

            else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 135, 0);
                temprotation = new Vector3(0, -135, 0);

            }

            else if (Input.GetKey(KeyCode.D))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, -90, 0);
                temprotation = new Vector3(0, 90, 0);              
            }
                      
            else if (Input.GetKey(KeyCode.A))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 90, 0);
                temprotation = new Vector3(0, -90, 0);               
            }

            else if (Input.GetKey(KeyCode.S))
            {
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 180f, 0);
                temprotation = new Vector3(0, -180f, 0);               
            }

            transform.eulerAngles = transform.eulerAngles + temprotation;

        }
    }
}
