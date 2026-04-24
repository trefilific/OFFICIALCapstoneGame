using UnityEngine;

public class Player : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] float damgage = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       currentHealth = maxHealth;
         healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Projectile"))
        {
            currentHealth -= (int)damgage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthBar.UpdateHealthBar(maxHealth, currentHealth);
       }
    }

    

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            Destroy(gameObject);
            // You can add additional logic here, such as respawning the player or ending the game.
        }
    }
}
