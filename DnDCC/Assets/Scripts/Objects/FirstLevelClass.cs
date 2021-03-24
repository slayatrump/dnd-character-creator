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
    public TMP_Dropdown skillSelection3;
    public TMP_Dropdown skillSelection4;

    private Vector2 skillSelectionPos1;
    private Vector2 skillSelectionPos2;
    private Vector2 skillSelectionPos3;
    private Vector2 skillSelectionPos4;

    private TMP_Text skillChoice1;
    private TMP_Text skillChoice2;
    private TMP_Text skillChoice3;
    private TMP_Text skillChoice4;

    private Vector2 skillChoicePos1;
    private Vector2 skillChoicePos2;
    private Vector2 skillChoicePos3;
    private Vector2 skillChoicePos4;

    private TMP_Text className;
    private TMP_Text currentRaceName;
    private TMP_Text hitDiceInfo;
    private TMP_Text savingThrowsInfo;
    private TMP_Text weaponProficienciesInfo;
    private TMP_Text armorProficienciesInfo;

    private SelectionController sc;

    List<string> skills;

    private void Start()
    {
        skillSelection1.options.Clear();
        skillSelection2.options.Clear();

        SettingTextFields();

        skillChoice1 = GameObject.Find("SkillProficienciesInfo1").GetComponent<TMP_Text>();
        skillChoice2 = GameObject.Find("SkillProficienciesInfo2").GetComponent<TMP_Text>();
        skillChoice3 = GameObject.Find("SkillProficienciesInfo3").GetComponent<TMP_Text>();
        skillChoice4 = GameObject.Find("SkillProficienciesInfo4").GetComponent<TMP_Text>();
        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();

        skillChoicePos1 = new Vector2(skillChoice1.gameObject.transform.position.x, skillChoice1.gameObject.transform.position.y);
        skillChoicePos2 = new Vector2(skillChoice2.gameObject.transform.position.x, skillChoice2.gameObject.transform.position.y);
        skillChoicePos3 = new Vector2(skillChoice3.gameObject.transform.position.x, skillChoice3.gameObject.transform.position.y);
        skillChoicePos4 = new Vector2(skillChoice4.gameObject.transform.position.x, skillChoice4.gameObject.transform.position.y);

        skillSelectionPos1 = new Vector2(skillSelection1.gameObject.transform.position.x, skillSelection1.gameObject.transform.position.y);
        skillSelectionPos2 = new Vector2(skillSelection2.gameObject.transform.position.x, skillSelection2.gameObject.transform.position.y);
        skillSelectionPos3 = new Vector2(skillSelection3.gameObject.transform.position.x, skillSelection3.gameObject.transform.position.y);
        skillSelectionPos4 = new Vector2(skillSelection4.gameObject.transform.position.x, skillSelection4.gameObject.transform.position.y);

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

                    NumberOfSkillSelections();

                    break;
                }
            case "s2":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]
                        + ", " + this.WeaponProficiencies[2] + ", " + this.WeaponProficiencies[3] + ", " + this.WeaponProficiencies[4];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    NumberOfSkillSelections();

                    break;
                }
        }
    }

    private void NumberOfSkillSelections()
    {
        switch (SkillProficiencies)
        {
            case 1:
                {
                    skillChoice2.gameObject.SetActive(false);
                    skillChoice3.gameObject.SetActive(false);
                    skillChoice4.gameObject.SetActive(false);

                    skillSelection2.gameObject.SetActive(false);
                    skillSelection3.gameObject.SetActive(false);
                    skillSelection4.gameObject.SetActive(false);

                    skillChoice1.gameObject.transform.position = skillChoicePos2;
                    skillSelection1.gameObject.transform.position = skillSelectionPos2;

                    Dropmenu1();

                    SkillSelected1(skillSelection1);

                    skillSelection1.onValueChanged.AddListener(delegate { SkillSelected1(skillSelection1); });
                    break;
                }
            case 2:
                {
                    skillChoice2.gameObject.SetActive(true);
                    skillChoice3.gameObject.SetActive(false);
                    skillChoice4.gameObject.SetActive(false);

                    skillSelection2.gameObject.SetActive(true);
                    skillSelection3.gameObject.SetActive(false);
                    skillSelection4.gameObject.SetActive(false);

                    skillChoice1.gameObject.transform.position = skillChoicePos2;
                    skillSelection1.gameObject.transform.position = skillSelectionPos2;
                    skillChoice2.gameObject.transform.position = skillChoicePos3;
                    skillSelection2.gameObject.transform.position = skillSelectionPos3;

                    Dropmenu1();
                    Dropmenu2();

                    SkillSelected1(skillSelection1);
                    SkillSelected2(skillSelection2);

                    skillSelection1.onValueChanged.AddListener(delegate { SkillSelected1(skillSelection1); });
                    skillSelection2.onValueChanged.AddListener(delegate { SkillSelected2(skillSelection2); });
                    break;
                }
            case 3:
                {
                    skillChoice2.gameObject.SetActive(true);
                    skillChoice3.gameObject.SetActive(true);
                    skillChoice4.gameObject.SetActive(false);

                    skillSelection2.gameObject.SetActive(true);
                    skillSelection3.gameObject.SetActive(true);
                    skillSelection4.gameObject.SetActive(false);

                    skillChoice1.gameObject.transform.position = skillChoicePos2;
                    skillSelection1.gameObject.transform.position = skillSelectionPos2;
                    skillChoice2.gameObject.transform.position = skillChoicePos3;
                    skillSelection2.gameObject.transform.position = skillSelectionPos3;
                    skillChoice3.gameObject.transform.position = skillChoicePos4;
                    skillSelection3.gameObject.transform.position = skillSelectionPos4;

                    Dropmenu1();
                    Dropmenu2();
                    Dropmenu3();

                    SkillSelected1(skillSelection1);
                    SkillSelected2(skillSelection2);
                    SkillSelected3(skillSelection3);

                    skillSelection1.onValueChanged.AddListener(delegate { SkillSelected1(skillSelection1); });
                    skillSelection2.onValueChanged.AddListener(delegate { SkillSelected2(skillSelection2); });
                    skillSelection3.onValueChanged.AddListener(delegate { SkillSelected3(skillSelection3); });
                    break;
                }
            case 4:
                {
                    skillChoice2.gameObject.SetActive(true);
                    skillChoice3.gameObject.SetActive(true);
                    skillChoice4.gameObject.SetActive(true);

                    skillSelection2.gameObject.SetActive(true);
                    skillSelection3.gameObject.SetActive(true);
                    skillSelection4.gameObject.SetActive(true);

                    skillChoice1.gameObject.transform.position = skillChoicePos1;
                    skillSelection1.gameObject.transform.position = skillSelectionPos1;
                    skillChoice2.gameObject.transform.position = skillChoicePos2;
                    skillSelection2.gameObject.transform.position = skillSelectionPos2;
                    skillChoice3.gameObject.transform.position = skillChoicePos3;
                    skillSelection3.gameObject.transform.position = skillSelectionPos3;
                    skillChoice4.gameObject.transform.position = skillChoicePos4;
                    skillSelection4.gameObject.transform.position = skillSelectionPos4;

                    Dropmenu1();
                    Dropmenu2();
                    Dropmenu3();
                    Dropmenu4();

                    SkillSelected1(skillSelection1);
                    SkillSelected2(skillSelection2);
                    SkillSelected3(skillSelection3);
                    SkillSelected4(skillSelection4);

                    skillSelection1.onValueChanged.AddListener(delegate { SkillSelected1(skillSelection1); });
                    skillSelection2.onValueChanged.AddListener(delegate { SkillSelected2(skillSelection2); });
                    skillSelection3.onValueChanged.AddListener(delegate { SkillSelected3(skillSelection3); });
                    skillSelection4.onValueChanged.AddListener(delegate { SkillSelected4(skillSelection4); });
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
    private void Dropmenu3()
    {
        foreach (string sk in skills)
        {
            skillSelection3.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }

    private void Dropmenu4()
    {
        foreach (string sk in skills)
        {
            skillSelection4.options.Add(new TMP_Dropdown.OptionData() { text = sk });
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
    private void SkillSelected3(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        skillChoice3.text = dropdownItem.options[index].text;
        skillSelection3.GetComponentInChildren<TMP_Text>().text = skillChoice3.text;

    }
    private void SkillSelected4(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        skillChoice4.text = dropdownItem.options[index].text;
        skillSelection4.GetComponentInChildren<TMP_Text>().text = skillChoice4.text;

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
