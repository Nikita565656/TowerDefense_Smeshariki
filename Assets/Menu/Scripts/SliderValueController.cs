using UnityEngine;
using UnityEngine.UI;

public class SliderValueController : MonoBehaviour
{
    public Slider volumeSlider;
    private float slidervalue;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
        LoadSliderValue();
        volumeSlider.value = slidervalue;
        volumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }


    public void ChangeVolume()

    {

        audioSource.volume = volumeSlider.value;
        volumeSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });

    }

    void OnSliderValueChanged()
    {
        slidervalue = volumeSlider.value;
        SaveSliderValue();
    }

    void LoadSliderValue()
    {
        slidervalue = PlayerPrefs.GetFloat("SliderValue", 0f);
    }

    void SaveSliderValue()
    {
        PlayerPrefs.SetFloat("SliderValue", slidervalue);
        PlayerPrefs.Save();
    }
}

