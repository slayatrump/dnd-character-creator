using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;

public class Armor : MonoBehaviour
{
    public string Name;

    public ArmorType ArmorType;

    public int Cost;

    public int BaseArmorClass;
    public enum DexBonusType { FullModAdded, MaxOfPlusTwo, NoModAdded};
    public DexBonusType DexBonus;

    public int StrengthRequirement;

    public bool StealthDisadvantage;

    public int Weight;
}
