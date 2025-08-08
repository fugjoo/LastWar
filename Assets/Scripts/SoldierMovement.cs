using UnityEngine;

/// <summary>
/// Handles forward motion and lane switching for a soldier unit.
/// </summary>
public class SoldierMovement : MonoBehaviour
{
    [Tooltip("Forward movement speed in units per second.")]
    public float forwardSpeed = 2f;
    [Tooltip("Horizontal distance moved per lane switch.")]
    public float laneOffset = 1.5f;

    private void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Move the soldier horizontally across the belt by one lane in the given direction.
    /// </summary>
    public void MoveLane(int direction)
    {
        Vector3 position = transform.position;
        position.x += laneOffset * direction;
        transform.position = position;
    }
}
