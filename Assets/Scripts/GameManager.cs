using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Central game manager tracking score, coins and level progression.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Tooltip("UI text element showing the current coin balance.")]
    public Text coinText;

    [Tooltip("Current score accumulated by the player.")]
    public int score;
    [Tooltip("Current level number.")]
    public int level = 1;
    [Tooltip("Total coins available to spend.")]
    public int coins;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        UpdateCoinUI();
    }

    /// <summary>
    /// Increase the player's score.
    /// </summary>
    public void AddScore(int amount)
    {
        score += amount;
    }

    /// <summary>
    /// Add coins and refresh the UI counter.
    /// </summary>
    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI();
    }

    /// <summary>
    /// Attempt to spend coins. Returns true if successful.
    /// </summary>
    public bool SpendCoins(int amount)
    {
        if (coins < amount)
        {
            return false;
        }
        coins -= amount;
        UpdateCoinUI();
        return true;
    }

    /// <summary>
    /// Progress to the next level.
    /// </summary>
    public void AdvanceLevel()
    {
        level += 1;
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = coins.ToString();
        }
    }
}
