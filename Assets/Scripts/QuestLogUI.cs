using UnityEngine;

public class QuestLogUI : MonoBehaviour
{
    [SerializeField] Transform questContainer;
    [SerializeField] QuestEntryUI questPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QuestManager.Instance.OnQuestAdded += CreateQuestUI;
        foreach (var quest in QuestManager.Instance.activeQuests)
        {
            CreateQuestUI(quest);
        }
    }

    void CreateQuestUI(QuestInstance quest)
    {
        var questUI = Instantiate(questPrefab, questContainer);
        questUI.Initialize(quest);
    }
}
