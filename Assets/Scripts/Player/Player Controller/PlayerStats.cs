using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] IG_UI HealthBar;
    [SerializeField] IG_UI StaminaBar;
    [SerializeField] DeathScreen deathScreen;
    [SerializeField] protected float maxHealth, maxStamina, maxHealthFlasks, staminaRegenRate;
    public float currentHealth, currentStamina, currentHealthFlasks, currentLevel;

    void Awake()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentHealthFlasks = maxHealthFlasks;

        HealthBar.SetValue(currentHealth / maxHealth);
        StaminaBar.SetValue(currentStamina / maxStamina);
    }

    private void FixedUpdate()
    {
        StaminaRegen();
    }

    private void StaminaRegen()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += Time.deltaTime * staminaRegenRate;
            StaminaBar.SetValue(currentStamina / maxStamina);
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;
        //Destroy(gameObject);
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
        StaminaBar.SetValue(currentStamina / maxStamina);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        HealthBar.SetValue(currentHealth / maxHealth);
        if (currentHealth <= 0)
        {
            Die();
            deathScreen.Enable();
        }
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;
    }

}
