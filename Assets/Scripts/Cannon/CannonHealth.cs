using UnityEngine;

public class CannonHealth : MonoBehaviour
{
    [SerializeField] private float baseMaxHealth = 100f;
    [SerializeField] private int playerNumber = 1;
    [SerializeField] private CannonStats stats;

    public float currentHealth;

    private void Awake()
    {
        currentHealth = baseMaxHealth * stats.healthMultiplier;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            int winner = (playerNumber == 1) ? 2 : 1;
            GameManager.Instance.RegisterRoundWin(winner);
            gameObject.SetActive(false);
        }
    }

    public void ResetHealth()
    {
        currentHealth = baseMaxHealth * stats.healthMultiplier;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}