using System.Collections.Generic;
using UnityEngine;

public static class ListExtention
{
    public static bool ContainsExt<T>(this List<T> list, T element, bool defaultValue = false)
    {
        if(list == null) return defaultValue;
        return list.Contains(element);
    }

    public static void RemoveExt<T>(this List<T> list, T element)
    {
        if (list.ContainsExt(element) == false) return;
        list.Remove(element);
    }

    public static void AddExt<T>(this List<T> list, T element)
    {
        if (list.ContainsExt(element)) return;
        list.Add(element);
    }
}
