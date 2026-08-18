using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public Card Owner { get; private set; }
    public Card Target { get; private set; }


    public abstract void UseSkill(List<SkillStat> skillStatList);
}
