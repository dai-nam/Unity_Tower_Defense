using UnityEngine;
using UnityEngine.Audio;

public class ExtGameSounds : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        SetMixGroup(audioSource);
    }

    private void SetMixGroup(AudioSource source)
    {
        source.outputAudioMixerGroup = audioMixerGroup;
    }


}
