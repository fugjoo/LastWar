using UnityEngine;

/// <summary>
/// Spawns boss prefabs at set intervals and scales their health and damage.
/// </summary>
public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public float spawnInterval = 30f;
    private float timer;
    private int spawnCount = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBoss();
            timer = 0f;
        }
    }

    private void SpawnBoss()
    {
        spawnCount++;
        GameObject boss = Instantiate(bossPrefab, transform.position, transform.rotation);

        Health health = boss.GetComponent<Health>();
        if (health != null)
        {
            health.maxHealth += spawnCount * 100;
            health.currentHealth = health.maxHealth;
        }

        Attack attack = boss.GetComponent<Attack>();
        if (attack != null)
        {
            attack.damage += spawnCount * 10;
        }
    }
}
