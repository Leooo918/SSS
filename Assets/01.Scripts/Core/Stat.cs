using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public int BaseValue { get; private set; }
    public bool IsPercentageStat { get; private set; }
    public Dictionary<string, int> Modifiers { get; private set; }


    public int GetFinalValue()
    {
        int finalValue = BaseValue;
        foreach (var modifier in Modifiers.Values)
        {
            finalValue += modifier;
        }
        return finalValue;
    }

    public void AddModifier(string key, int value)
    {
        if (Modifiers.ContainsKey(key))
        {
            Modifiers[key] += value;
        }
        else
        {
            Modifiers.Add(key, value);
        }
    }

    public void RemoveModifier(string key)
    {
        if (Modifiers.ContainsKey(key))
        {
            Modifiers.Remove(key);
        }
    }

    public Stat(int baseValue)
    {
        BaseValue = baseValue;
        Modifiers = new Dictionary<string, int>();
    }
}

//이 아래쪽은 좀 더 고민해보고 사용하자
public struct StatKey
{
    public StatModifierType ModifyType;
    public string Key;
}

public enum StatModifierType
{

}
