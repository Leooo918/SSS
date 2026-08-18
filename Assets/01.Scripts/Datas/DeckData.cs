using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeckData
{
    public List<CardData> ContainCardList { get; private set; }
    public int MaxCardCount { get; private set; }

    public List<CardData> HandsCardList = new List<CardData>(); //have to search hands
    public List<CardData> ShuffledCard = new List<CardData>();  //can search shuffled card
    public List<CardData> UsedCardList = new List<CardData>();  //can search used card 

    public Action<CardEventTrigger, CardData> OnTrigger;


    #region For Game

    public void SuffleCard(bool shuffleWithUsedCard = false)
    {
        ShuffledCard = shuffleWithUsedCard ? UsedCardList : ContainCardList;
        int cardCount = ShuffledCard.Count;

        for (int i = 0; i < cardCount; i++)
        {
            int a = Random.Range(0, cardCount);
            int b = Random.Range(0, cardCount);

            CardData temp = ShuffledCard[a];
            ShuffledCard[a] = ShuffledCard[b];
            ShuffledCard[b] = temp;
        }
    }

    public CardData DrawCard(bool ignoreDrawTrigger = false)
    {
        //Shuffle when use all
        if (ShuffledCard.Count == 0)
        {
            SuffleCard(true);
        }

        //If there is no card to shuffle just return null
        if (ShuffledCard.Count == 0 || ShuffledCard[0] == null)
        {
            return null;
        }

        CardData card = ShuffledCard[0];
        HandsCardList.Add(card);
        if (ignoreDrawTrigger == false)
        {
            OnTrigger?.Invoke(CardEventTrigger.OnDrawCard, card);
            card.Trigger(CardEventTrigger.OnDrawCard);
        }
        return card;
    }

    public void ForceDrawCard(CardData card, bool ignoreCardEffect = false)
    {
        HandsCardList.Add(card);

        if (ignoreCardEffect == false)
        {
            OnTrigger?.Invoke(CardEventTrigger.OnDrawCard, card);
            card.Trigger(CardEventTrigger.OnDrawCard);
        }
    }

    public void UseCard(CardData card, bool checkHand, bool ignoreCardEffect = false)
    {
        if (checkHand == false || HandsCardList.ContainsExt(card))
        {
            if (ignoreCardEffect == false)
            {
                OnTrigger?.Invoke(CardEventTrigger.BeforeUseCard, card);
                card.Trigger(CardEventTrigger.BeforeUseCard);
            }

            //효과 적용시켜

            RemoveCardOnHand(card);

            if (ignoreCardEffect == false)
            {
                OnTrigger?.Invoke(CardEventTrigger.AfterUseCard, card);
                card.Trigger(CardEventTrigger.AfterUseCard);
            }
        }
        else
        {
            Debug.LogWarning($"You tried to use card not on your hands");
        }
    }

    public void RemoveCardOnHand(CardData card, bool ignoreCardEffect = false)
    {
        UsedCardList.Add(card);
        HandsCardList.RemoveExt(card);

        if (ignoreCardEffect == false)
        {
            OnTrigger?.Invoke(CardEventTrigger.AfterUseCard, card);
            card.Trigger(CardEventTrigger.AfterUseCard);
        }
    }

    #endregion


    #region For Deck

    public void GetCardOnDeck(CardData card, bool ignoreCardEffect = false)
    {
        ContainCardList.Add(card);

        if (ignoreCardEffect == false)
        {
            OnTrigger?.Invoke(CardEventTrigger.OnGetCardOnDeck, card);
            card.Trigger(CardEventTrigger.OnGetCardOnDeck);
        }
    }

    public void RemoveCardOnDeck(CardData card, bool ignoreCardEffect = false)
    {
        ContainCardList.RemoveExt(card);
        HandsCardList.RemoveExt(card);
        ShuffledCard.RemoveExt(card);
        UsedCardList.RemoveExt(card);

        if (ignoreCardEffect == false)
        {
            OnTrigger?.Invoke(CardEventTrigger.OnRemoveCardFromDeck, card);
            card.Trigger(CardEventTrigger.OnRemoveCardFromDeck);
        }
    }

    #endregion


    public DeckData(int maxCardCount, List<CardData> initCard)
    {
        ContainCardList = initCard;
        MaxCardCount = maxCardCount;
    }
}
