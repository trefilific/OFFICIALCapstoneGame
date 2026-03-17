using System;
using UnityEngine;

public static class GameplayEventBus
{
    public static Action<GameplayEvent> OnGameplayEvent;
    public static void Raise(GameplayEvent gameplayEvent)
    {
        OnGameplayEvent?.Invoke(gameplayEvent);
    }
}
