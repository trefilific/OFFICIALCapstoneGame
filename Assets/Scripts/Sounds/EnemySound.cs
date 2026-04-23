using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource enemyStepsAudio;
    public AudioClip[] enemyStepClips;

    // Add another AudioSource and clip array

    void Start()
    {
        // aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Enemy_Footsteps()
    {
        if (enemyStepClips == null || enemyStepClips.Length == 0)
        {
           // Debug.LogWarning("[EnemySound] No enemy step clips assigned!");
            return;
        }

        if (enemyStepsAudio == null)
        {
           // Debug.LogError("[EnemySound] AudioSource not assigned!");
            return;
        }

        int randEnemyStep = Random.Range(0, enemyStepClips.Length);
        enemyStepsAudio.clip = enemyStepClips[randEnemyStep];
        enemyStepsAudio.Play();

       // Debug.Log($"[EnemySound] Playing footstep index: {randEnemyStep}");
    }
}
