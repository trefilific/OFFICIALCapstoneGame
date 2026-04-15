using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Scrollbar healthBarFill;


    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthBarFill.size = currentHealth/maxHealth;
    }



}
