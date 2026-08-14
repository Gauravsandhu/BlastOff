using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public GameState CurrentState {get; private set;}
    public int losingPlayer { get; private set; }

    public static event Action<GameState> OnStateChanged;

    [SerializeField] private int roundsToWin = 8;
    public int player1Score = 0;
    public int player2Score = 0;

    // Respawn Variables
    [SerializeField] private Transform player1SpawnPoint;
    [SerializeField] private Transform player2SpawnPoint;
    [SerializeField] private GameObject player1Cannon;
    [SerializeField] private GameObject player2Cannon;

    public void RespawnCannons()
    {
        player1Cannon.transform.position = player1SpawnPoint.position;
        player2Cannon.transform.position = player2SpawnPoint.position;
        player1Cannon.SetActive(true);
        player2Cannon.SetActive(true);
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }



    private void Start()
    {
        ChangeState(GameState.RoundLive);
    }

    public void ChangeState(GameState newState)

    {
        if(newState == GameState.RoundLive)
        {
            RespawnCannons();
        }
        CurrentState = newState;
        
        Debug.Log($"State Changed to : {newState}");
        OnStateChanged?.Invoke(newState);
    }


    public void RegisterRoundWin(int winningPlayer)
    {
        losingPlayer = (winningPlayer == 1) ? 2 : 1;

        if (winningPlayer == 1)
        {
            player1Score++;
        }
        else
        {
            player2Score++;
        }

        if (player1Score >= roundsToWin || player2Score >= roundsToWin)
        {
            ChangeState(GameState.MatchEnd);
        }
        else
        {
            ChangeState(GameState.PowerUpSelect);
        }
    }

}
