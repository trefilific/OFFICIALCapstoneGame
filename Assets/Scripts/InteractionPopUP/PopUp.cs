
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI; // Add this to use UnityEngine.UI.Image

public class PopUp : MonoBehaviour
{
    [SerializeField] private Image border;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private BoatMount boatMount;
    [SerializeField] GameObject player;

    private bool playerInRange = false;
    private Transform playerTransform;


    void Start()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerTransform = other.transform;
            Debug.Log("Player entered interaction range.");
            ShowPrompt(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           playerInRange=false;
           playerTransform = null;
           Debug.Log("Player exited interaction range.");
            ShowPrompt(false);
        }
    }
    void Update()
    {
        if(!playerInRange) return;

        /*if (Input.GetKeyDown(KeyCode.E)) {
            if (boatMount.IsMounted())
            {
                boatMount.GetComponent<PlayerController>().enabled = false; // Re-enable player control
                player.GetComponent<PlayerController>().enabled = true; // Re-enable player control
                boatMount.Dismount();
                ShowPrompt(true);
            }
            else
            {
                boatMount.GetComponent<PlayerController>().enabled = true; // Re-enable player control
                player.GetComponent<PlayerController>().enabled = false; // Re-enable player control
                boatMount.Mount(playerTransform);
                ShowPrompt(false);
            }
        }*/
    }

    private void ShowPrompt(bool show)
    {
        border.gameObject.SetActive(show);
        text.gameObject.SetActive(show);
    }

    public void OnInteract()
    {
        if (boatMount.IsMounted())
        {
            boatMount.GetComponent<PlayerController>().enabled = false; // Re-enable player control
            player.GetComponent<PlayerController>().enabled = true; // Re-enable player control
            boatMount.Dismount();
            ShowPrompt(true);
            Debug.Log("Dismounting boat.");
        }
        else
        {
            boatMount.GetComponent<PlayerController>().enabled = true; // Re-enable player control
            player.GetComponent<PlayerController>().enabled = false; // Re-enable player control
            boatMount.GetComponent<PlayerController>().isBoat = true; // Enable boat control
            player.GetComponent<PlayerController>().isBoat = true; // Enable boat control
            boatMount.Mount(playerTransform);
            ShowPrompt(false);
            Debug.Log("Mounting boat.");
        }
    }
}
