using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
