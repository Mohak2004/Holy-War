using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] protected float maxHealth, maxStamina, maxHealthFlasks, staminaRegenRate;
    public float currentHealth, currentStamina, currentHealthFlasks;

    void Awake()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentHealthFlasks = maxHealthFlasks;
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
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;
        Destroy(gameObject);
    }

    public void UseStamina(float amount)
    {
        currentStamina -= amount;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;
    }

}
