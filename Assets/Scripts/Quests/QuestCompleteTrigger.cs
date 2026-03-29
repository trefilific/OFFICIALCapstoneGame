using UnityEngine;

public class QuestCompleteTrigger : MonoBehaviour
{
    public Quest questToComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager.Instance.CompleteQuest(questToComplete);
        }
    }
}
