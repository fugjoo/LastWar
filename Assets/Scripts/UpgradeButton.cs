using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Generic upgrade button that triggers unit or helicopter upgrades.
/// </summary>
public class UpgradeButton : MonoBehaviour
{
    public enum UpgradeType
    {
        Unit,
        Helicopter
    }

    [Tooltip("Which upgrade to trigger when this button is pressed.")]
    public UpgradeType upgradeType;

    [Tooltip("Reference to the unit upgrade manager.")]
    public UnitUpgradeManager unitManager;
    [Tooltip("Reference to the helicopter upgrade manager.")]
    public HelicopterUpgradeManager helicopterManager;

    [Tooltip("Health component of the unit to upgrade.")]
    public Health unitHealth;
    [Tooltip("Damage component of the unit to upgrade.")]
    public Damage unitDamage;

    [Tooltip("Health component of the helicopter to upgrade.")]
    public Health helicopterHealth;
    [Tooltip("Damage component of the helicopter to upgrade.")]
    public Damage helicopterDamage;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    private void OnClick()
    {
        switch (upgradeType)
        {
            case UpgradeType.Unit:
                unitManager?.TryUpgrade(unitHealth, unitDamage);
                break;
            case UpgradeType.Helicopter:
                helicopterManager?.TryUpgrade(helicopterHealth, helicopterDamage);
                break;
        }
    }
}
