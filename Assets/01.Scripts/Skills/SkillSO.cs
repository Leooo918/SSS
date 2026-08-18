using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SkillSO")]
public class SkillSO : ScriptableObject
{
    public int SkillIndex;
    public string SkillName;
    public Skill Skill;

    public List<SkillStat> StatList;

    private string _prevSkillName;

    public void OnValidate()
    {
        if (_prevSkillName == SkillName)
        {
            return;
        }

        _prevSkillName = SkillName;
        try
        {
            Type type = Type.GetType(SkillName);
            if (type != null)
            {
                Skill = Activator.CreateInstance(type) as Skill;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }
}
