using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionUI : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnLevel1ButtonClicked()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }

    public void OnLevel2ButtonClicked()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1.0f;
    }
}
