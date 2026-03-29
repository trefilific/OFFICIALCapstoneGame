using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    public string questName;
    [TextArea] public string description;
    public int rewardGold;
    public int rewardXP;
    public bool isCompleted;
}
