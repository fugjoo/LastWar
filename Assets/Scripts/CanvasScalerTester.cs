using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Logs the scale factor of a CanvasScaler across several mobile resolutions.
/// </summary>
[RequireComponent(typeof(CanvasScaler))]
public class CanvasScalerTester : MonoBehaviour
{
    private readonly Vector2[] testResolutions =
    {
        new Vector2(720, 1280), // HD
        new Vector2(1080, 1920), // FHD
        new Vector2(1440, 2560) // QHD
    };

    private void Start()
    {
        CanvasScaler scaler = GetComponent<CanvasScaler>();
        foreach (Vector2 res in testResolutions)
        {
            scaler.referenceResolution = res;
            Debug.Log($"Testing resolution {res.x}x{res.y}, scale factor {scaler.scaleFactor}");
        }
    }
}
