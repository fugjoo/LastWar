using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays progress until the conveyor belt's next speed increase.
/// </summary>
public class ConveyorProgressBar : MonoBehaviour
{
    public ConveyorBelt conveyor;
    public Slider slider;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        if (slider != null)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
        }
    }

    private void Update()
    {
        if (conveyor == null || slider == null || conveyor.increaseInterval <= 0f)
        {
            return;
        }
        float elapsed = (Time.time - startTime) % conveyor.increaseInterval;
        slider.value = elapsed / conveyor.increaseInterval;
    }
}
