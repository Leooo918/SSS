using System;
using UnityEngine;

[Serializable]
public class SkillStat
{
    public StatType UsingSkill;
    public bool Is;
    //Expression 같은걸 만들어서 붙혀주는걸로ㄱㄱ

    public int GetFinalValue(Card statCalculater)
    {
        return 0;
    }
}


