using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData
{
    public Card CardVisual;
    public List<Skill> CardSkillList;
    public Action<CardEventTrigger, CardData> OnTrigger;

    public void Trigger(CardEventTrigger trigger)
    {
        OnTrigger?.Invoke(trigger, this);
    }
}
