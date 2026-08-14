using System.IO;
using UnityEngine;


[CreateAssetMenu(fileName ="New Card",menuName ="Card")]

public class CardSO : ScriptableObject
{
    public Sprite cardImage;  // image of the card
    public string cardText;   // text of the card
    public float effectValue;  //the value of the effect
    public bool isUnique; // controls if we are able to get this card many times or not
    public int unlockLevel;
    public CardEffect effectType; // effect type

    public enum CardEffect
    {
        DamageIncrease,
        HealthIncrease,
        SpeedIncrease,
        ShotSpeed,
        ReloadSpeed
    }
 
};
