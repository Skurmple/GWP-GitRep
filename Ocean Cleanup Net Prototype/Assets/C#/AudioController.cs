using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioMixer musicMixer;

    public AudioMixer sfxMixer;

    [SerializeField]
    private Slider musicVolumeSlider = null;

    [SerializeField]
    private Slider sfxVolumeSlider = null;

    [SerializeField]
    private Text musicSliderText = null;

    [SerializeField]
    private Text musicSliderDrop = null;

    [SerializeField]
    private Text sfxSliderText = null;

    [SerializeField]
    private Text sfxSliderDrop = null;

    void Start()
    {
        LoadValues();
    }
    public void MusicSliderText(float volume)
    {
        musicSliderText.text = volume.ToString("0.0");
        musicSliderDrop.text = volume.ToString("0.0");
    }
    public void SFXSliderText(float volume)
    {
        sfxSliderText.text = volume.ToString("0.0");
        sfxSliderDrop.text = volume.ToString("0.0");
    }

    public void SetMusicLevel(float sliderValue)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

        float musicVolumeValue = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolumeValue", musicVolumeValue);
        LoadValues();
    }

    public void SetSFXLevel(float sliderValue)
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);

        float sfxVolumeValue = sfxVolumeSlider.value;
        PlayerPrefs.SetFloat("SFXVolumeValue", sfxVolumeValue);
        LoadValues();
    }

    public void LoadValues()
    {
        float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolumeValue");
        musicVolumeSlider.value = musicVolumeValue;

        float sfxVolumeValue = PlayerPrefs.GetFloat("SFXVolumeValue");
        sfxVolumeSlider.value = sfxVolumeValue;
    }
}
