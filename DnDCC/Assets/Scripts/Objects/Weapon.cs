using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;

public class Weapon : MonoBehaviour
{
    //https://roll20.net/compendium/dnd5e/Weapons#content This has all the weapons listed

    public string WeaponName;

    public enum WeaponTypes { SimpleMelee, SimpleRanged, MartialMelee, MartialRanged};
    public WeaponTypes WeaponType;

    //Numcost is the number, Costtype is gp, sp, cp, etc.
    public int NumCost;
    public string CostType;

    //1d4, 2d6, 1d8, etc.
    public string Damage;
    public DamageTypes DamageType;

    public float Weight;

    public List<string> Properties;
}
