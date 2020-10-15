using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mix
{
    public string audioName;
    [Range(0f, 2f)] public float volume;
    [Range(0f, 2f)] public float pitch;

    public Mix(string _name, float _vol, float _pitch)
    {
        this.audioName = _name;
        this.volume = _vol;
        this.pitch = _pitch;
    }

  

}
