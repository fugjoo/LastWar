using UnityEngine;

/// <summary>
/// Detects swipe input and moves units on the conveyor belt.
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    [Tooltip("Minimum swipe distance in pixels to trigger a lane change.")]
    public float swipeThreshold = 50f;

    private Vector2 startPosition;
    private SoldierMovement selected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(startPosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                selected = hit.collider.GetComponent<SoldierMovement>();
            }
        }
        else if (Input.GetMouseButtonUp(0) && selected != null)
        {
            Vector2 endPosition = Input.mousePosition;
            Vector2 delta = endPosition - startPosition;
            if (Mathf.Abs(delta.x) > swipeThreshold)
            {
                int direction = delta.x > 0 ? 1 : -1;
                selected.MoveLane(direction);
            }
            selected = null;
        }
    }
}
