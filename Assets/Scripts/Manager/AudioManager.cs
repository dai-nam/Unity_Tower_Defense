using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    bool audioEnabled = true;
    [SerializeField] AudioMixerGroup masterOutputMixer;
    AudioMixerGroup inGameSoundMixer;
    AudioMixerGroup extGameSoundMixer;

    static InGameSounds inGameSounds;
    static ExtGameSounds extGameSounds;


    private void Awake()
    {
        inGameSounds = GetComponentInChildren<InGameSounds>();
        extGameSounds = GetComponentInChildren<ExtGameSounds>();
    }

    private void Start()
    {
        inGameSoundMixer = inGameSounds.audioMixerGroup;
        extGameSoundMixer = extGameSounds.audioMixerGroup;
        SetMasterOutputVolume(0f);
    }


    public static void PlaySound(string name)
    {
        inGameSounds.PlaySound(name);
    }

    public void ToggleMasterOutput()
    {
        audioEnabled = !audioEnabled;
        float volume = audioEnabled ? 0f : -80f;
        SetMasterOutputVolume(volume);
    }

    private void SetMasterOutputVolume(float volume)
    {
        masterOutputMixer.audioMixer.SetFloat("Submix", volume);
    }

}
