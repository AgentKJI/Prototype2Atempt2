using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private bool GameStarted = true;
    [SerializeField] private bool IsMoving = false;
    [SerializeField] private Vector3 moveInput;
    [SerializeField] private Vector3 moveVector;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform orientation;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField]private Transform groundCheck;    
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    // Update is called once per frame

    private void Update()
    { 
       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, whatIsGround);

        if (isGrounded && playerVelocity.y< 0)
            playerVelocity.y = -2f;

        playerVelocity.y += gravity* Time.deltaTime;
        playerVelocity.y = Mathf.Max(playerVelocity.y, -20f);

        moveVector = Vector3.zero;

        if (IsMoving)
        {
            Vector3 flatForward = new Vector3(orientation.forward.x, 0f, orientation.forward.z).normalized;
        Vector3 flatRight = new Vector3(orientation.right.x, 0f, orientation.right.z).normalized;
        moveVector = (flatRight* moveInput.x + flatForward* moveInput.z).normalized;
        }

    characterController.Move((moveVector * moveSpeed + Vector3.up * playerVelocity.y) * Time.deltaTime);
       
    }
    public void move(InputAction.CallbackContext ctx)
    {
        if (GameStarted)
        {
            if (ctx.performed)
            {
                Vector2 inputVector = ctx.ReadValue<Vector2>();
                Debug.Log("Input Vector: " + inputVector);
                moveInput = new Vector3(inputVector.x, 0, inputVector.y);
                IsMoving = true;
                //Debug.Log("IsMoving: " + IsMoving);



            }
            if (ctx.canceled)
            {
                IsMoving = false;
            }
        }

    }


}
