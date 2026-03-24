//using UnityEngine;
//using UnityEngine.InputSystem;
//public class PlayerController : MonoBehaviour
//{
//    private CharacterController _characterController;

//    public float MovementSpeed = 10f, RotateSpeed = 5f, JumpForce = 10f, Gravity = -30f;

//    private float _rotationY;
//    private float _verticalVelocity;

//    [Header("Camera Settings")]
//    [SerializeField] private Transform cameraTransform;
//    private float _rotationX = 0f;


//    Rigidbody rb;

//    private void Start()
//    {

//        _characterController = GetComponent<CharacterController>();
//       // rb = GetComponent<Rigidbody>();


//    }

//    public void Move(Vector2 movementVector)
//    {
//        Vector3 move = transform.forward * movementVector.y + transform.right * movementVector.x;
//        move = move * MovementSpeed * Time.deltaTime;
//        _characterController.Move(move);

//        _verticalVelocity = _verticalVelocity + Gravity * Time.deltaTime;
//        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
//    }

//    public void Rotate(Vector2 rotationVector)
//    {
//        //Horizontal Rotation
//        _rotationY += rotationVector.x * RotateSpeed * Time.deltaTime;
//        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);

//        //Vertical Rotation
//        _rotationX -= rotationVector.y * RotateSpeed * Time.deltaTime;
//        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
//        cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);


//    }

//    public void Jump()
//    {
//        if(_characterController.isGrounded)
//        {
//            _verticalVelocity = JumpForce;
//        }
//    }
//    private void Update()
//    {
//    }
//}

//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerController : MonoBehaviour
//{
//    private CharacterController _characterController;
//    private Animator _animator;

//    public float MovementSpeed = 10f;
//    public float RotateSpeed = 5f;
//    public float JumpForce = 10f;
//    public float Gravity = -30f;

//    private float _rotationY;
//    private float _verticalVelocity;

//    [Header("Camera Settings")]
//    [SerializeField] private Transform cameraTransform;
//    private float _rotationX = 0f;

//    private Vector2 _movementInput;

//    private void Start()
//    {
//        _characterController = GetComponent<CharacterController>();
//        _animator = GetComponentInChildren<Animator>();
//    }

//    private void Update()
//    {
//        bool isMoving = _movementInput.magnitude > 0.1f;

//        if (_animator != null)
//        {
//            _animator.SetBool("IsMoving", isMoving);
//        }

//        Vector3 move = transform.forward * _movementInput.y + transform.right * _movementInput.x;
//        move *= MovementSpeed * Time.deltaTime;
//        _characterController.Move(move);

//        if (_characterController.isGrounded && _verticalVelocity < 0)
//        {
//            _verticalVelocity = -2f;
//        }

//        _verticalVelocity += Gravity * Time.deltaTime;
//        _characterController.Move(new Vector3(0, _verticalVelocity, 0) * Time.deltaTime);
//    }

//    public void Move(Vector2 movementVector)
//    {
//        _movementInput = movementVector;
//    }

//    public void Rotate(Vector2 rotationVector)
//    {
//        _rotationY += rotationVector.x * RotateSpeed * Time.deltaTime;
//        transform.localRotation = Quaternion.Euler(0, _rotationY, 0);

//        _rotationX -= rotationVector.y * RotateSpeed * Time.deltaTime;
//        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

//        if (cameraTransform != null)
//        {
//            cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
//        }
//    }

//    public void Jump()
//    {
//        if (_characterController.isGrounded)
//        {
//            _verticalVelocity = JumpForce;
//        }
//    }
//}
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;

    public float MovementSpeed = 10f;
    public float RotateSpeed = 5f;
    public float JumpForce = 10f;
    public float Gravity = -30f;

    private float _rotationY;
    private float _verticalVelocity;

    [Header("Camera Settings")]
    [SerializeField] private Transform cameraTransform;
    private float _rotationX = 0f;

    private Vector2 _movementInput;
    private Vector2 _lookInput;
    private bool _jumpQueued;
    private bool _isAttacking;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        bool isMoving = _movementInput.magnitude > 0.1f;

        if (_animator != null)
        {
            _animator.SetBool("IsMoving", isMoving);
        }

        Vector3 move = transform.forward * _movementInput.y + transform.right * _movementInput.x;
        move *= MovementSpeed * Time.deltaTime;
        _characterController.Move(move);

        if (_characterController.isGrounded && _verticalVelocity < 0f)
        {
            _verticalVelocity = -2f;
        }

        if (_jumpQueued && _characterController.isGrounded)
        {
            _verticalVelocity = JumpForce;
        }

        _jumpQueued = false;

        _verticalVelocity += Gravity * Time.deltaTime;
        _characterController.Move(new Vector3(0f, _verticalVelocity, 0f) * Time.deltaTime);

        _rotationY += _lookInput.x * RotateSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, _rotationY, 0f);

        _rotationX -= _lookInput.y * RotateSpeed * Time.deltaTime;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        if (cameraTransform != null)
        {
            cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        }
    }

    public void Move(Vector2 movementVector)
    {
        _movementInput = movementVector;
    }

    public void Rotate(Vector2 rotationVector)
    {
        _lookInput = rotationVector;
    }

    public void Jump()
    {
        _jumpQueued = true;
    }

    public void Hit()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("Hit");
        }
    }
}