using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    private PlayerInput _input;
    public Animator animator;
    private int buttonNordDurationAnimatorID;

    private int isButtonNordDown, IsButtonEastDown, IsButtonSouthDown, IsButtonWestDown;

    public  int playerId;

    void OnMovementAction(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnDPad(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnRightStick(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    public void OnButtonNord(InputAction.CallbackContext context)
    {
        Debug.Log("Trigegr");
        if (_input.user.index == playerId)
        {
            animator.SetBool(isButtonNordDown, context.ReadValueAsButton());
        }
    }
    public void OnButtonSouth(InputAction.CallbackContext context)
    {
        print("triggerbuttonsouth");
        if (_input.user.index == playerId)
        {
            animator.SetBool("isButtonSouthDown", context.ReadValueAsButton());

        }
    }
    void OnButtonWest(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnButtonEast(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnMousePosition(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnMouseRightClick(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnMouseLeftClick(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnMouseMiddleButton(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    void OnStart(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }

    void OnAny(InputAction.CallbackContext context)
    {
        if (_input.user.index == playerId)
        {
            
        }
    }
    
    public void ControlConnected(PlayerInput playerInput)
    {
        _input = playerInput;
    }
}
