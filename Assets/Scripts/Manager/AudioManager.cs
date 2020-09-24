using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip towerUpgrade;
    [SerializeField] AudioClip towerDowngrade;
    [SerializeField] AudioClip towerSold;

    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip enemyKilled;
    [SerializeField] AudioClip finishedPath;

    public static List<AudioClip> audioClips;
    public static List<AudioSource> audioSources;

    private void Awake()
    {
        audioClips = new List<AudioClip>();
        audioSources = new List<AudioSource>();
        AddAudioClipsToList();

        foreach (AudioClip audio in audioClips)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.clip = audio;
            audioSources.Add(source);
        }
    }

    private void AddAudioClipsToList()
    {
        audioClips.Add(towerUpgrade);
        audioClips.Add(towerDowngrade);
        audioClips.Add(towerSold);
        audioClips.Add(enemyHit);
        audioClips.Add(enemyKilled);
        audioClips.Add(finishedPath);
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
        print("Sound not found: " + name);


    }
}
