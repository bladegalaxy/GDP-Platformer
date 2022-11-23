using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    CharacterController characterController;
    Rigidbody rigidBody;

    private Vector2 moveDirection;
    private float horizontalInput;

    [SerializeField] private float horizontalMovement;
    [SerializeField] private float verticalMovement;
    [SerializeField]private float gravity = 10f;
    private float moveSpeed;
    private float jumpSpeed;
    private bool allowJump = false;
    private bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && allowJump)
        {
            jumping = true; // for future jump setting changes, different type of jumping
            jumpSpeed = 5f;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && jumping)
        {
            jumping = false;
        }
#endif

        if (characterController.isGrounded)
        {
            allowJump = true;

            if (allowJump /* for future speed changing e.g. sprint, speed boost buff */)
            {
                moveSpeed = 5f;
            }
            horizontalMovement = horizontalInput * moveSpeed;
        }
        if (jumping)
        {
            verticalMovement = jumpSpeed;
        }
        moveDirection = new Vector2(horizontalMovement, verticalMovement);
        verticalMovement -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
