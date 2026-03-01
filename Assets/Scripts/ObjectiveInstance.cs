using System;
using UnityEngine;

public class ObjectiveInstance
{

    private ObjectiveDefinition definition;
    private int currentAmount;
    private bool isCompleted = false;

    public event Action<ObjectiveInstance> OnObjectiveCompleted;

    public ObjectiveInstance(ObjectiveDefinition definition)
    {
        this.definition = definition;
        currentAmount = 0;
        isCompleted = false;
    }
    public void UpdateProgress(int amount)
    {
        if (isCompleted) return;
        currentAmount += amount;
        if (currentAmount >= definition.RequiredAmount)
        {
            Debug.Log($"Objective '{definition.ObjectiveName}' completed!");
            isCompleted = true;
            OnObjectiveCompleted.Invoke(this);
        }
    }

    public void TryProgress(string targetID, int amount)
    {
        if (isCompleted) return;

        if (definition.TargetID != targetID) return;
        UpdateProgress(amount);
    }

    public bool IsCompleted => isCompleted;
    public int CurrentAmount => currentAmount;
    public string TargetID => definition.TargetID;
}
