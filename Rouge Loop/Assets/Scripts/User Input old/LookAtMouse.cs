using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnLookAtMouse(InputAction.CallbackContext context)
    {
        //shooting lasers pew pew
        if(HelpVariables.isDashing == false){
            Ray ray = mainCamera.ScreenPointToRay(context.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
            }
        }
    }
    
}
