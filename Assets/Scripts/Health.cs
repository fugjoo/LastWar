using UnityEngine;

/// <summary>
/// Basic health component that tracks hit points and handles death.
/// </summary>
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector]
    public int currentHealth;

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
        Destroy(gameObject);
    }
}
