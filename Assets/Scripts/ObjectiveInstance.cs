using UnityEngine;

public class ObjectiveInstance : ObjectiveDefinition
{
    [SerializeField] int currentAmount;
    [SerializeField] int requiredAmount;
    [SerializeField] string objectiveName;
    public void UpdateProgress(int amount)
    {
        currentAmount += amount;
        if (currentAmount >= requiredAmount)
        {
            Debug.Log($"Objective '{objectiveName}' completed!");
        }
    }
}
