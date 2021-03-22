using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalEnums
{
    //This is used for quick access, if you make an enum that will be used in multiple areas put it here 
    //and use "using GlobalEnums;" for the script youre working on
    public enum SkillType { Athletics, Acrobatics, Sleight_Of_Hand, Stealth, Arcana, History, Investigation, Nature, Religion, Animal_Handling, 
        Insight, Medicine, Perception, Survival, Deception, Intimidation, Performance, Persuasion};

    public enum AbilityScoreType { Str, Dex, Con, Int, Wis, Cha};

    public enum ArmorType { Light_Armor, Medium_Armor, Heavy_Armor, Shield, None};
}
