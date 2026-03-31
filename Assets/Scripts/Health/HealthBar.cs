using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject healthBarFill;



    public void UpdateHealthBar(float healthPercentage)
    {
        healthBarFill.transform.localScale = new Vector3(healthPercentage, 1f, 1f);
    }

    
}
