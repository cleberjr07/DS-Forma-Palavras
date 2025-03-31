using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private bool _isInGameMenu;
    [SerializeField] Slider _masterSlider;
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;


    void OnEnable()
    {
        if (_isInGameMenu)
            UpdateSoundMenu();
    }

    private void UpdateSoundMenu()
    {
        float masterVolume, soundVolume, musicVolume;

        if (_audioMixer.GetFloat("masterVolume", out masterVolume))
            _masterSlider.value = Mathf.Pow(10, masterVolume / 20);

        if (_audioMixer.GetFloat("soundVolume", out soundVolume))
            _soundSlider.value = Mathf.Pow(10, soundVolume / 20);

        if (_audioMixer.GetFloat("musicVolume", out musicVolume))
            _musicSlider.value = Mathf.Pow(10, musicVolume / 20);
    }

    public void SetMasterVolume(float level)
    {
        _audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20);
    }

    public void SetSoundFXVolume(float level)
    {
        _audioMixer.SetFloat("soundVolume", Mathf.Log10(level) * 20);
    }

    public void SetMusicVolume(float level)
    {
        _audioMixer.SetFloat("musicVolume", Mathf.Log10(level) * 20);
    }
}
