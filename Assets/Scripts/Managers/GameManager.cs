using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public GameState CurrentState {get; private set;}

    public static event Action<GameState> OnStateChanged;

    [SerializeField] private int roundsToWin = 8;
    public int player1Score = 0;
    public int player2Score = 0;

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
        CurrentState = newState;
        Debug.Log($"State Changed to : {newState}");
        OnStateChanged?.Invoke(newState);
    }


    public void RegisterRoundWin(int winningPlayer)
    {
        if(winningPlayer == 1)
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
            ChangeState(GameState.RoundEnd);
        }
    }

}
