using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource AudioSourceSFX;
    public AudioSource AudioSourceBackgroundMusic;
    public AudioClip[] BackgroundMusic;
    // Start is called before the first frame update
    void Start()
    {
        AudioClip BackgroundMusicOfThisPhase = BackgroundMusic[0];
        AudioSourceBackgroundMusic.clip = BackgroundMusicOfThisPhase;
        AudioSourceBackgroundMusic.Play();

    }

    public void TouchSFX(AudioClip clip)
    {
        AudioSourceSFX.PlayOneShot(clip);

    }
}