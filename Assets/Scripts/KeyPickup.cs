using UnityEngine;

public class KeyPickup : MonoBehaviour, IPickupable
{
    public void OnPickup(PlayerController player)
    {
        player.GiveKey();
        Debug.Log("Picked up a key!");
    }
}