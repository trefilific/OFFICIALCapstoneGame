using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioSource enemyStepsAudio;
    public AudioClip[] enemyStepClips;
    public AudioClip[] enemyAttackClips;

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

    public void Enemy_Attack()
    {
        int randEnemyAttack = Random.Range(0,enemyAttackClips.Length);
        enemyStepsAudio.clip = enemyAttackClips[randEnemyAttack];
        enemyStepsAudio.Play();
        print("Enemy Attack (Sound)");
    }
}
