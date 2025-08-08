using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages unit upgrades and coin expenditure.
/// </summary>
public class UnitUpgradeManager : MonoBehaviour
{
    [Tooltip("Available coins for upgrading units.")]
    public int coins;
    [Tooltip("Base cost for the first upgrade.")]
    public int baseUpgradeCost = 10;
    [Tooltip("Multiplier applied to the cost for each subsequent level.")]
    public float costMultiplier = 1.5f;

    private readonly Dictionary<Health, int> upgradeLevels = new();

    /// <summary>
    /// Attempt to upgrade a unit's health and damage using coins.
    /// </summary>
    public bool TryUpgrade(Health health, Damage damage)
    {
        int level = 0;
        if (upgradeLevels.TryGetValue(health, out int existing))
        {
            level = existing;
        }
        int cost = GetUpgradeCost(level);
        if (coins < cost)
        {
            return false;
        }
        coins -= cost;
        upgradeLevels[health] = level + 1;
        health.maxHealth += 10;
        health.currentHealth = health.maxHealth;
        damage.damage += 2;
        return true;
    }

    /// <summary>
    /// Calculate the cost for the given upgrade level.
    /// </summary>
    public int GetUpgradeCost(int level)
    {
        return Mathf.RoundToInt(baseUpgradeCost * Mathf.Pow(costMultiplier, level));
    }
}
