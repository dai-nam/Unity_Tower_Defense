using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Reflection;
using UnityEngine.Audio;

//static oder Singleton machen?
public abstract class GameSounds : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    public List<AudioClip> audioClips;
    public List<AudioSource> AudioSources { get; private set; }


    protected void Awake()
    {
        audioClips = new List<AudioClip>();
        AudioSources = new List<AudioSource>();
        AddAudioClipsToList();
        AddAudioSources();
    }

    protected void AddAudioClipsToList()
    {
        //Per Reflection alle AudioClip Felder der Klasse erhalten und zur Liste audioClips hinzufügen
        var clips = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                             .Where(pi => typeof(AudioClip).IsAssignableFrom(pi.FieldType));

        foreach (FieldInfo f in clips)
        {
            audioClips.Add((AudioClip)f.GetValue(this));
        }
    }

    protected void AddAudioSources()
    {
        foreach (AudioClip audio in audioClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = audio;
            SetMixGroup(source);
            AudioSources.Add(source);
        }
    }

    protected void SetMixGroup(AudioSource source)
    {
        source.outputAudioMixerGroup = audioMixerGroup;
    }

    public void PlaySound(string name)
    {
        foreach (AudioSource source in AudioSources)
        {
            if (name.Equals(source.clip.name))
            {
                source.Play();
                return;
            }
        }
        Debug.Log("Sound not found: " + name);
    }

  

}
