using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoSingleton<CharacterManager>
{
    public Dictionary<CharacterType, Color> PersonalColorDictionary = new Dictionary<CharacterType, Color>();
}
