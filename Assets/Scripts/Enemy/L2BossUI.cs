using UnityEngine;
using UnityEngine.UI;

public class L2BossUI : MonoBehaviour
{
    public IG_UI BossHPBar;
    public GameObject WinScreen;

    Enemy sk_Boss;

    private void Start()
    {
        sk_Boss = GetComponent<Enemy>();
        BossHPBar.SetValue(sk_Boss.currentHealth / sk_Boss.enemyData.enemyHealth);
    }

    private void Update()
    {
        BossHPBar.SetValue(sk_Boss.currentHealth / sk_Boss.enemyData.enemyHealth);
        
        if(sk_Boss.currentHealth <= 0 )
        {
            Time.timeScale = 0f;
            WinScreen.SetActive(true);
        }
    }
}
