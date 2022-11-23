using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonExample : MonoBehaviour
{
    // Requierments:
    // Player Input Component
    // This Script
    // A public Method with (InputAction.CallbackContext);
    // An Invocation of said method in Unity
    
    // How to Invoke
    // Go to Player Input Component
    // Go to Events
    // Go to User Actions
    // Go to the Button of your choice
    // Add to the list by pressing the plus
    // Drag and drop this script to the Object field
    // Click on Function and choose this script and this Method
    
    public void OnAction(InputAction.CallbackContext context)
    {
        // this function is called when the button is pressed
        // It is triggered 3 Times
        // on bool context.started
        // on bool context.performed
        // on bool context.cancelled
        //Debug.Log(context.ReadValue<float>());
        //Debug.Log(context);
        //float startTime = Time.time;
    }
}
