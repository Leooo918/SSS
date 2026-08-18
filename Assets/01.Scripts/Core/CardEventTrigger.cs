using UnityEngine;

public enum CardEventTrigger
{
    //For Game
    OnDrawCard = 1,             //Already draw card and card is on your hands.
    BeforeUseCard = 2,          //Have to use card. After this trigger card effect will be used.
    AfterUseCard = 4,           //Already card effect is used and remove.
    OnRemoveCard = 8,           //After just remove card not after use card. (if you need to cancel remove card just add card again)
    OnPassTurn = 16,            //Have to pass turn but not yet.

    //For Deck  
    OnGetCardOnDeck = 64,       //After get card on deck.
    OnRemoveCardFromDeck = 128, //After remove card from deck.
}
