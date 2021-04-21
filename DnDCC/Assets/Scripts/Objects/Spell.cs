using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GlobalEnums;
using TMPro;

public class Spell : SpellListController
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

    public TMP_Text spellName, spellSchool, spellCast, spellRange, spellComp, spellDesc;

    public Button button;

    private void Awake()
    {
        SetUI();
        button = GameObject.Find("MoveOnButton").GetComponent<Button>();
        button.interactable = false;

        GameObject[] cantrips = GameObject.FindGameObjectsWithTag("CantripCheckbox");
        GameObject[] spells = GameObject.FindGameObjectsWithTag("SpellCheckbox");

        if (SpellSelectionScript.maxSpells == 0)
        {
            foreach (GameObject s in spells)
            {
                if (!s.GetComponent<Toggle>().isOn)
                {
                    s.GetComponent<Toggle>().interactable = false;
                }
            }
        }

        if (SpellSelectionScript.maxCants == 0)
        {
            foreach (GameObject c in cantrips)
            {
                if (!c.GetComponent<Toggle>().isOn)
                {
                    c.GetComponent<Toggle>().interactable = false;
                }
            }
        }
    }

    public void DisplayInfo(bool isActive)
    {
        if (isActive)
        {
            spellComp.text = "";
            spellDesc.text = "";

            spellName.text = this.SpellName;
            spellSchool.text = this.SchoolType.ToString();
            spellCast.text = this.CastingTime;
            spellRange.text = this.Range;

            foreach (string element in Components)
            {
                int max = Components.Count;

                if (max == 2)
                {
                    spellComp.text += element + "\n";
                }
                else
                {
                    spellComp.text += element;
                }
            }

            foreach (string element in DescriptionParagraphs)
            {
                spellDesc.text += element;
            }

            if (SpellLevel == 0)
            {
                SpellSelectionScript.maxCants -= 1;
                GameObject.Find("Cantrips Number").GetComponent<TMP_Text>().text = $"{SpellSelectionScript.maxCants}";
                SettingSavedCantrips(this.SpellName);
            }
            else if (SpellLevel == 1)
            {
                SpellSelectionScript.maxSpells -= 1;
                GameObject.Find("1L Number").GetComponent<TMP_Text>().text = $"{SpellSelectionScript.maxSpells}";
                SettingSavedSpells(this.SpellName);
            }
        }
        else if (!isActive)
        {
            spellComp.text = "";
            spellDesc.text = "";

            spellName.text = "";
            spellSchool.text = "";
            spellCast.text = "";
            spellRange.text = "";

            if (SpellLevel == 0)
            {
                SpellSelectionScript.maxCants += 1;
                GameObject.Find("Cantrips Number").GetComponent<TMP_Text>().text = $"{SpellSelectionScript.maxCants}";
                RemovingSavedCantrips(this.SpellName);
            }
            else if (SpellLevel == 1)
            {
                SpellSelectionScript.maxSpells += 1;
                GameObject.Find("1L Number").GetComponent<TMP_Text>().text = $"{SpellSelectionScript.maxSpells}";
                RemovingSavedSpells(this.SpellName);
            }
        }

        if (SpellSelectionScript.maxCants == 0)
        {
            foreach (GameObject c in cantrips)
            {
                if (!c.GetComponent<Toggle>().isOn)
                {
                    c.GetComponent<Toggle>().interactable = false;
                }
            }
        }
        else if (SpellSelectionScript.maxCants > 0)
        {
            foreach (GameObject c in cantrips)
            {
                if (!c.GetComponent<Toggle>().isOn)
                {
                    c.GetComponent<Toggle>().interactable = true;
                }
            }
        }

        if (SpellSelectionScript.maxSpells == 0)
        {
            foreach (GameObject s in spells)
            {
                if (!s.GetComponent<Toggle>().isOn)
                {
                    s.GetComponent<Toggle>().interactable = false;
                }
            }
        }
        else if (SpellSelectionScript.maxSpells > 0)
        {
            foreach (GameObject s in spells)
            {
                if (!s.GetComponent<Toggle>().isOn)
                {
                    s.GetComponent<Toggle>().interactable = true;
                }
            }
        }

        if(SpellSelectionScript.maxSpells == 0 
            && SpellSelectionScript.maxCants == 0)
        {
            button.interactable = true;

        }
        else
        {
            button.interactable = false;

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

    public void SettingSavedSpells(string Spell)
    {
        SaveManager.instance.gameData.spellList.Add(Spell);
    }
    public void SettingSavedCantrips(string Cantrip)
    {
        SaveManager.instance.gameData.cantripList.Add(Cantrip);
    }
    public void RemovingSavedSpells(string Spell)
    {
        SaveManager.instance.gameData.spellList.Remove(Spell);
    }
    public void RemovingSavedCantrips(string Cantrip)
    {
        SaveManager.instance.gameData.cantripList.Remove(Cantrip);
    }

    public static void SavingSpellData()
    {
        SaveManager.instance.Save();
    }
}
