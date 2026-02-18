using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] ScriptableObject questItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void KillObjective(ScriptableObject scriptableObject)
    {
        string enemyName = scriptableObject.name;
        int requiredKills = 5; 
    }

    public void QuestDefinition(ScriptableObject scriptableObject)
    {
      string questName = scriptableObject.name;
      string rewardInfo = "Reward: 100 gold coins";
      
      List<string> objectives = new List<string>
      {
          "Kill 5 Goblins",
          "Collect 10 Herbs",
          "Defeat the Goblin King"
      };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Instantiate(questItem);
    }
}
