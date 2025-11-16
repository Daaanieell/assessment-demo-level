using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 movementVector2;

    private Vector3 movementVector3;
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
        animationStateController.HandleIsRunning(movementVector3);
    }

    void OnMove(InputValue value)
    {
        movementVector2 = value.Get<Vector2>();
        movementVector3 = new Vector3(movementVector2.x, 0, movementVector2.y);
    }

    void HandlePlayerMovement(float speed)
    {
        RaycastHit hit;
        Ray cameraRay = Camera.main.GetComponent<Camera>().ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(cameraRay, out hit))
        {
            Vector3 direction = hit.point - transform.position;
            Quaternion newRot = Quaternion.LookRotation(direction, Vector3.up);
            Vector3 euler = newRot.eulerAngles;
            transform.rotation = Quaternion.Euler(0, euler.y, 0);
        }

        Vector3 movement = transform.right * movementVector3.x * speed * Time.deltaTime + transform.forward * movementVector3.z * speed * Time.deltaTime;
        characterController.Move(movement);
    }
}