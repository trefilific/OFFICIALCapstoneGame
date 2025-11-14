using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public PlayerController CharacterController;
    [SerializeField] private PlayerInput playerInput; // Changed from public to private with SerializeField
    private InputAction _moveAction, _lookAction, _jumpAction;

    void Awake()
    {
        // Try to get PlayerController if not assigned
        if (CharacterController == null)
        {
            CharacterController = GetComponent<PlayerController>();
        }

        // Try to get PlayerInput component
        playerInput = GetComponent<PlayerInput>();
        if (playerInput == null)
        {
            Debug.LogError("PlayerInput component is missing! Adding one...");
            playerInput = gameObject.AddComponent<PlayerInput>();
        }

        // Ensure the Input Actions asset is assigned
        if (playerInput.actions == null)
        {
            Debug.LogError("Please assign the Input Actions asset to the PlayerInput component in the Inspector!");
            enabled = false;
        }
    }

    void Start()
    {
        if (playerInput == null || playerInput.actions == null)
        {
            Debug.LogError("Input Actions asset is not assigned to PlayerInput component!");
            enabled = false;
            return;
        }

        try
        {
            // Get the actions from PlayerInput component
            _moveAction = playerInput.actions["Move"];
            _lookAction = playerInput.actions["Look"];
            _jumpAction = playerInput.actions["Jump"];

            if (_moveAction == null || _lookAction == null || _jumpAction == null)
            {
                Debug.LogError("One or more required actions (Move, Look, Jump) are missing from the Input Actions asset!");
                enabled = false;
                return;
            }

            _jumpAction.performed += OnJumpPerformed;
            Cursor.visible = false;
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Error setting up input actions: {e.Message}");
            enabled = false;
        }
    }

    void Update()
    {
        if (CharacterController == null)
        {
            Debug.LogError("PlayerController reference is missing!");
            enabled = false;
            return;
        }

        if (_moveAction != null && _lookAction != null)
        {
            Vector2 movementVector = _moveAction.ReadValue<Vector2>();
            CharacterController.Move(movementVector);

            Vector2 lookVector = _lookAction.ReadValue<Vector2>();
            CharacterController.Rotate(lookVector);
        }
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (CharacterController != null)
        {
            CharacterController.Jump();
        }
    }

    private void OnDisable()
    {
        if (_jumpAction != null)
        {
            _jumpAction.performed -= OnJumpPerformed;
        }
    }
}
