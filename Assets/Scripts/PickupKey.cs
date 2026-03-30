using UnityEngine;

public class PickupKey: MonoBehaviour
{
    private IPickupable pickupLogic;

    private void Awake()
    {
        pickupLogic = GetComponent<IPickupable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && pickupLogic != null)
        {
            pickupLogic.OnPickup(player);
            Destroy(gameObject);
        }
    }
}