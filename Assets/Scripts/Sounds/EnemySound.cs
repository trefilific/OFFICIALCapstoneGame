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
        int randEnemyStep = Random.Range(0,enemyStepClips.Length);
        enemyStepsAudio.clip = enemyStepClips[randEnemyStep];
        enemyStepsAudio.Play();
        print("Player Footstep (Sound)");
    }
}
