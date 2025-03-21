using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int LettersCount = 0;
    public int WordsCount = 0;

    
    [Header("Sons")]
    [SerializeField] private AudioClip[] _VictorySound;
    [SerializeField] private AudioClip[] _LevelMusic;
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Application.isEditor)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (!scene.name.Contains("Level")) // se não tem level no nome da cena, não é um level, logo não precisa do hint manager
            return;

        GetAmountOfLetters();

        SoundFXManager.instance.PlaySoundFXClip(_LevelMusic, transform.position, 1f, true);
    }

    private void GetAmountOfLetters()
    {
        foreach(Transform child in GameObject.FindWithTag("LetterContainerMaster").transform)
        {
            if (child.CompareTag("LetterContainer"))
            {
                LettersCount++;
                LetterContainer lt = child.GetComponent<LetterContainer>();
                WordsCount = lt.WordIndex > WordsCount ? lt.WordIndex : WordsCount;
            }
        }
    }

    public void OnMatchLetter()
    {
        LettersCount--;

        if (LettersCount <= 0)
        {
            Debug.Log("Você venceu essa cartela");
            GameObject.FindWithTag("WinPanel").transform.GetChild(0).gameObject.SetActive(true);
            SoundFXManager.instance.PlaySoundFXClip(_VictorySound, transform.position, 1f, false);

            HintManager.instance.HintTimerRunning = false;
            foreach(Transform musicObj in GameObject.FindWithTag("MusicObj").transform) // isso serve pra musica parar quando a cartela termina, senão fica muita poluição sonora
                Destroy(musicObj.gameObject);
        }
    }
}
