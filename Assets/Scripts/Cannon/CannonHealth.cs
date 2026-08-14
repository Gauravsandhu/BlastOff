using UnityEngine;


public class CannonHealth : MonoBehaviour
{
    
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    // [SerializeField] private int playerNumber = 1;

    private void Awake()
    {
        currentHealth = maxHealth;
    }






}