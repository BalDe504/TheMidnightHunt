using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode leftLook = KeyCode.Q;
    public KeyCode rightLook = KeyCode.E;

    public KeyCode Exit = KeyCode.Escape;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    bool lookingBackward;

    Rigidbody rb;

    public MovementState state;

    public AudioSource footstepsWalk;
    public AudioSource footstepsSprint;

    public enum MovementState
    {
        walking,
        sprinting,
        air
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();
        QuitGame();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if(state == MovementState.walking)
        {
            footstepsSprint.enabled = false;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                footstepsWalk.enabled = true;
            }
            else
            {
                footstepsWalk.enabled = false;
            }
        }
        else if (state == MovementState.sprinting)
        {
            footstepsWalk.enabled = false;
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                footstepsSprint.enabled = true;
            }
            else
            {
                footstepsSprint.enabled = false;
            }
        }
        



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void StateHandler()
    {
        if(Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        else
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
    }

    private void MovePlayer()
    {
        if (Input.GetKey(leftLook) || Input.GetKey(rightLook))
        {
            lookingBackward = true;
        }
        else
        {
            lookingBackward = false;
        }

        if (lookingBackward)
        {
            moveDirection = -orientation.forward * verticalInput + (-orientation.right * horizontalInput);

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    public void QuitGame()
    {
        if(Input.GetKeyDown(Exit))
        {
            Application.Quit();
        }
        
    }
}
