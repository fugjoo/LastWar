using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Builds the runtime UI including coin counter, unit health and conveyor progress.
/// </summary>
public class GameUI : MonoBehaviour
{
    [Tooltip("Reference to the player or unit whose health is displayed.")]
    public Health unitHealth;
    [Tooltip("Reference to the conveyor belt for progress display.")]
    public ConveyorBelt conveyor;
    [Tooltip("Upgrade manager for units.")]
    public UnitUpgradeManager unitUpgradeManager;
    [Tooltip("Upgrade manager for helicopters.")]
    public HelicopterUpgradeManager helicopterUpgradeManager;
    [Tooltip("Helicopter health component.")]
    public Health helicopterHealth;
    [Tooltip("Helicopter damage component.")]
    public Damage helicopterDamage;

    private Slider healthSlider;
    private Slider conveyorSlider;

    private void Start()
    {
        GameObject canvasGO = new("GameCanvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1080, 1920);
        scaler.matchWidthOrHeight = 0.5f;
        canvasGO.AddComponent<GraphicRaycaster>();

        // Coin text
        GameObject coinTextGO = new("CoinText");
        coinTextGO.transform.SetParent(canvasGO.transform);
        Text coinText = coinTextGO.AddComponent<Text>();
        coinText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        coinText.alignment = TextAnchor.UpperLeft;
        coinText.rectTransform.anchorMin = new Vector2(0f, 1f);
        coinText.rectTransform.anchorMax = new Vector2(0f, 1f);
        coinText.rectTransform.anchoredPosition = new Vector2(20f, -20f);
        GameManager.Instance.coinText = coinText;

        // Health bar
        GameObject healthGO = new("HealthBar");
        healthGO.transform.SetParent(canvasGO.transform);
        healthSlider = healthGO.AddComponent<Slider>();
        healthSlider.minValue = 0f;
        healthSlider.maxValue = 1f;
        RectTransform healthRect = healthSlider.GetComponent<RectTransform>();
        healthRect.anchorMin = new Vector2(0.5f, 0f);
        healthRect.anchorMax = new Vector2(0.5f, 0f);
        healthRect.sizeDelta = new Vector2(300f, 20f);
        healthRect.anchoredPosition = new Vector2(0f, 40f);

        // Conveyor progress bar
        GameObject conveyorGO = new("ConveyorProgress");
        conveyorGO.transform.SetParent(canvasGO.transform);
        conveyorSlider = conveyorGO.AddComponent<Slider>();
        ConveyorProgressBar progressBar = conveyorGO.AddComponent<ConveyorProgressBar>();
        progressBar.conveyor = conveyor;
        progressBar.slider = conveyorSlider;
        RectTransform conveyorRect = conveyorSlider.GetComponent<RectTransform>();
        conveyorRect.anchorMin = new Vector2(0.5f, 0f);
        conveyorRect.anchorMax = new Vector2(0.5f, 0f);
        conveyorRect.sizeDelta = new Vector2(300f, 20f);
        conveyorRect.anchoredPosition = new Vector2(0f, 10f);

        // Unit upgrade button
        GameObject unitButtonGO = CreateButton(canvasGO.transform, new Vector2(-150f, 80f), "Upgrade Unit");
        UpgradeButton unitButton = unitButtonGO.AddComponent<UpgradeButton>();
        unitButton.upgradeType = UpgradeButton.UpgradeType.Unit;
        unitButton.unitManager = unitUpgradeManager;
        unitButton.unitHealth = unitHealth;
        unitButton.unitDamage = unitHealth.GetComponent<Damage>();

        // Helicopter upgrade button
        GameObject heliButtonGO = CreateButton(canvasGO.transform, new Vector2(150f, 80f), "Upgrade Heli");
        UpgradeButton heliButton = heliButtonGO.AddComponent<UpgradeButton>();
        heliButton.upgradeType = UpgradeButton.UpgradeType.Helicopter;
        heliButton.helicopterManager = helicopterUpgradeManager;
        heliButton.helicopterHealth = helicopterHealth;
        heliButton.helicopterDamage = helicopterDamage;
    }

    private GameObject CreateButton(Transform parent, Vector2 anchoredPosition, string label)
    {
        GameObject buttonGO = new("Button");
        buttonGO.transform.SetParent(parent);
        Button button = buttonGO.AddComponent<Button>();
        Image image = buttonGO.AddComponent<Image>();
        image.color = Color.white;
        Text text = new("Text");
        text.transform.SetParent(buttonGO.transform);
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        text.alignment = TextAnchor.MiddleCenter;
        text.text = label;
        RectTransform rect = button.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(120f, 40f);
        rect.anchorMin = new Vector2(0.5f, 0f);
        rect.anchorMax = new Vector2(0.5f, 0f);
        rect.anchoredPosition = anchoredPosition;
        RectTransform textRect = text.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
        return buttonGO;
    }

    private void Update()
    {
        if (unitHealth != null && healthSlider != null)
        {
            healthSlider.value = (float)unitHealth.currentHealth / unitHealth.maxHealth;
        }
    }
}
