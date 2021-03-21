using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;

public class FirstLevelClass : MonoBehaviour
{
    //Each prefab should be named "[name of class] Class Object" to stay in line with races

    //What youd expect
    public string Name;

    //1d12 has a hit die type of d12, but this can be input with 12 to make hp calc easier later down the line
    public int HitDieType;

    //Split by a semicolon in the excel sheet
    public ArmorType[] ArmorProficiencies;

    //This one cant be an enum since it would have to cover every possible weapon (which is too much work)
    public string[] WeaponProficiencies;

    //Saving throws from classes add the proficiency bonus to saving throws
    public AbilityScoreType SavingThrow1;
    public AbilityScoreType SavingThrow2;

    public int SkillProficiencies;
    public SkillType[] SkillProficiencyChoices;

    //Each choice is separated by a semicolon in the excel sheet, any that doesnt have a second or more option is just a guaranteed
    //This part is weird in the inspector but it works, trust me, theoretically each choice group should be displayed in bullet points (or something similar)
    [System.Serializable]
    public class EquipmentChoices
    {
        public string[] ChoicesInGroup;
    }
    public EquipmentChoices[] EquipmentChoiceGroups;

    public string[] ClassFeatures;

    //This does not need to be displayed to the user on class selection, its mostly here to tell the program if it should skip the spell selection scene
    public bool CastsSpellsAtFirstLevel;
}
