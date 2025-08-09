using UnityEngine;

/// <summary>
/// Centralised audio playback for common game events.
/// </summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Tooltip("Sound played when a unit shoots")]
    public AudioClip shootClip;
    [Tooltip("Sound played on explosions")]
    public AudioClip explosionClip;
    [Tooltip("Sound played on upgrades")]
    public AudioClip upgradeClip;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// Play the shooting sound effect.
    /// </summary>
    public void PlayShoot()
    {
        PlayClip(shootClip);
    }

    /// <summary>
    /// Play the explosion sound effect.
    /// </summary>
    public void PlayExplosion()
    {
        PlayClip(explosionClip);
    }

    /// <summary>
    /// Play the upgrade sound effect.
    /// </summary>
    public void PlayUpgrade()
    {
        PlayClip(upgradeClip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
