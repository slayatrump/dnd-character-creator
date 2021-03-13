using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race : MonoBehaviour
{
    public enum ASType { Str, Dex, Con, Int, Wis, Cha, All, ChoicePool};
    public enum SizeType { Small, Medium, Large };

    [System.Serializable]
    public class ASIncrease
    {
        public ASType AbilityScore;
        public int IncreaseBy;
    }

    public ASIncrease AS1;
    public ASIncrease AS2;

    public SizeType Size;

    public int Speed;

    public string[] Languages;

    public string[] Features;
}
