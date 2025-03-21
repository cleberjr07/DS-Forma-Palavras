using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Sons")]
    [SerializeField] private AudioClip[] _mainMenuMusic;
    public void Start()
    {
        SoundFXManager.instance.PlaySoundFXClip(_mainMenuMusic, transform.position, 1f, true);
        HintManager.instance.enabled = false;
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level " + levelIndex);
        HintManager.instance.enabled = true;
    }
}
