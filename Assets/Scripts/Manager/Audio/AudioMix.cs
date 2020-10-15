using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Audio Mix", menuName = "Scriptable Object/Audio Mix")]
public class AudioMix : ScriptableObject
{
    [SerializeField] private List<Mix> mixes;
    public List<Mix> Mixes
    {
        get
        {
            if (mixes == null)
            {
                mixes = new List<Mix>();
            }
            return mixes;
        }
        set
        {
            mixes = value;
        }
    }

    public void ResetToDefaultValues()
    {
        foreach (Mix mix in Mixes)
        {
            mix.volume = 1f;
            mix.pitch = 1f;
        }
    }
}
