using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;

    public float MovementSpeed = 10f, RotateSpeed = 5f;

    private float _rotationY;


    Rigidbody rb;

    private void Start()
    {

        _characterController = GetComponent<CharacterController>();
       // rb = GetComponent<Rigidbody>();


    }

    public void Move(Vector2 movementVector)
    {
        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
        move = move * MovementSpeed * Time.deltaTime;
        _characterController.Move(move);
    }

    public void Rotate(Vector2 rotationVector)
    {
        _rotationY += rotationVector.x * RotateSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);
    }
    private void Update()
    {
    }
}

