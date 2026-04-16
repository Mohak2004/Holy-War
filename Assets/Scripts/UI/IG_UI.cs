using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IG_UI : MonoBehaviour
{
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetValue(float normalizedValue)
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        slider.value = normalizedValue;
    }
}
