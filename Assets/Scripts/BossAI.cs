using UnityEngine;

/// <summary>
/// Simple AI that moves towards the player and attacks when in range.
/// </summary>
[RequireComponent(typeof(Attack))]
[RequireComponent(typeof(Health))]
public class BossAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Attack attack;
    private Transform target;

    private void Awake()
    {
        if (attack == null)
        {
            attack = GetComponent<Attack>();
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        attack.AttackTarget(target.gameObject);
    }
}
