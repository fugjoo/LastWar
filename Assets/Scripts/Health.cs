using UnityEngine;

/// <summary>
/// Basic health component that tracks hit points and handles death.
/// </summary>
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;
    [Tooltip("Coins awarded to the player when this unit dies.")]
    public int coinValue = 0;
    [Tooltip("Score awarded to the player when this unit dies.")]
    public int scoreValue = 0;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Apply damage to the component.
    /// </summary>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Heal the component by a given amount without exceeding max health.
    /// </summary>
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }

    private void Die()
    {
        if (GameManager.Instance != null && CompareTag("Enemy"))
        {
            GameManager.Instance.AddCoins(coinValue);
            GameManager.Instance.AddScore(scoreValue);
        }
        Destroy(gameObject);
    }
}
