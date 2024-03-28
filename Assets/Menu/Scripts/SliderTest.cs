using UnityEngine.UI;
using UnityEngine;

public class SliderTest : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string Musicpref = "MusicPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider musicSlider, soundEffectSlider;
    private float musicFloat, soundEffectFloat;
    public AudioSource musicSource;
    public AudioSource[] soundEffectsAudio;


    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt == 0)
        {
            musicFloat = 0.25f;
            soundEffectFloat = 0.75f;
            musicSlider.value = musicFloat;
            soundEffectSlider.value = soundEffectFloat;
            PlayerPrefs.SetFloat(Musicpref, musicFloat);
            PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(Musicpref);
            musicSlider.value = musicFloat;
            soundEffectFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
            soundEffectSlider.value = soundEffectFloat;
        }
    }

    
    public void SaveSoundSettings ()
    {
        PlayerPrefs.SetFloat(Musicpref, musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectSlider.value);

    }
    private void OnApplicationFocus(bool focus)
    {
        if(!focus)
        { 
        SaveSoundSettings();
        
        }
    }
    public void UpdateSound()
    {
        musicSource.volume = musicSlider.value;
        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = musicSlider.value;
        }
    }
}
