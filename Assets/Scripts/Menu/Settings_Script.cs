using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Script : MonoBehaviour
{
    private float volume_Music;
    private float volume_Sounds;
    [SerializeField] AudioSource _audio;

    private int isPostProcessing = 1;
    [SerializeField] private GameObject post;
    [SerializeField] private Toggle postProcessing;

    private int antiAliasingVariant;
    [SerializeField] private TMP_Dropdown AntiAliasingDD;

    [SerializeField] Slider slider_Music;
    [SerializeField] Slider slider_Sounds;

    void Start()
    {
        Load();
        ValueAudio();
    }

    public void SliderMusic()
    {
        volume_Music = slider_Music.value;
        Save();
        ValueAudio();
    }

    public void SliderSounds()
    {
        volume_Sounds = slider_Sounds.value;
        Save();
        ValueAudio();
    }

    void ValueAudio()
    {
        _audio.volume = volume_Music;
        slider_Music.value = volume_Music;
        slider_Sounds.value = volume_Sounds;
    }

    public void PostProcessing()
    {
        if (isPostProcessing == 1)
        {
            isPostProcessing = 0;
            post.SetActive(false);
        }
        else
        {
            isPostProcessing = 1;
            post.SetActive(true);
        }
        Save();
    }

    public void AntiAliasing()
    {
        if (AntiAliasingDD.value == 0)
        {
            antiAliasingVariant = 0;
            QualitySettings.antiAliasing = 0;
        }
        else if (AntiAliasingDD.value == 1)
        {
            antiAliasingVariant = 1;
            QualitySettings.antiAliasing = 2;
        }
        else if (AntiAliasingDD.value == 2)
        {
            antiAliasingVariant = 2;
            QualitySettings.antiAliasing = 4;
        }
        else if (AntiAliasingDD.value == 3)
        {
            antiAliasingVariant = 3;
            QualitySettings.antiAliasing = 8;
            
        }
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetFloat("VolumeMusic", volume_Music);
        PlayerPrefs.SetFloat("VolumeSounds", volume_Sounds);
        PlayerPrefs.SetInt("IsPostProcessing", isPostProcessing);
        PlayerPrefs.SetInt("AntiAliasing", antiAliasingVariant);
    }

    void Load()
    {
        volume_Music = PlayerPrefs.GetFloat("VolumeMusic", volume_Music);
        volume_Sounds = PlayerPrefs.GetFloat("VolumeSounds", volume_Sounds);
        isPostProcessing = PlayerPrefs.GetInt("IsPostProcessing", isPostProcessing);
        if (isPostProcessing == 0)
        {
            postProcessing.isOn = false;
            post.SetActive(false);
        }
        antiAliasingVariant = PlayerPrefs.GetInt("AntiAliasing", antiAliasingVariant);
        AntiAliasingDD.value = antiAliasingVariant;
        if (antiAliasingVariant == 1) { QualitySettings.antiAliasing = 2; }
        else if (antiAliasingVariant == 2) { QualitySettings.antiAliasing = 4; }
        else if (AntiAliasingDD.value == 3) { QualitySettings.antiAliasing = 8; }
    }
}
