using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TransformPosition : MonoBehaviour
{
    private Vector3 moveInput;
    public Transform cameraAngle;
    private float turnSmoothVelocity;
    public float smoothTime;
    private Vector3 inputDirection;
    private Vector3 moveDirection;
    private Animator animator;


    
    private void Start()
    {
        cameraAngle = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MoveRelativeToCamera();

    }

    public void  OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        inputDirection = new Vector3(moveInput.x, 0f, moveInput.y);
    }

    public  void  MoveRelativeToCamera()
    {
        if (inputDirection.magnitude > 0.2)
        {
            float relativeAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraAngle.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, relativeAngle, ref turnSmoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            animator.SetFloat("Magnitude", moveInput.magnitude, 0.2f, Time.deltaTime);
        }
    }
    
    
}
