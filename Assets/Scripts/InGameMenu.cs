using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToggleTimerVisibility(bool visibility)
    {
        GameController.instance.DisplayTimer = visibility;
    }
}
