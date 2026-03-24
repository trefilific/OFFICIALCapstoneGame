using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter(Collider other)
    {
        Inventory inv = other.GetComponent<Inventory>();

        if (inv != null)
        {
            inv.AddItem(item);
            Destroy(gameObject);
        }
    }
}

