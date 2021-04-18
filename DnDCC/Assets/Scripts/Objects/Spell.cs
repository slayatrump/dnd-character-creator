using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalEnums;
using TMPro;

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

    TMP_Text spellName, spellSchool, spellCast, spellRange, spellComp, spellDesc;

    private void Awake()
    {
        SetUI();
    }

    public void DisplayInfo()
    {
        spellName.text = this.SpellName;
        spellSchool.text = this.SchoolType.ToString();
        spellCast.text = this.CastingTime;
        spellRange.text = this.Range;

        foreach(string element in Components)
        {
            spellComp.text += this.Components.ToString();
        }

        foreach(string element in DescriptionParagraphs)
        {
            spellDesc.text += this.DescriptionParagraphs.ToString();
        }
    }

    public void SetUI()
    {
        spellName = GameObject.Find("NText").GetComponent<TMP_Text>();
        spellSchool = GameObject.Find("SText").GetComponent<TMP_Text>();
        spellCast = GameObject.Find("CTText").GetComponent<TMP_Text>();
        spellRange = GameObject.Find("RText").GetComponent<TMP_Text>();
        spellComp = GameObject.Find("CompText").GetComponent<TMP_Text>();
        spellDesc = GameObject.Find("DText").GetComponent<TMP_Text>();
    }
}
