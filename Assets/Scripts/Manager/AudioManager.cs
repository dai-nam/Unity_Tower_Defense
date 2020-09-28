﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip towerPlaced;
    [SerializeField] AudioClip towerUpgrade;
    [SerializeField] AudioClip towerDowngrade;
    [SerializeField] AudioClip towerSold;

    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip enemyKilled;
    [SerializeField] AudioClip finishedPath;

    private static List<AudioClip> audioClips;
    private static List<AudioSource> audioSources;

    private void Awake()
    {
        audioClips = new List<AudioClip>();
        audioSources = new List<AudioSource>();
        AddAudioClipsToList();
        AddAudioSources();
    }


    private void AddAudioClipsToList()
    {
        //Per Reflection alle AudioClip Felder der Klasse erhalten und zur Liste audioClips hinzufügen
        var clips = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                             .Where(pi => typeof(AudioClip).IsAssignableFrom(pi.FieldType));   

        foreach (FieldInfo f in clips)
        {
            audioClips.Add((AudioClip) f.GetValue(this));
        }
    }

    private void AddAudioSources()
    {
        foreach (AudioClip audio in audioClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = audio;
            audioSources.Add(source);
        }
    }

    public static void PlaySound(string name)
    {
        foreach(AudioSource source in audioSources)
        {
            if(name.Equals(source.clip.name))
            {
                source.Play();
                return;
            }
        }
        Debug.Log("Sound not found: " + name);
    }
}
