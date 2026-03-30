using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteract : MonoBehaviour
{
    [SerializeField] private int keysRequired = 2;
    [SerializeField] private int sapReward = 1;

    private bool playerInRange = false;
    private bool isOpened = false;
    private PlayerController currentPlayer;

    private void Update()
    {
        if (playerInRange && !isOpened && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryOpenChest();
        }
    }

    private void TryOpenChest()
    {
        if (currentPlayer == null) return;

        if (currentPlayer.UseKeys(keysRequired))
        {
            isOpened = true;
            currentPlayer.GiveSap(sapReward);
            Debug.Log("Chest unlocked! Gained Sap.");
        }
        else
        {
            Debug.Log("You need 2 keys to unlock this chest.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            playerInRange = true;
            currentPlayer = player;
            Debug.Log("Press E to unlock chest.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && player == currentPlayer)
        {
            playerInRange = false;
            currentPlayer = null;
        }
    }
}