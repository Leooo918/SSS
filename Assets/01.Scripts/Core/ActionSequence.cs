using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionSequence
{
    public Dictionary<Action, int> SequenceDic;
    public List<Action> SequenceList;

    public ActionSequence()
    {
        SequenceList = new List<Action>();
        SequenceDic = new Dictionary<Action, int>();
    }

    public void AppendAction(Action action, int delay = 0)
    {
        SequenceList.Add(action);
        SequenceDic[action] = delay;
    }

    public void RemoveAction(Action action)
    {
        SequenceList.Remove(action);
        SequenceDic.Remove(action);
    }

    public void Play()
    {

    }
}
