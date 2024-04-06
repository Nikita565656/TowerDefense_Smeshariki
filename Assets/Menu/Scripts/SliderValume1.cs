using UnityEngine;
using UnityEngine.UI;

public class SliderValume1 : MonoBehaviour
{
    private SliderValueController slideryy;
    private AudioSource audioSource;
    public Slider VolumeSlider;
    private float sliderValue;

    void Start()
    {
        VolumeSlider = slideryy.volumeSlider;

       

        audioSource = GetComponent<AudioSource>();
        VolumeSlider.value = audioSource.volume;
        LoadSliderValue();
        VolumeSlider.value = sliderValue;
        VolumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }


    public void ChangeVolume()

    {

        audioSource.volume = VolumeSlider.value;
        VolumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });

    }

    void OnSliderValueChanged()
    {
        sliderValue = VolumeSlider.value;
        SaveSliderValue();
    }

    void LoadSliderValue()
    {
        sliderValue = PlayerPrefs.GetFloat("SliderValue", 0f);
    }

    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("SliderValue", sliderValue);
        PlayerPrefs.Save();
    }
}
