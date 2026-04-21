using UnityEngine;
using UnityEngine.UI;

public class L1BossUI : MonoBehaviour
{
    public IG_UI BossHPBar;
    public GameObject WinScreen;

    Enemy mahoraga;

    private void Start()
    {
        mahoraga = GetComponent<Enemy>();
        BossHPBar.SetValue(mahoraga.currentHealth / mahoraga.enemyData.enemyHealth);
    }

    private void Update()
    {
        BossHPBar.SetValue(mahoraga.currentHealth / mahoraga.enemyData.enemyHealth);
        
        if(mahoraga.currentHealth <= 0 )
        {
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
        }
    }
}
