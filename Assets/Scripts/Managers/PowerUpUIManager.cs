using UnityEngine;

public class PowerUpUIManager : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpPanel;


    private void OnEnable()
    {
        GameManager.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        GameManager.OnStateChanged -= HandleStateChanged;
    }

    private void HandleStateChanged(GameState newState)
    
    {
         Debug.Log("PowerupUIManager heard state: " + newState);
        if(newState  == GameState.PowerupSelect)
        {
            PowerUpPanel.SetActive(true);
        }
        else
        {
            PowerUpPanel.SetActive(false);
        }
    }
}
