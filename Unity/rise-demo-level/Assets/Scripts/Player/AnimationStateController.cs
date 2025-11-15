using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleIsRunning(Vector3 InputDirection)
    {
        animator.SetBool("isRunningForward", InputDirection.z >= 1);
        animator.SetBool("isRunningBackwards", InputDirection.z <= -1);
    }
}