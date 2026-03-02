using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDefinition", menuName = "Scriptable Objects/QuestDefinition")]
public class QuestDefinition : ScriptableObject
{
    [SerializeField] string questName;
    [SerializeField] string description;
    [SerializeField] List<ObjectiveDefinition> objectives;

    public string QuestName => questName;
    public string Description => description;
    public List<ObjectiveDefinition> Objectives => objectives;



}
