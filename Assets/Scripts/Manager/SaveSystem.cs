using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public static class SaveSystem
{

    static string path = Application.dataPath + "/SavedData.json";
    static string path2 = Application.dataPath + "/SavedData_test.json";


    public static void SaveAudioMixToJson(AudioMix audioMix)
    {
        string json = JsonConvert.SerializeObject(audioMix, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public static AudioMix LoadAudioMixFromJson()
    {
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            AudioMix audioMix = JsonConvert.DeserializeObject<AudioMix>(json);
            Debug.Log("File " + path+" loaded");
            return audioMix;
        }
        else
        {
            Debug.Log("File not found in "+path);
            return null;
        }
    }
}


