using UnityEngine;

/// <summary>
/// Scales a child transform to reflect the attached Health component.
/// </summary>
public class HealthBar : MonoBehaviour
{
    public Health health;
    public Transform bar;
    private float initialScaleX = 1f;

    private void Awake()
    {
        if (health == null)
        {
            health = GetComponentInParent<Health>();
        }

        if (bar != null)
        {
            initialScaleX = bar.localScale.x;
        }
    }

    private void Update()
    {
        if (health == null || bar == null || health.maxHealth <= 0)
        {
            return;
        }

        float scale = (float)health.currentHealth / health.maxHealth;
        bar.localScale = new Vector3(initialScaleX * scale, bar.localScale.y, bar.localScale.z);
    }
}
