/*using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController CharacterController;
    private InputAction _moveAction, _lookAction, _jumpAction;
    void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _lookAction = InputSystem.actions.FindAction("Look");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _jumpAction.performed += OnJumpPerformed;

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        CharacterController.Move(movementVector);

        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        CharacterController.Rotate(lookVector);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        CharacterController.Jump();
    }
}*/
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerController CharacterController;
    [SerializeField] private InputActionAsset inputActions; // Reference to your Input Actions asset

    private InputAction _moveAction, _lookAction, _jumpAction;

    void Start()
    {
        // Get the action map (replace "Player" with your actual action map name)
        var actionMap = inputActions.FindActionMap("Player");

        _moveAction = actionMap.FindAction("Move");
        _lookAction = actionMap.FindAction("Look");
        _jumpAction = actionMap.FindAction("Jump");

        // Enable the action map
        actionMap.Enable();

        _jumpAction.performed += OnJumpPerformed;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector2 movementVector = _moveAction.ReadValue<Vector2>();
        CharacterController.Move(movementVector);

        Vector2 lookVector = _lookAction.ReadValue<Vector2>();
        CharacterController.Rotate(lookVector);
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        CharacterController.Jump();
    }

    private void OnDestroy()
    {
        // Clean up
        if (_jumpAction != null)
            _jumpAction.performed -= OnJumpPerformed;
    }
}
