using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource _soundFXObj;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);   
        }

    }

    public void PlaySoundFXClip(AudioClip[] audioClip, Vector2 spawnPos, float volume)
    {
        AudioSource audioSource = Instantiate(_soundFXObj, spawnPos, Quaternion.identity);

        audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        audioSource.volume = volume;
        audioSource.Play();

        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
