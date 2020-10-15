
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioMix))]
public class AudioMixEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AudioMix audioMix = (AudioMix)target;


        if (GUILayout.Button("Save to JSON"))
        {
            SaveSystem.SaveAudioMixToJson(audioMix);
        }
        if (GUILayout.Button("Reset to Defaults"))
        {
            audioMix.ResetToDefaultValues();
        }
    }

    //private static void BindMixValuesToAudioMixEditor(AudioMix audioMix)
    //{
    //    if(GameSounds.AudioSources == null)
    //    {
    //        return; //Game is not running
    //    }

    //    for (int i = 0; i < audioMix.Mixes.Count; i++)
    //    {
    //       
    //            GameSounds.AudioSources[i].volume = audioMix.Mixes[i].volume;
    //            GameSounds.AudioSources[i].pitch = audioMix.Mixes[i].pitch;

    //    }
}

