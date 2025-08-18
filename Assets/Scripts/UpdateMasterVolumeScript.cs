using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class UpdateMasterVolumeScript : MonoBehaviour
{

    public Slider MasterVolumeSlider;
    public TMP_Text MasterVolumeText;

    public Slider SFXVolumeSlider;
    public TMP_Text SFXVolumeText;

    public Slider MusicVolumeSlider;
    public TMP_Text MusicVolumeText;

    public AudioMixer MasterAudioMixer;

    void Start()
    {
        MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 100);
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 75);
        MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 50);
    }

    public void OnMasterVolumeChanged(float value)
    {
        float masterVolumePercent = MasterVolumeSlider.value;
        MasterVolumeText.text = masterVolumePercent.ToString();

        float masterVolumeInDecibels = Mathf.Lerp(-80f, 0f, masterVolumePercent / 100f);

        MasterAudioMixer.SetFloat("MasterVolume", masterVolumeInDecibels);

        PlayerPrefs.SetFloat("MasterVolume", masterVolumePercent);
        PlayerPrefs.Save();
    }

    public void OnSFXVolumeChanged(float value)
    {
        float SFXVolumePercent = SFXVolumeSlider.value;
        SFXVolumeText.text = SFXVolumePercent.ToString();

        float SFXVolumeInDecibels = Mathf.Lerp(-80f, 0f, SFXVolumePercent / 100f);

        MasterAudioMixer.SetFloat("SFXVolume", SFXVolumeInDecibels);

        PlayerPrefs.SetFloat("SFXVolume", SFXVolumePercent);
        PlayerPrefs.Save();
    }
    public void OnMusicVolumeChanged(float value)
    {
        float musicVolumePercent = MusicVolumeSlider.value;
        MusicVolumeText.text = musicVolumePercent.ToString();

        float musicVolumeInDecibels = Mathf.Lerp(-80f, 0f, musicVolumePercent / 100f);

        MasterAudioMixer.SetFloat("MusicVolume", musicVolumeInDecibels);

        PlayerPrefs.SetFloat("MusicVolume", musicVolumePercent);
        PlayerPrefs.Save();
    }

}
