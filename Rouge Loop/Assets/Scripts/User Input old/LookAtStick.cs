using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class LookAtStick : MonoBehaviour
{
    private float xRotation;
    private float yRotation;
    
    public void OnLookAtStick(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        if (Mathf.Abs(input.x) > 0.3f || Mathf.Abs(input.y) > 0.3f)
        {
            Vector3 playerDirection = Vector3.right * input.x +Vector3.forward * input.y;
            if (playerDirection.sqrMagnitude > 0.2f)
            {
                float lookDirectionAngle = (Mathf.Rad2Deg * Mathf.Atan2(input.y, input.x))*-1;
                Quaternion rotation = Quaternion.Euler(transform.rotation.x, lookDirectionAngle, transform.rotation.z);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 180 *Time.deltaTime);
            }
        }
    }
}
