using UnityEngine;

public class ObjectiveEntryUI : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;

    ObjectiveInstance objective;

    public void Initialize(ObjectiveInstance obj)
    {
        objective = obj;
        Refresh();
    }
  
    void Refresh()
    {
        text.text = $"{objective.ObjectiveName} ({objective.CurrentAmount}/{objective.RequiredAmount})";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
