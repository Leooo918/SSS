using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoSingleton<CardManager>
{
    public DeckData DeckData { get; private set; }

    [field : SerializeField] public Card CardPrefab { get; private set; }
    [field: SerializeField] public Transform CardParent { get; private set; }


    private List<CardData> _playerCardDataList = new List<CardData>();

    public void InitializeDeck(int handCount, List<CardData> cardData)
    {
        if(cardData == null)
        {
            return;
        }

        for(int i = 0; i < cardData.Count; i++)
        {
            Card card = Instantiate(CardPrefab, CardParent);
            card.gameObject.SetActive(false);
            cardData[i].CardVisual = card;

            _playerCardDataList.Add(cardData[i]);
        }
    }
}
