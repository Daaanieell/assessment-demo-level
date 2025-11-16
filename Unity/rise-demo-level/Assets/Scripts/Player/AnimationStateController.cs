using System;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private float VelocityX;
    private float VelocityZ;

    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.1f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleIsRunning(Vector3 input)
    {
        if (input.z > 0)
            VelocityZ += acceleration * Time.deltaTime;
        else if (input.z < 0)
            VelocityZ -= acceleration * Time.deltaTime;
        else
        {
            if (VelocityZ > 0)
                VelocityZ -= deceleration * Time.deltaTime;
            else if (VelocityZ < 0)
                VelocityZ += deceleration * Time.deltaTime;
        }

        VelocityZ = Mathf.Clamp(VelocityZ, -1f, 1f);
        animator.SetFloat("VelocityZ", VelocityZ);

        if (input.x > 0)
            VelocityX += acceleration * Time.deltaTime;
        else if (input.x < 0)
            VelocityX -= acceleration * Time.deltaTime;
        else
        {
            if (VelocityX > 0)
                VelocityX -= deceleration * Time.deltaTime;
            else if (VelocityX < 0)
                VelocityX += deceleration * Time.deltaTime;
        }

        VelocityX = Mathf.Clamp(VelocityX, -1f, 1f);
        animator.SetFloat("VelocityX", VelocityX);
    }


}