using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInput2 : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    private Vector3 movementInput;
    private Vector3 movementdirection;
    public Transform cameraAngle;
    private float turnSmoothVelocity;
    public float smoothTime;
    private Vector2 rotationInput;
    private Vector2 mousePositionInput;

    private InputAction action;
    public float playerSpeed = 10;
    private Vector3 moveInput;
    private Vector3 inputDirection;
    private Vector3 moveDirection;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraAngle = Camera.main.transform;

    }

     void FixedUpdate()
    {
        //animator.SetFloat("Magnitude", Mathf.Clamp01(movementInput.magnitude), 0.5f, Time.deltaTime);
        MoveRelativeToCamera();
        animator.SetFloat("Magnitude", Mathf.Clamp01(moveInput.magnitude), 0.2f, Time.deltaTime);

    }

     public void  OnMoveInput(InputAction.CallbackContext context)
     {

         moveInput = context.ReadValue<Vector2>();                                  //gather inputs
         inputDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;  
         //animator.SetFloat("Magnitude", Mathf.Clamp01(inputDirection.magnitude), 0.1f, Time.deltaTime);
         
     }

     public  void  MoveRelativeToCamera()
    {
        if (moveInput.magnitude> 0.5) // checks if there is input
        {
            float relativeAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraAngle.eulerAngles.y; // converts to angle based on input and relative to the camera 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, relativeAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);                                                                //rotates the object in the direction it is moving; it collides with analog and mouse rotation
            moveDirection = Quaternion.Euler(0f, relativeAngle, 0f) * Vector3.forward;
            //controller.Move(moveDirection * (playerSpeed * Time.deltaTime));                                                 // moves the Object
        }
    }
    
}
