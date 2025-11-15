using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 movementVector2;
    private Vector3 forwardMovement;
    private Vector3 mousePosition;

    [SerializeField] private float speed = 10;
    [SerializeField] private AnimationStateController animationStateController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        HandlePlayerMovement(speed);
    }

    void Update()
    {
        animationStateController.HandleIsRunning(forwardMovement);
    }

    void OnMove(InputValue value)
    {
        movementVector2 = value.Get<Vector2>();
        forwardMovement = new Vector3(0, 0, movementVector2.y);
    }

    void HandlePlayerMovement(float speed)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 direction = mousePosition - transform.position;
        Quaternion newRot = Quaternion.LookRotation(direction, Vector3.up);
        Vector3 euler = newRot.eulerAngles;
        transform.rotation = Quaternion.Euler(0, euler.y, 0);

        Vector3 movement = transform.forward * forwardMovement.z * speed * Time.deltaTime;
        characterController.Move(movement);
    }
}