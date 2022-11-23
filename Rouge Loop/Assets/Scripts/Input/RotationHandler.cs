
using UnityEngine;

public class RotationHandler : MonoBehaviour
{
    private AnimationHandler animationHandler;
    private InputHandler inputHandler;
    private Transform cameraAngle;
    private float turnSmoothVelocity;
    public float smoothTime;
    private void Awake()
    {
        cameraAngle = Camera.main.transform;
        inputHandler = GetComponent<InputHandler>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    private void Update()
    {
        DoRotationRalativeCamera();
    }

    public  void  DoRotationRalativeCamera()
    {
        if (inputHandler.MovementInput.magnitude < 0.2f) return;
        if (animationHandler.animator.GetBool("isInteracting")) { Rotate(0.5f); return; }
        Rotate(smoothTime);
    }

    private void Rotate(float smooth)
    {
        float relativeAngle = Mathf.Atan2(inputHandler.MovementInput.x, inputHandler.MovementInput.y) * Mathf.Rad2Deg + cameraAngle.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, relativeAngle, ref turnSmoothVelocity, smooth);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
