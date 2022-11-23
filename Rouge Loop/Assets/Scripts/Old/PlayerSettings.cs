using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public float gravity = -250.0f;
    Vector3 velocity;
    private CharacterController controller;

    // Start is called before the first frame update
    void Awake()
    {
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // What?
        
        velocity.y += gravity * Time.deltaTime;
        Physics.SyncTransforms();
        controller.Move(velocity*Time.deltaTime);
        
    }
}
