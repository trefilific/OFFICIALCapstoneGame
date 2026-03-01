using UnityEngine;

[CreateAssetMenu(fileName = "ObjectiveDefinition", menuName = "Scriptable Objects/ObjectiveDefinition")]
public class ObjectiveDefinition : ScriptableObject
{
    [SerializeField] string objectiveName;
    [SerializeField] string description;
    [SerializeField] int requiredAmount;
    [SerializeField] string targetID;
   
    public string ObjectiveName => objectiveName;
    public int RequiredAmount => requiredAmount;

    public string TargetID => targetID;

}
