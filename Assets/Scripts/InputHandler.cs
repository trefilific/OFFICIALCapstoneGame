//using UnityEngine;
//using UnityEngine.InputSystem;

//public class InputHandler : MonoBehaviour
//{
//    [SerializeField] private PlayerController characterController;
//    [SerializeField] private InputActionAsset inputActions;

//    private InputAction _moveAction;
//    private InputAction _lookAction;
//    private InputAction _jumpAction;
//    private InputAction _attackAction;

//    private void Start()
//    {
//        var actionMap = inputActions.FindActionMap("Player");

//        _moveAction = actionMap.FindAction("Move");
//        _lookAction = actionMap.FindAction("Look");
//        _jumpAction = actionMap.FindAction("Jump");
//        _attackAction = actionMap.FindAction("Attack");

//        actionMap.Enable();

//        _jumpAction.performed += OnJumpPerformed;
//        _attackAction.performed += OnAttackPerformed;

//        Cursor.visible = false;
//        Cursor.lockState = CursorLockMode.Locked;
//    }

//    private void Update()
//    {
//        if (characterController == null) return;

//        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
//        characterController.Move(movementVector);

//        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
//        characterController.Rotate(lookVector);
//    }

//    private void OnJumpPerformed(InputAction.CallbackContext context)
//    {
//        if (characterController != null)
//        {
//            characterController.Jump();
//        }
//    }

//    private void OnAttackPerformed(InputAction.CallbackContext context)
//    {
//        if (characterController != null)
//        {
//            characterController.Hit();
//        }
//    }

//    private void OnDestroy()
//    {
//        if (_jumpAction != null)
//            _jumpAction.performed -= OnJumpPerformed;

//        if (_attackAction != null)
//            _attackAction.performed -= OnAttackPerformed;
//    }
//}
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController characterController;
    [SerializeField] private InputActionAsset inputActions;

    [Header("Settings")]
    [SerializeField] private string actionMapName = "Player";
    [SerializeField] private bool lockCursor = true;

    private InputActionMap _actionMap;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;
    private InputAction _attackAction;

    private void Awake()
    {
        if (characterController == null)
        {
            characterController = GetComponent<PlayerController>();
        }

        if (inputActions == null)
        {
            Debug.LogError("[InputHandler] Missing InputActionAsset reference.");
            return;
        }

        _actionMap = inputActions.FindActionMap(actionMapName, true);

        _moveAction = _actionMap.FindAction("Move", true);
        _lookAction = _actionMap.FindAction("Look", true);
        _jumpAction = _actionMap.FindAction("Jump", true);
        _attackAction = _actionMap.FindAction("Attack", true);
    }

    private void OnEnable()
    {
        if (_actionMap == null) return;

        _jumpAction.performed += OnJumpPerformed;
        _attackAction.performed += OnAttackPerformed;

        _actionMap.Enable();

        if (lockCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        Debug.Log("[InputHandler] Enabled Player input map.");
    }

    private void Update()
    {
        if (characterController == null || _moveAction == null || _lookAction == null)
            return;

        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        characterController.Move(movementVector);

        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        characterController.Rotate(lookVector);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("[InputHandler] Jump input detected.");

        if (characterController != null)
        {
            characterController.Jump();
        }
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("[InputHandler] Attack input detected.");

        if (characterController != null)
        {
            characterController.Hit();
        }
    }

    private void OnDisable()
    {
        if (_jumpAction != null)
            _jumpAction.performed -= OnJumpPerformed;

        if (_attackAction != null)
            _attackAction.performed -= OnAttackPerformed;

        if (_actionMap != null)
            _actionMap.Disable();

        Debug.Log("[InputHandler] Disabled Player input map.");
    }
}