using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class QuestInstance
{
    private QuestDefinition _questDefinition;
    private List<ObjectiveInstance> objectiveInstances;
    private bool isCompleted = false;

    public event System.Action<QuestInstance> OnQuestCompleted;
    public event System.Action<ObjectiveInstance> OnObjectiveCompleted;

    public QuestInstance(QuestDefinition questDefinition)
    {
        this._questDefinition = questDefinition;
        objectiveInstances = new List<ObjectiveInstance>();

        /*foreach (var objectiveInstance in objectiveInstances)
        {
            objectiveInstances.Add(objectiveInstance);
        }*/
        foreach(var objectiveDef in _questDefinition.Objectives)
        {
            var instance = new ObjectiveInstance(objectiveDef);
            instance.OnObjectiveCompleted += HandleObjectiveCompleted;
            objectiveInstances.Add(instance);
        }
    }

    private void HandleObjectiveCompleted(ObjectiveInstance objInstance)
    {
        OnObjectiveCompleted?.Invoke(objInstance);
        CheckCompletion();
    }
    public void CheckCompletion()
    {
        if(isCompleted) return;

        foreach (var objectiveInstance in objectiveInstances)
        {
            if (!objectiveInstance.IsCompleted)
            {
                return;
            }
        }
        isCompleted = true;
        OnQuestCompleted?.Invoke(this);
    }
    public IReadOnlyList<ObjectiveInstance> ObjectiveInstances => objectiveInstances;
    public bool IsCompleted => isCompleted;
    public string QuestName => _questDefinition.QuestName;

}
