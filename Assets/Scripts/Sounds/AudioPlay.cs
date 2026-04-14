using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource footstepAudio;
    public AudioClip[] footstepClips;
    public AudioSource weaponAudio;
    public AudioClip[] weaponClips;

    // Add another AudioSource and clip array

    void Start()
    {
        // aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Player_Footsteps()
    {
        int randFootstep = Random.Range(0,footstepClips.Length);
        footstepAudio.clip=footstepClips[randFootstep];
        footstepAudio.Play();
        print("Player Footstep (Sound)");
    }

    public void Weapon_Sounds()
    {
        int randWeapon = Random.Range(0,weaponClips.Length);
        weaponAudio.clip = weaponClips[randWeapon];
        weaponAudio.Play();
        print("Weapon Attack (Sound)");
    }
}
