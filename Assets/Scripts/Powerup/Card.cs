using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer cardImageRenderer;
    [SerializeField] TextMeshPro cardTextRenderer;

    private CardSO cardInfo;  // why do we need this?

    public void Setup(CardSO card)
    {
     cardInfo = card;
     cardImageRenderer.sprite = card.cardImage;
     cardTextRenderer.text = card.cardText;   
    }


    void OnMouseDown()
    {
        CardManager.Instance.SelectCard(cardInfo);
        Debug.Log("You Clicked a card!");
        
    }
}
