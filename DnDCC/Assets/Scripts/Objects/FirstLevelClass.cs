using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalEnums;
using UnityEngine.EventSystems;

public class FirstLevelClass : MonoBehaviour
{
    #region Class Prefab Info
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
    #endregion

    #region Class UI Functionality
    [Header("Class UI Functionality")]
    public TMP_Dropdown skillSelection1;
    public TMP_Dropdown skillSelection2;

    private TMP_Text className;
    private TMP_Text currentRaceName;
    private TMP_Text hitDiceInfo;
    private TMP_Text savingThrowsInfo;
    private TMP_Text weaponProficienciesInfo;
    private TMP_Text armorProficienciesInfo;

    private TMP_Text skillChoice1;
    private TMP_Text skillChoice2;

    private SelectionController sc;

    List<string> skills;

    private void Start()
    {
        skillSelection1.options.Clear();
        skillSelection2.options.Clear();

        SettingTextFields();

        skillChoice1 = GameObject.Find("SkillProficienciesInfo1").GetComponent<TMP_Text>();
        skillChoice2 = GameObject.Find("SkillProficienciesInfo2").GetComponent<TMP_Text>();
        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();

        skills = new List<string>();
    }

    public void ClassSelected()
    {
        sc.selected = EventSystem.current.currentSelectedGameObject.name;

        switch (sc.selected)
        {
            case "s1":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 + 
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]; 
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ",  " + this.ArmorProficiencies[1]
                        + ",  " + this.ArmorProficiencies[2];

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    Dropmenu1();
                    Dropmenu2();

                    SkillSelected1(skillSelection1);
                    SkillSelected2(skillSelection2);

                    skillSelection1.onValueChanged.AddListener(delegate { SkillSelected1(skillSelection1); });
                    skillSelection2.onValueChanged.AddListener(delegate { SkillSelected2(skillSelection2); });

                    break;
                }
        }
    }

    private void Dropmenu1()
    {
        foreach (string sk in skills)
        {
            skillSelection1.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }

    private void Dropmenu2()
    {
        foreach (string sk in skills)
        {
            skillSelection2.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }

    private void SkillSelected1(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        skillChoice1.text = dropdownItem.options[index].text;
        skillSelection1.GetComponentInChildren<TMP_Text>().text = skillChoice1.text;
    }

    private void SkillSelected2(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        skillChoice2.text = dropdownItem.options[index].text;
        skillSelection2.GetComponentInChildren<TMP_Text>().text = skillChoice2.text;

    }

    private void SettingTextFields()
    {
        className = GameObject.Find("ClassName").GetComponent<TMP_Text>();
        currentRaceName = GameObject.Find("CurrentRaceName").GetComponent<TMP_Text>();
        hitDiceInfo = GameObject.Find("HitDieTypeInfo").GetComponent<TMP_Text>();
        savingThrowsInfo = GameObject.Find("SavingThrowsInfo").GetComponent<TMP_Text>();
        weaponProficienciesInfo = GameObject.Find("WeaponProficienciesInfo").GetComponent<TMP_Text>();
        armorProficienciesInfo = GameObject.Find("ArmorProficienciesInfo").GetComponent<TMP_Text>();
    }
    #endregion
}
