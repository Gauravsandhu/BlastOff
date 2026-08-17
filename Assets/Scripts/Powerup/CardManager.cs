using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    void Awake()
    {
        Instance = this;
    }
    [SerializeField] GameObject cardSelectionUI;
   [SerializeField] GameObject cardPrefab;

   [SerializeField] Transform cardPositionOne;
   [SerializeField] Transform cardPositionTwo;
   [SerializeField] Transform cardPositionThree;

   [SerializeField] List<CardSO> deck;

    [SerializeField] private CannonStats player1Stats;
    [SerializeField] private CannonStats player2Stats;

   List<CardSO> alreadySelectedCards = new List<CardSO>();

    private GameObject cardOne, cardTwo, cardThree;   // currently randomized cards


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
        if(GameState.PowerUpSelect == newState)
        {
            RandomizeNewCards();
            ShowCardSelection();
        }
        else
        {
            HideCardSelection();
        }
    }

    void Start()
    {
        RandomizeNewCards();
    }
   void RandomizeNewCards()
    {
        if(cardOne != null) Destroy(cardOne);
        if(cardTwo != null) Destroy(cardTwo);
        if(cardThree != null) Destroy(cardThree);

        List<CardSO> offeredCards = new List<CardSO>();

        List<CardSO> availableCards = new List<CardSO>(deck);
        availableCards.RemoveAll(card => card.isUnique && alreadySelectedCards.Contains(card));

        if(availableCards.Count < 3)
        {
            Debug.Log("Not enough cards available"); 
            return;
        }

        while(offeredCards.Count < 3){
            CardSO randomCard = availableCards[Random.Range(0,availableCards.Count)];

            if (!offeredCards.Contains(randomCard))
            {
                offeredCards.Add(randomCard);
            }
        }

        // Instantiates the cards with (CARDSO) at (position)
        cardOne = InstantiateCard(offeredCards[0], cardPositionOne);
        cardTwo = InstantiateCard(offeredCards[1], cardPositionTwo);
        cardThree = InstantiateCard(offeredCards[2], cardPositionThree);
    }

        GameObject InstantiateCard(CardSO cardSO, Transform position)
    {
        GameObject cardGO = Instantiate(cardPrefab, position.position, Quaternion.identity, position);

        Card card = cardGO.GetComponent<Card>();
        card.Setup(cardSO);
        return cardGO;
    }


     public void SelectCard(CardSO selectedCard)
    {
        if (!alreadySelectedCards.Contains(selectedCard))
        {
            alreadySelectedCards.Add(selectedCard);
        }
        Debug.Log("SelectCard called with: " + selectedCard.cardText);

        int losingPlayer = GameManager.Instance.losingPlayer;
        CannonStats targetStats = (losingPlayer == 1) ? player1Stats : player2Stats;
        ApplyEffect(selectedCard, targetStats);

        GameManager.Instance.ChangeState(GameState.RoundLive);
    }

    private void ApplyEffect(CardSO card, CannonStats stats)
{
    Debug.Log("Applying " + card.effectType + " to " + stats.gameObject.name);
    switch (card.effectType)
    {
        case CardSO.CardEffect.DamageIncrease:
            stats.damageMultiplier += card.effectValue;
            Debug.Log("New damageMultiplier: " + stats.damageMultiplier);
            break;
        case CardSO.CardEffect.SpeedIncrease:
            stats.moveSpeedMultiplier += card.effectValue;
            Debug.Log("New moveSpeedMultiplier: " + stats.moveSpeedMultiplier);
            break;
        case CardSO.CardEffect.ShotSpeed:
            stats.bulletSpeedMultiplier += card.effectValue;
            break;
        case CardSO.CardEffect.HealthIncrease:
            stats.healthMultiplier += card.effectValue;
            break;
    }
}



    public void ShowCardSelection()
    {
        cardSelectionUI.SetActive(true);
    }

    public void HideCardSelection()
    {
        cardSelectionUI.SetActive(false);
    }


    
}
