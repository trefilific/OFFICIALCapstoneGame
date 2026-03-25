//using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
   public static QuestManager Instance { get; private set; }
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
    }
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }*/
}
