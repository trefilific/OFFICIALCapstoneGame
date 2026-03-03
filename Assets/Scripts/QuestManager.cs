using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
   public static QuestManager Instance { get; private set; }
    private List<QuestInstance> activeQuests = new();

    private Dictionary<GameplayEventType, Dictionary<string, List<ObjectiveInstance>>> routingTable = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }*/
}
