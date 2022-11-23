using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float animationAmplitude;
    public float animationSpeed;
    private Quaternion startingPos;

    private void Start()
    {
        startingPos = transform.rotation;
    }
    
    private void Update() 
    {
        YRotation();
    }


    void YRotation()
    {
        Quaternion transformedPos = startingPos;
        transformedPos.y = startingPos.y + Mathf.Sin(Time.time * animationSpeed) * animationAmplitude;
            
        transform.rotation = transformedPos;
    }

}
