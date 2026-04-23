using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 30;
    [SerializeField] int currentHealth;
   
    [SerializeField] float damgage = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentHealth -= (int)damgage;
            Debug.Log("Enemy hit by player, current health: " + currentHealth);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            //healthBar.UpdateHealthBar(maxHealth, currentHealth);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
