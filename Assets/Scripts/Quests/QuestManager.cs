////using NUnit.Framework;
//using System.Collections.Generic;
////using System.Runtime.CompilerServices;
//using TMPro;
//using UnityEngine;

//public class QuestManager : MonoBehaviour
//{
//    public static QuestManager Instance { get; private set; }
//    private List<Quest> activeQuests = new();
//    private List<Quest> completedQuest = new();
//    public TMP_Text QuestTitle;
//    public TMP_Text QuestDescription;

//    void Start()
//    {
//        QuestTitle.text = "No Active Quest";
//        QuestDescription.text = "";
//    }
//    void Awake()
//    {
//        if (Instance != null)
//        {
//            Destroy(gameObject);
//            return;
//        }
//        Instance = this;
//        DontDestroyOnLoad(gameObject);
//    }

//    public void AcceptQuest(Quest quest)
//    {
//        if(!activeQuests.Contains(quest) && !quest.isCompleted)
//        {
//            activeQuests.Add(quest);
//            Debug.Log($"Accepted quest: {quest.questName}");
//           QuestTitle.text = quest.questName;
//           QuestDescription.text = quest.description;
//        }
//    }

//    public void CompleteQuest(Quest quest)
//    {
//        if (!activeQuests.Contains(quest)) return;
//           quest.isCompleted = true;
//           activeQuests.Remove(quest);
//           completedQuest.Add(quest);
//           GiveReward(quest);
//        Debug.Log($"Completed quest: {quest.questName}");
//        QuestTitle.text = "No Active Quest";
//        QuestDescription.text = "";

//    }

//    private void GiveReward(Quest quest)
//    {
//        // Implement reward logic here (e.g., add gold, experience points, items, etc.)
//        Debug.Log($"Received {quest.rewardGold} gold and {quest.rewardXP} XP for completing {quest.questName}");
//    }

//    public bool IsActive(Quest quest) => activeQuests.Contains(quest);
//    public bool IsCompleted(Quest quest) => completedQuest.Contains(quest);

/* public static QuestManager Instance { get; private set; }
  public IReadOnlyList<QuestInstance> activeQuests => activeQuests;

  private Dictionary<GameplayEventType, Dictionary<string, List<ObjectiveInstance>>> routingTable = new();

  public event System.Action<QuestInstance> OnQuestAdded;
  public event System.Action<QuestInstance> OnQuestRemoved;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  private void Awake()
  {
      if (Instance != null && Instance != this)
      {
          Destroy(gameObject);
          return;
      }
      Instance = this;
      DontDestroyOnLoad(gameObject);
  }

  private void OnEnable()
  {
      GameplayEventBus.OnGameplayEvent += HandleGameplayEvent;
  }

  private void OnDisable()
  {
      GameplayEventBus.OnGameplayEvent -= HandleGameplayEvent;
  }

  private void HandleGameplayEvent(GameplayEvent gameplayEvent)
  {
      if (!routingTable.TryGetValue(gameplayEvent.EventType, out var targetDict))
      {
          return;
      }
      if (!targetDict.TryGetValue(gameplayEvent.TargetId, out var objectives))
      {
          return;
      }

      var snapshot = new List<ObjectiveInstance>(objectives);

      foreach (var objective in snapshot)
      {
          objective.TryProgress(gameplayEvent.TargetId, gameplayEvent.Amount);
      }
  }

  private void HandleQuestCompleted(QuestInstance quest)
  {
      UnregisterObjectives(quest);
     // activeQuests.Remove(quest);
      OnQuestRemoved?.Invoke(quest);
  }

  public void AddQuest(QuestDefinition questDefinition)
  {
      var questInstance = new QuestInstance(questDefinition);
      questInstance.OnQuestCompleted += HandleQuestCompleted;
      //activeQuests.Add(questInstance);
      OnQuestAdded?.Invoke(questInstance);
      RegisterObjectives(questInstance);
  }

  public void RegisterObjectives(QuestInstance quest)
  {
      foreach(var objective in quest.ObjectiveInstances)
      {
          var type = objective.EventType;
          var target = objective.TargetID;

          if (!routingTable.ContainsKey(type))
          {
            routingTable[type] = new Dictionary<string, List<ObjectiveInstance>>();
          }

          if (!routingTable[type].ContainsKey(target))
          {
              routingTable[type][target] = new List<ObjectiveInstance>();
          }

          routingTable[type][target].Add(objective);
      }
  }

  private void UnregisterObjectives(QuestInstance quest)
  {
      foreach (var objective in quest.ObjectiveInstances)
      {
          var type = objective.EventType;
          var target = objective.TargetID;

          if (!routingTable.TryGetValue(type, out var targetDict))
              continue;

          if (!targetDict.TryGetValue(target, out var objectives))
              continue;

          objectives.Remove(objective);

          if (objectives.Count == 0)
          {
              targetDict.Remove(target);
          }

          if (targetDict.Count == 0)
          {
              routingTable.Remove(type);
          }

      }
  }*/
/*void Start()
{

}

// Update is called once per frame
void Update()
{

}*/
//}
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance { get; private set; }

    private List<Quest> activeQuests = new();
    private List<Quest> completedQuest = new();

    public TMP_Text QuestTitle;
    public TMP_Text QuestDescription;

    [Header("Quest 1: Collect 2 Keys")]
    [SerializeField] private Quest collect2KeysQuest;
    private int keyProgress = 0;
    private int keysNeeded = 2;

    [Header("Quest 2: Retrieve Sap")]
    [SerializeField] private Quest retrieveSapQuest;
    private int sapProgress = 0;
    private int sapNeeded = 1;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        QuestTitle.text = "No Active Quest";
        QuestDescription.text = "";

        if (collect2KeysQuest != null)
        {
            AcceptQuest(collect2KeysQuest);
        }
    }

    public void AcceptQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest) && !completedQuest.Contains(quest))
        {
            activeQuests.Add(quest);
            Debug.Log($"Accepted quest: {quest.questName}");

            QuestTitle.text = quest.questName;

            if (quest == collect2KeysQuest)
            {
                keyProgress = 0;
                UpdateKeyQuestUI();
            }
            else if (quest == retrieveSapQuest)
            {
                sapProgress = 0;
                UpdateSapQuestUI();
            }
            else
            {
                QuestDescription.text = quest.description;
            }
        }
    }

    public void CompleteQuest(Quest quest)
    {
        if (!activeQuests.Contains(quest)) return;

        activeQuests.Remove(quest);
        completedQuest.Add(quest);

        GiveReward(quest);

        Debug.Log($"Completed quest: {quest.questName}");

        // Chain quests here
        if (quest == collect2KeysQuest && retrieveSapQuest != null && !IsCompleted(retrieveSapQuest))
        {
            AcceptQuest(retrieveSapQuest);
            return;
        }

        QuestTitle.text = "No Active Quest";
        QuestDescription.text = "";
    }

    private void GiveReward(Quest quest)
    {
        Debug.Log($"Received {quest.rewardGold} gold and {quest.rewardXP} XP for completing {quest.questName}");
    }

    public bool IsActive(Quest quest)
    {
        return activeQuests.Contains(quest);
    }

    public bool IsCompleted(Quest quest)
    {
        return completedQuest.Contains(quest);
    }

    public void OnKeyCollected()
    {
        if (collect2KeysQuest == null) return;
        if (!IsActive(collect2KeysQuest)) return;
        if (IsCompleted(collect2KeysQuest)) return;

        keyProgress++;
        Debug.Log($"Key progress: {keyProgress}/{keysNeeded}");

        UpdateKeyQuestUI();

        if (keyProgress >= keysNeeded)
        {
            CompleteQuest(collect2KeysQuest);
        }
    }

    public void OnSapCollected()
    {
        if (retrieveSapQuest == null) return;
        if (!IsActive(retrieveSapQuest)) return;
        if (IsCompleted(retrieveSapQuest)) return;

        sapProgress++;
        Debug.Log($"Sap progress: {sapProgress}/{sapNeeded}");

        UpdateSapQuestUI();

        if (sapProgress >= sapNeeded)
        {
            CompleteQuest(retrieveSapQuest);
        }
    }

    private void UpdateKeyQuestUI()
    {
        QuestDescription.text = $"Collect 2 keys ({keyProgress}/{keysNeeded})";
    }

    private void UpdateSapQuestUI()
    {
        QuestDescription.text = $"Retrieve sap from final area ({sapProgress}/{sapNeeded})";
    }
}