using System.Runtime.CompilerServices;
using UnityEngine;

public class BoatMount : MonoBehaviour
{
    [SerializeField] private Transform steeringWheelSeatPosition;
    [SerializeField] private MonoBehaviour playerMovementScript;

  //  private BoatSteering boatSteering;
    private Transform player;
    private bool isMounted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // boatSteering = GetComponent<BoatSteering>();
    }

    public void Mount(Transform playerTransform)
    {
        player = playerTransform;
        isMounted = true;
        playerMovementScript.enabled = false; 
        player.SetParent(transform);
        player.position = steeringWheelSeatPosition.position;
        player.rotation = steeringWheelSeatPosition.rotation;
        //boatSteering.SetControl(true); // Enable boat control
        Debug.Log("Player mounted the boat.");
    }

    public void Dismount()
    {
        if (!isMounted) return;
        isMounted = false;
        playerMovementScript.enabled = true; 
        player.SetParent(null);
       // boatSteering.SetControl(false); 
        player = null;
        Debug.Log("Player dismounted the boat.");
    }

    public bool IsMounted() => isMounted;
    // Update is called once per frame
    void Update()
    {
        
    }
}
