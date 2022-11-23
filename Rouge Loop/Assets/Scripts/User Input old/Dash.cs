using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Dash : MonoBehaviour
{
    private CharacterController controller;

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }
    public float dashTime = 1f;
    public float dashSpeed = 10f;
    public void DoDash(InputAction.CallbackContext context)
    {
        
        if(context.ReadValueAsButton() && HelpVariables.isDashing == false){
            
        StartCoroutine(DashCoroutine());
        }
        // this function is called when the button is pressed
        // It is triggered 3 Times
        // on bool context.started
        // on bool context.performed
        // on bool context.cancelled
        //Debug.Log(context.ReadValue<float>());
        //Debug.Log(context);
        //float startTime = Time.time;
    }


    private IEnumerator DashCoroutine()
{
    float startTime = Time.time;
    while(Time.time < startTime + dashTime)
    {   HelpVariables.isDashing = true;
        HelpVariables.isInvincible = true;
        transform.position+= transform.forward * dashSpeed * Time.deltaTime;
        yield return null;
    }
    HelpVariables.isDashing = false;
    HelpVariables.isInvincible = false;
}

}
