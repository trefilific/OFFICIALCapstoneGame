using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerController characterController;
    [SerializeField] private InputActionAsset inputActions;

    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;

    private void Start()
    {
        var actionMap = inputActions.FindActionMap("Player");

        _moveAction = actionMap.FindAction("Move");
        _lookAction = actionMap.FindAction("Look");
        _jumpAction = actionMap.FindAction("Jump");
        _attackAction = actionMap.FindAction("Attack");

        actionMap.Enable();

        _jumpAction.performed += OnJumpPerformed;
        _attackAction.performed += OnAttackPerformed;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (characterController == null) return;

        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        characterController.Move(movementVector);

        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        characterController.Rotate(lookVector);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (characterController != null)
        {
            characterController.Jump();
        }
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        if (characterController != null)
        {
            characterController.Hit();
        }
    }

    private void OnDestroy()
    {
        if (_jumpAction != null)
            _jumpAction.performed -= OnJumpPerformed;

        if (_attackAction != null)
            _attackAction.performed -= OnAttackPerformed;
    }
}
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputHandler : MonoBehaviour
//{
//    [SerializeField] private PlayerController CharacterController;
//    [SerializeField] private InputActionAsset inputActions; // Reference to your Input Actions asset

//    private InputAction _moveAction, _lookAction, _jumpAction;

//    void Start()
//    {
//        // Get the action map (replace "Player" with your actual action map name)
//        var actionMap = inputActions.FindActionMap("Player");

//        _moveAction = actionMap.FindAction("Move");
//        _lookAction = actionMap.FindAction("Look");
//        _jumpAction = actionMap.FindAction("Jump");

//        // Enable the action map
//        actionMap.Enable();

//        _jumpAction.performed += OnJumpPerformed;

//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;
//    }

//    void Update()
//    {
//        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
//        CharacterController.Move(movementVector);

//        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
//        CharacterController.Rotate(lookVector);
//    }

//    private void OnJumpPerformed(InputAction.CallbackContext context)
//    {
//        CharacterController.Jump();
//    }

//    private void OnDestroy()
//    {
//        // Clean up
//        if (_jumpAction != null)
//            _jumpAction.performed -= OnJumpPerformed;
//    }
//}
