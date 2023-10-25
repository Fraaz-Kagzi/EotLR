using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float sensitivity = 2.0f; // Mouse sensitivity for looking
    private float normalMoveSpeed;
    private CharacterController controller;
    private Animator animator;

    private bool isCrouched = false;
    private bool hasPistol = false;
    private bool isSprinting = false;

    private float rotationX = 0.0f; // Rotation around the X-axis for looking

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>(); // Assuming the Animator component is on the same GameObject as the script.
        normalMoveSpeed = moveSpeed; // Store the normal movement speed.
        
    }

    void Update()
    {
        // Mouse Input for Looking
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f); // Limit vertical rotation

        // Apply rotation to the player
        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
       
        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = transform.TransformDirection(moveDirection);

        // Check if the "Shift" key is held down to sprint.
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isSprinting = true;
            animator.SetBool("isSprinting", true);
            moveSpeed = normalMoveSpeed * 2.0f; // Double the movement speed.
        }
        else
        {
            isSprinting = false;
            animator.SetBool("isSprinting", false);
            moveSpeed = normalMoveSpeed; // Reset the movement speed to normal.
        }

        moveDirection *= moveSpeed;

        controller.Move(moveDirection * Time.deltaTime);

        // Check if the player is moving and set the "isMoving" parameter in the animator.
        if (moveDirection.magnitude > 0.1f)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        // Check if the "C" key is pressed and set the "isCrouched" parameter in the animator.
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouched = !isCrouched; // Toggle the crouch state.
            animator.SetBool("isCrouched", isCrouched);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            hasPistol = !hasPistol; // Toggle the crouch state.
            animator.SetBool("hasPistol", hasPistol);
        }
    }
}
