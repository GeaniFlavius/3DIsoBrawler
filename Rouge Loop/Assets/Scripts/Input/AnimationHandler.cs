using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    public InputHandler inputHandler;
    private int buttonNordDurationAnimatorID,
        buttonEastDurationAnimatorID,
        buttonSouthDurationAnimatorID,
        buttonWestDurationAnimatorID;
    private int isButtonNordDown, IsButtonEastDown, IsButtonSouthDown, IsButtonWestDown;
    private int magnitude;
    private int isMoving;
    private bool canCombo;
    public bool Isinteracting { get { return animator.GetBool("isInteracting"); } }
    private Transform cameraAngle;
    private float smoothTime= 0.1f;
    private float turnSmoothVelocity;
    public void Awake()
    {
        animator = GetComponent<Animator>();
        inputHandler = GetComponent<InputHandler>();
        buttonNordDurationAnimatorID = Animator.StringToHash("buttonNordDuration");
        buttonEastDurationAnimatorID=Animator.StringToHash("buttonEastDuration");
        buttonSouthDurationAnimatorID=Animator.StringToHash("buttonSouthDuration");
        buttonWestDurationAnimatorID= Animator.StringToHash("buttonWestDuration");
        
        isButtonNordDown=Animator.StringToHash("isButtonNordDown");
        IsButtonEastDown =Animator.StringToHash("isButtonEastDown");
        IsButtonSouthDown=Animator.StringToHash("isButtonSouthDown");
        IsButtonWestDown =Animator.StringToHash("isButtonWestDown");
        
        magnitude= Animator.StringToHash("magnitude");
        isMoving = Animator.StringToHash("isMoving");

        cameraAngle = Camera.main.transform;
        
        #region Subscribtions to Action.started

         inputHandler.MovementInputAction.started += context =>
         {
         };

         inputHandler.ButtonNordAction.started += context => animator.SetBool(isButtonNordDown, context.ReadValueAsButton());

        inputHandler.ButtonEastAction.started += context =>
        {
            animator.SetBool(IsButtonEastDown, context.ReadValueAsButton());
        };

        inputHandler.ButtonSouthAction.started += context =>
        {
            animator.SetBool(IsButtonSouthDown, context.ReadValueAsButton());
        };

        inputHandler.ButtonWestAction.started += context =>
        {
            animator.SetBool(IsButtonWestDown, context.ReadValueAsButton());
        };
        #endregion

        #region Subscribtions to Action.performed
        inputHandler.MovementInputAction.performed += context =>
        {
            
        };
        
        inputHandler.ButtonNordAction.performed += context =>
        {

        };
        
        inputHandler.ButtonEastAction.performed += context =>
        {
        };
        
        inputHandler.ButtonSouthAction.performed += context =>
        {
        };
        
        inputHandler.ButtonWestAction.performed += context =>
        {
        };
        #endregion

        #region Subscribtions to Action.canceled
        
        inputHandler.MovementInputAction.canceled += context =>
        {

        };
        
        inputHandler.ButtonNordAction.canceled += context =>
        {
            animator.SetBool(isButtonNordDown, context.ReadValueAsButton());
            animator.SetFloat(buttonNordDurationAnimatorID, (float)inputHandler.DurationButtonNord);
        };

        inputHandler.ButtonEastAction.canceled += context =>
        {
            animator.SetBool(IsButtonEastDown, context.ReadValueAsButton());
            animator.SetFloat(buttonEastDurationAnimatorID, (float)inputHandler.DurationButtonEast);
        };

        inputHandler.ButtonSouthAction.canceled += context =>
        {
            animator.SetBool(IsButtonSouthDown, context.ReadValueAsButton());
            animator.SetFloat(buttonSouthDurationAnimatorID, (float)inputHandler.DurationButtonSouth);
        };

        inputHandler.ButtonWestAction.canceled += context => 
        {
        animator.SetBool(IsButtonWestDown, context.ReadValueAsButton());
        animator.SetFloat(buttonWestDurationAnimatorID, (float)inputHandler.DurationButtonWest);
        };
        #endregion

    }
    private void OnEnable()
    {

    }

    public void Update()
    {
        UpdateButtonDurationValues();

    }

    private void FixedUpdate()
    {
        UpdateMovementValues();
        DoRotationRalativeCamera();
    }

    void UpdateButtonDurationValues()
    {
        if (inputHandler.IsButtonNordDown) animator.SetFloat(buttonNordDurationAnimatorID,(float)inputHandler.DurationButtonNord);
        if (inputHandler.IsButtonEastDown) animator.SetFloat(buttonEastDurationAnimatorID,(float)inputHandler.DurationButtonEast);
        if (inputHandler.IsButtonSouthDown)animator.SetFloat(buttonSouthDurationAnimatorID,(float)inputHandler.DurationButtonSouth);
        if (inputHandler.IsButtonWestDown) animator.SetFloat(buttonWestDurationAnimatorID,(float)inputHandler.DurationButtonWest);
    }

    void UpdateMovementValues()
    {
        //print("update");
        animator.SetFloat(magnitude, Mathf.Clamp01(inputHandler.MovementInput.magnitude), 0.2f, Time.deltaTime);
        if (animator.GetBool("isInteracting")) return;
        if (inputHandler.MovementInput.magnitude > 0.2f) { animator.SetBool(isMoving, true);}
        else animator.SetBool(isMoving, false);
       
        
    }
    
    public  void  DoRotationRalativeCamera()
    {
        if (inputHandler.MovementInput.magnitude < 0.2f) return;
        if (animator.GetBool("isInteracting")) { Rotate(smoothTime+0.4f); return; }
        Rotate(smoothTime);
    }

    private void Rotate(float smooth)
    {
        float relativeAngle = Mathf.Atan2(inputHandler.MovementInput.x, inputHandler.MovementInput.y) * Mathf.Rad2Deg + cameraAngle.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, relativeAngle, ref turnSmoothVelocity, smooth);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
    void CanComboEnable() { animator.SetBool("canCombo", true); }
    void CanComboDisable() { animator.SetBool("canCombo", false); }
    
    void PlayTargetAnimation(String targetAnimation, bool isInteracting)
    { //Should root motion be applied?
        animator.applyRootMotion = isInteracting;
        animator.SetBool("isInteracting", isInteracting);
        animator.CrossFade(targetAnimation, 0.2f);
    }
}
