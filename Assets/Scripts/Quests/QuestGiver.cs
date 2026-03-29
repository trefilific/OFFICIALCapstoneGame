using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public void Interact()
    {
        var questManager = QuestManager.Instance;
        if(questManager.IsCompleted(quest))
        {
            Debug.Log("You have already completed this quest.");
        }
        else if(questManager.IsActive(quest))
        {
            questManager.CompleteQuest(quest);
        }
        else
        {
            questManager.AcceptQuest(quest);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
