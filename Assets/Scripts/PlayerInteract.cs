using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered trigger with: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            QuestGiver questGiver = GetComponent<QuestGiver>(); 
            Debug.Log("QuestGiver component found: " + (questGiver != null));
            if (questGiver != null)
            {
                questGiver.Interact();
            }
        }
    }
}

