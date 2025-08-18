using UnityEngine;
using UnityEngine.Audio;

public class RestoreVolume : MonoBehaviour
{
    public AudioMixer masterAudioMixer;

    void Start()
    {
        // Load saved volumes from PlayerPrefs
        int masterVolumePercent = PlayerPrefs.GetInt("MasterVolume", 100);
        int sfxVolumePercent = PlayerPrefs.GetInt("SFXVolume", 100);
        int musicVolumePercent = PlayerPrefs.GetInt("MusicVolume", 100);

        // Convert from 0-100 scale to -80dB to 0dB for AudioMixer
        float masterVolumeDb = Mathf.Lerp(-80f, 0f, masterVolumePercent / 100f);
        float sfxVolumeDb = Mathf.Lerp(-80f, 0f, sfxVolumePercent / 100f);
        float musicVolumeDb = Mathf.Lerp(-80f, 0f, musicVolumePercent / 100f);

        // Set the exposed parameters on the AudioMixer
        masterAudioMixer.SetFloat("MasterVolume", masterVolumeDb);
        masterAudioMixer.SetFloat("SFXVolume", sfxVolumeDb);
        masterAudioMixer.SetFloat("MusicVolume", musicVolumeDb);
    }
}
