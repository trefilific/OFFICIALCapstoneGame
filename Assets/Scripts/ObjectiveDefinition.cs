using UnityEngine;

[CreateAssetMenu(fileName = "ObjectiveDefinition", menuName = "Scriptable Objects/ObjectiveDefinition")]
public class ObjectiveDefinition : ScriptableObject
{
    string objectiveName;
    string description;
    int requiredAmount;
    int currentAmount;
    string targetID;
    
    public void UpdateProgress(int amount)
    {
     currentAmount += amount;
     if (currentAmount >= requiredAmount)
     {
       Debug.Log($"Objective '{objectiveName}' completed!");
      }
    }
}
