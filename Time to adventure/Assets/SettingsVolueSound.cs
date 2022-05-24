using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsVolueSound : MonoBehaviour
{
    public AudioSource audioEffects;
    public AudioSource Music;
    public Slider MusicSlider, SoundSlider;

    void Update()
    {
        VolueMusic();
        VolueSound();
    }

    void VolueSound()
    {
        audioEffects.volume = PlayerPrefs.GetFloat("Sound");
    }

    void VolueMusic()
    {
        Music.volume = PlayerPrefs.GetFloat("Music");
    }
}
