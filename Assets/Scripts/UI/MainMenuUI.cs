using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
   public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
