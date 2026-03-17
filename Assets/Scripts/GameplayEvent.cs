using UnityEngine;

public struct GameplayEvent//was intially a struct
{
    public GameplayEventType EventType;
    public string TargetId;
    public int Amount;

    public GameplayEvent(GameplayEventType eventType, string targetId, int amount)
    {
        EventType = eventType;
        TargetId = targetId;
        Amount = amount;
    }
    /*EnemyKilled,
    ItemCollected,
    AreaEntered,
    NPCInteracted*/

}
