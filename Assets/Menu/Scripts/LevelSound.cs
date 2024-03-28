using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    private static readonly string Musicpref = "MusicPref";
    private float musicFloat, soundEffectFloat;
    public AudioSource musicSource;
    public AudioSource[] soundEffectsAudio;
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private void Awake()
    {
        LevelSoundSettings();
    }
    private void LevelSoundSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(Musicpref);
        soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        musicSource.volume = musicFloat;
        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectFloat;
        }

    }
}
