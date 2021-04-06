using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;

public class Spell : MonoBehaviour
{
    public string SpellName;

    public int SpellLevel;

    public SchoolTypes SchoolType;

    public string CastingTime;

    public string Range;

    public List<string> Components;

    public string Duration;

    //Putting this in its own class structure allows class level to be grabbed individually without touching the class name if it is ever needed
    [System.Serializable]
    public class ClassPrerequisite
    {
        public ClassTypes Class;
        public int ClassLevel;
    }

    public List<ClassPrerequisite> Classes;

    //Using a list here to split descriptions by sections, such as if it has bullet points like for prestidigitation
    public List<string> DescriptionParagraphs;


}
