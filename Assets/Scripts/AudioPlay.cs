using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioSource footstepAudio;
    public AudioClip[] footstepClips;

    // Add another AudioSource and clip array

    void Start()
    {
        // aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void Play_sound()
    {
        int randFootstep = Random.Range(0,footstepClips.Length);
        footstepAudio.clip=footstepClips[randFootstep];
        footstepAudio.Play();
        print("play_sound");
    }
}
