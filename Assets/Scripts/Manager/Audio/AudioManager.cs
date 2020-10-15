using System;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour
{
    bool audioEnabled = true;
    [SerializeField] AudioMixerGroup masterOutputMixer;
    public static InGameSounds inGameSounds;
    public static ExtGameSounds extGameSounds;
    public List<AudioSource> AudioSources { get; private set; }

    AudioMixerGroup inGameSoundMixer;
    AudioMixerGroup extGameSoundMixer;

    [SerializeField] AudioMix audioMix;

    private void Awake()
    {
        AudioSources = new List<AudioSource>();
        inGameSounds = GetComponentInChildren<InGameSounds>();
        extGameSounds = GetComponentInChildren<ExtGameSounds>();
        LoadAllAudioSources();
        LoadAudioMixData();
    }

    void LoadAllAudioSources()
    {
        foreach(AudioSource source in inGameSounds.AudioSources)
        {
            AudioSources.Add(source);
        }
        foreach (AudioSource source in extGameSounds.AudioSources)
        {
            AudioSources.Add(source);
        }
    }

    #region ###LoadAudioMixData###
    private void LoadAudioMixData()
    {
        LoadAudioMixDataFromDisk();
        SetDataToLoadedValues();
    }

    //Loads  data from disk file into Scriptable Object AudioMix
    private void LoadAudioMixDataFromDisk()
    {
        AudioMix loadedData = SaveSystem.LoadAudioMixFromJson();
        if(loadedData != null)
        {
            audioMix.Mixes = loadedData.Mixes;
        }
    }

    //Set values of AudioSources to loaded data from Scriptable Object AudioMix
    private void SetDataToLoadedValues()
    {
        for (int i = 0; i < AudioSources.Count; i++)
        {
            AudioSource source = AudioSources[i];
            if (audioMix.Mixes.Count == 0)
            {
                source.volume = 1f;
                source.pitch = 1f;
            }
            else
            {
                source.volume = audioMix.Mixes[i].volume;
                source.pitch = audioMix.Mixes[i].pitch;
            }
        }
    }
    #endregion

    private void Start()
    {
        inGameSoundMixer = inGameSounds.audioMixerGroup;
        extGameSoundMixer = extGameSounds.audioMixerGroup;
        extGameSounds.PlaySound("Cartoon Music Loop");

        SetMasterOutputVolume(0f);
    }

    private void OnDisable()
    {
        StoreAudioMixInScriptableObject();
    }

    private void StoreAudioMixInScriptableObject()
    {
        audioMix.Mixes.Clear();                                      // unschön, besser: nur die geänderten Werte überschreiben
        foreach (AudioSource source in AudioSources)
        {
            audioMix.Mixes.Add(new Mix(source.clip.name, source.volume, source.pitch));
        }
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
