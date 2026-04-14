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
    }
}
