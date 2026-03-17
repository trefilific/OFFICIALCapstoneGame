using UnityEngine;

public class QuestEntryUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI questNameText;
    [SerializeField] Transform objectiveContainer;
    [SerializeField] ObjectiveEntryUI objectivePrefab;

    QuestInstance quest;

    public void Initialize(QuestInstance quest)
    {
        this.quest = quest;
        questNameText.text = quest.QuestName;
        foreach (var objective in quest.ObjectiveInstances)
        {
            var objectiveUI = Instantiate(objectivePrefab, objectiveContainer);
            objectiveUI.Initialize(objective);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void CreateQuestUI(QuestInstance quest)
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
