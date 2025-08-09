using UnityEngine;

/// <summary>
/// Basic attack component that damages a target's Health at a fixed interval.
/// </summary>
public class Attack : MonoBehaviour
{
    public int damage = 20;
    public float attackInterval = 1.5f;
    private float lastAttackTime;
    [Tooltip("Particle effect played when attacking.")]
    public ParticleSystem shootEffect;
    private Animator animator;
    private ParticleSystem shootInstance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if (shootEffect != null)
        {
            shootInstance = Instantiate(shootEffect, transform);
            shootInstance.Stop();
        }
    }

    /// <summary>
    /// Attempts to deal damage to the target's Health component.
    /// </summary>
    public void AttackTarget(GameObject target)
    {
        if (Time.time < lastAttackTime + attackInterval)
        {
            return;
        }

        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
            lastAttackTime = Time.time;
            if (animator != null)
            {
                animator.SetTrigger("Attack");
            }
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayShoot();
            }
            if (shootInstance != null)
            {
                shootInstance.transform.position = transform.position;
                shootInstance.Play();
            }
        }
    }
}
