using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
