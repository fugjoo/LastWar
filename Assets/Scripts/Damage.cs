using UnityEngine;

/// <summary>
/// Applies damage to other objects on collision.
/// </summary>
public class Damage : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        Health target = collision.gameObject.GetComponent<Health>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}
