using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource _soundFXObj;
    [SerializeField] private AudioSource _musicFXObj;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);   
        }
        else
            Destroy(gameObject);
    }

    public void PlaySoundFXClip(AudioClip[] audioClip, Vector2 spawnPos, float volume, bool isMusic)
    {
        AudioSource audioSource = Instantiate(isMusic? _musicFXObj : _soundFXObj, spawnPos, Quaternion.identity);

        audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        audioSource.volume = volume;
        audioSource.Play();

        if (!isMusic)
        {
            float clipLength = audioSource.clip.length;
            Destroy(audioSource.gameObject, clipLength);
        }
    }
}
