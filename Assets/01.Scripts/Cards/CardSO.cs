using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "SO/CardSO")]
public class CardSO : ScriptableObject
{
    public int CardIndex;

    public string CardName;
    public string CardDescription;
    public CharacterType CharacterType;
    public CardType CardType;   //may be dispose

    public CardData CardData;
}
