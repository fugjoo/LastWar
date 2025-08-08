using System.Collections;
using UnityEngine;

/// <summary>
/// Obstacle that slows down units passing through it.
/// </summary>
public class SlowObstacle : MonoBehaviour
{
    [Tooltip("Multiplier applied to the unit's speed while slowed.")]
    public float slowFactor = 0.5f;

    [Tooltip("Duration in seconds the slow effect lasts.")]
    public float slowDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        ApplySlow(other.gameObject);
    }

    private void ApplySlow(GameObject target)
    {
        SoldierMovement movement = target.GetComponent<SoldierMovement>();
        if (movement != null)
        {
            StartCoroutine(SlowRoutine(movement));
        }
    }

    private IEnumerator SlowRoutine(SoldierMovement movement)
    {
        float originalSpeed = movement.forwardSpeed;
        movement.forwardSpeed *= slowFactor;
        yield return new WaitForSeconds(slowDuration);
        movement.forwardSpeed = originalSpeed;
    }
}
