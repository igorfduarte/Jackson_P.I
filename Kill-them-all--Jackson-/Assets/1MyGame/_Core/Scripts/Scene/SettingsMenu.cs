using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public AudioMixer musicMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("Volume", volume);
    }
}
