using UnityEngine;

public struct GameplayEvent
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

}
