using UnityEngine;

/// <summary>
/// Simple conveyor belt behaviour that moves colliding objects along a set direction.
/// </summary>
public class ConveyorBelt : MonoBehaviour
{
    [Tooltip("Direction of belt movement in world space.")]
    public Vector3 direction = Vector3.forward;

    [Tooltip("Speed at which objects are translated along the belt.")]
    public float speed = 1f;

    private void OnCollisionStay(Collision collision)
    {
        Rigidbody body = collision.rigidbody;
        Vector3 movement = direction.normalized * speed * Time.deltaTime;
        if (body != null)
        {
            body.MovePosition(body.position + movement);
        }
        else
        {
            collision.transform.position += movement;
        }
    }
}
