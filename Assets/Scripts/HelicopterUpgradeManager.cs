using UnityEngine;

/// <summary>
/// Manages helicopter upgrades using the player's coin balance.
/// </summary>
public class HelicopterUpgradeManager : MonoBehaviour
{
    [Tooltip("Base cost for the first helicopter upgrade.")]
    public int baseUpgradeCost = 20;
    [Tooltip("Multiplier applied to the cost for each subsequent level.")]
    public float costMultiplier = 2f;

    private int level = 0;

    /// <summary>
    /// Attempt to upgrade the helicopter's health and damage.
    /// </summary>
    public bool TryUpgrade(Health health, Damage damage)
    {
        int cost = Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(costMultiplier, level));
        if (!GameManager.Instance.SpendCoins(cost))
        {
            return false;
        }
        level += 1;
        if (health != null)
        {
            health.maxHealth += 20;
            health.currentHealth = health.maxHealth;
        }
        if (damage != null)
        {
            damage.damage += 5;
        }
        return true;
    }
}
