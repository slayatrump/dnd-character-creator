using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalEnums;
using UnityEngine.EventSystems;
using System.Diagnostics;

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
    public static bool CastsSpellsAtFirstLevel;
    #endregion

    #region Class UI Functionality

    #region Skill Selection UI Sutff
    [Header("Skill Selection Dropmenus")]
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

    List<string> skills = new List<string>();
    #endregion

    #region Equipment Selection UI Stuff
    [Header("Equipment Selection Dropmenus")]
    public TMP_Dropdown equipmentSelection1;
    public TMP_Dropdown equipmentSelection2;
    public TMP_Dropdown equipmentSelection3;
    public TMP_Dropdown equipmentSelection4;
    public TMP_Dropdown equipmentSelection5;
    public TMP_Dropdown equipmentSelection6;

    private TMP_Text equipmentChoice1;
    private TMP_Text equipmentChoice2;
    private TMP_Text equipmentChoice3;
    private TMP_Text equipmentChoice4;
    private TMP_Text equipmentChoice5;
    private TMP_Text equipmentChoice6;

    private TMP_Text choiceText;

    private Vector2 equipmentChoicePos1;
    private Vector2 equipmentChoicePos2;
    private Vector2 equipmentChoicePos3;
    private Vector2 equipmentChoicePos4;
    private Vector2 equipmentChoicePos5;
    private Vector2 equipmentChoicePos6;

    private Vector2 choiceTextPos;

    List<string> e1 = new List<string>();
    List<string> e2 = new List<string>();
    List<string> e3 = new List<string>();
    List<string> e4 = new List<string>();
    List<string> e5 = new List<string>();
    List<string> e6 = new List<string>();

    int index;
    #endregion

    #region Class Info UI Stuff
    private TMP_Text className;
    private TMP_Text currentRaceName;
    private TMP_Text hitDiceInfo;
    private TMP_Text savingThrowsInfo;
    private TMP_Text weaponProficienciesInfo;
    private TMP_Text armorProficienciesInfo;
    private TMP_Text classFeaturesInfo;
    #endregion

    private SelectionController sc;

    private Button firstNext;

    Stopwatch watch = new Stopwatch();

    private void Awake()
    {
        firstNext = GameObject.Find("NextToSkills").GetComponent<Button>();
    }

    private void Start()
    {
        skillSelection1.options.Clear();
        skillSelection2.options.Clear();
        skillSelection3.options.Clear();
        skillSelection4.options.Clear();

        equipmentSelection1.options.Clear();
        equipmentSelection2.options.Clear();
        equipmentSelection3.options.Clear();
        equipmentSelection4.options.Clear();
        equipmentSelection5.options.Clear();
        equipmentSelection6.options.Clear();

        SettingTextFields();
        SettingOriginalPositions();

        firstNext.gameObject.SetActive(false);

        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();
    }

    public void ClassSelected()
    {
        watch.Start();

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
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2 )
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4 )
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 5)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 5 && index < 6)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

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
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 3)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 3 && index < 5)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 5 && index < 7)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 8)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 8 && index < 9)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s3":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ", " + this.ArmorProficiencies[1]
                        + ", " + this.ArmorProficiencies[2];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 5)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 5 && index < 7)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 9)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 9 && index < 10)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                            else if (index >= 10 && index < 11)
                            {
                                this.e6.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s4":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]
                        + ", " + this.WeaponProficiencies[2] + ", " + this.WeaponProficiencies[3] + ", " + this.WeaponProficiencies[4]
                        + ", " + this.WeaponProficiencies[5] + ", " + this.WeaponProficiencies[6] + ", " + this.WeaponProficiencies[7]
                        + ", " + this.WeaponProficiencies[8] + ", " + this.WeaponProficiencies[9];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ", " + this.ArmorProficiencies[1]
                        + ", " + this.ArmorProficiencies[2];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 5)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 5 && index < 6)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s5":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ", " + this.ArmorProficiencies[1]
                        + ", " + this.ArmorProficiencies[2] + ", " + this.ArmorProficiencies[3];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 8)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s6":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 5)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s7":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ", " + this.ArmorProficiencies[1]
                        + ", " + this.ArmorProficiencies[3] + ", " + this.ArmorProficiencies[3];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 8)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s8":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0] + ", " + this.ArmorProficiencies[1] 
                        + ", " + this.ArmorProficiencies[2];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 8)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s9":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]
                        + ", " + this.WeaponProficiencies[2] + ", " + this.WeaponProficiencies[3] + ", " + this.WeaponProficiencies[4];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1]
                         + ", " + this.ClassFeatures[2];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 7)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 8)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 8 && index < 9)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                            else if (index >= 9 && index < 10)
                            {
                                this.e6.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s10":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]
                        + ", " + this.WeaponProficiencies[2] + ", " + this.WeaponProficiencies[3] + ", " + this.WeaponProficiencies[4];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s11":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0] + ", " + this.ClassFeatures[1];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                            else if (index >= 7 && index < 8)
                            {
                                this.e5.Add(equ);
                                index++;
                            }
                            else if (index >= 8 && index < 9)
                            {
                                this.e6.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
            case "s12":
                {
                    className.text = "Class Name: " + this.Name;
                    currentRaceName.text = "Race: " + SaveManager.instance.gameData.raceName;
                    hitDiceInfo.text = "Hit Dice: d" + this.HitDieType.ToString();
                    savingThrowsInfo.text = "Saving Throws: \n" + this.SavingThrow1 +
                        " & " + this.SavingThrow2;
                    weaponProficienciesInfo.text = "Weapon Proficiencies: \n" + this.WeaponProficiencies[0] + ", " + this.WeaponProficiencies[1]
                        + ", " + this.WeaponProficiencies[2] + ", " + this.WeaponProficiencies[3] + ", " + this.WeaponProficiencies[4];
                    armorProficienciesInfo.text = "Armor Proficiencies: \n" + this.ArmorProficiencies[0];
                    classFeaturesInfo.text = this.Name + " Class Features: \n" + this.ClassFeatures[0];

                    ClearingLists();

                    foreach (SkillType sk in SkillProficiencyChoices)
                    {
                        this.skills.Add(sk.ToString());
                    }

                    foreach (EquipmentChoices eq in EquipmentChoiceGroups)
                    {
                        foreach (string equ in eq.ChoicesInGroup)
                        {
                            if (index >= 0 && index < 2)
                            {
                                this.e1.Add(equ);
                                index++;
                            }
                            else if (index >= 2 && index < 4)
                            {
                                this.e2.Add(equ);
                                index++;
                            }
                            else if (index >= 4 && index < 6)
                            {
                                this.e3.Add(equ);
                                index++;
                            }
                            else if (index >= 6 && index < 7)
                            {
                                this.e4.Add(equ);
                                index++;
                            }
                        }
                    }
                    index = 0;

                    NumberOfSkillSelections();
                    NumberOfEquipmentSelections();

                    break;
                }
        }

        firstNext.gameObject.SetActive(true);

        watch.Stop();
        UnityEngine.Debug.Log($"Execution Time: {watch.Elapsed.TotalSeconds} seconds");
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

                    SkillDropmenu1();

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

                    SkillDropmenu1();
                    SkillDropmenu2();

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

                    SkillDropmenu1();
                    SkillDropmenu2();
                    SkillDropmenu3();

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

                    SkillDropmenu1();
                    SkillDropmenu2();
                    SkillDropmenu3();
                    SkillDropmenu4();

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

    private void NumberOfEquipmentSelections()
    {
        switch (this.EquipmentChoiceGroups.Length)
        {
            case 3:
                {
                    equipmentChoice4.gameObject.SetActive(false);
                    equipmentChoice5.gameObject.SetActive(false);
                    equipmentChoice6.gameObject.SetActive(false);

                    Vector2 newTextPos = new Vector2(choiceTextPos.x, choiceTextPos.y - 130);

                    choiceText.gameObject.transform.position = newTextPos;
                    equipmentChoice1.gameObject.transform.position = equipmentChoicePos2;
                    equipmentChoice2.gameObject.transform.position = equipmentChoicePos3;
                    equipmentChoice3.gameObject.transform.position = equipmentChoicePos4;

                    EquipmentDropMenu1();
                    EquipmentDropMenu2();
                    EquipmentDropMenu3();

                    EquipmentSelected1(equipmentSelection1);
                    EquipmentSelected2(equipmentSelection2);
                    EquipmentSelected3(equipmentSelection3);

                    equipmentSelection1.onValueChanged.AddListener(delegate { EquipmentSelected1(equipmentSelection1); });
                    equipmentSelection2.onValueChanged.AddListener(delegate { EquipmentSelected2(equipmentSelection2); });
                    equipmentSelection3.onValueChanged.AddListener(delegate { EquipmentSelected3(equipmentSelection3); });

                    break;
                }
            case 4:
                {
                    equipmentChoice4.gameObject.SetActive(true);
                    equipmentChoice5.gameObject.SetActive(false);
                    equipmentChoice6.gameObject.SetActive(false);

                    Vector2 newTextPos = new Vector2(choiceTextPos.x, choiceTextPos.y - 130);

                    choiceText.gameObject.transform.position = newTextPos;
                    equipmentChoice1.gameObject.transform.position = equipmentChoicePos2;
                    equipmentChoice2.gameObject.transform.position = equipmentChoicePos3;
                    equipmentChoice3.gameObject.transform.position = equipmentChoicePos4;
                    equipmentChoice4.gameObject.transform.position = equipmentChoicePos5;

                    EquipmentDropMenu1();
                    EquipmentDropMenu2();
                    EquipmentDropMenu3();
                    EquipmentDropMenu4();

                    EquipmentSelected1(equipmentSelection1);
                    EquipmentSelected2(equipmentSelection2);
                    EquipmentSelected3(equipmentSelection3);
                    EquipmentSelected4(equipmentSelection4);

                    equipmentSelection1.onValueChanged.AddListener(delegate { EquipmentSelected1(equipmentSelection1); });
                    equipmentSelection2.onValueChanged.AddListener(delegate { EquipmentSelected2(equipmentSelection2); });
                    equipmentSelection3.onValueChanged.AddListener(delegate { EquipmentSelected3(equipmentSelection3); });
                    equipmentSelection4.onValueChanged.AddListener(delegate { EquipmentSelected3(equipmentSelection4); });

                    break;
                }
            case 5:
                {
                    equipmentChoice4.gameObject.SetActive(true);
                    equipmentChoice5.gameObject.SetActive(true);
                    equipmentChoice6.gameObject.SetActive(false);

                    choiceText.gameObject.transform.position = choiceTextPos;
                    equipmentChoice1.gameObject.transform.position = equipmentChoicePos1;
                    equipmentChoice2.gameObject.transform.position = equipmentChoicePos2;
                    equipmentChoice3.gameObject.transform.position = equipmentChoicePos3;
                    equipmentChoice4.gameObject.transform.position = equipmentChoicePos4;
                    equipmentChoice5.gameObject.transform.position = equipmentChoicePos5;

                    EquipmentDropMenu1();
                    EquipmentDropMenu2();
                    EquipmentDropMenu3();
                    EquipmentDropMenu4();
                    EquipmentDropMenu5();

                    EquipmentSelected1(equipmentSelection1);
                    EquipmentSelected2(equipmentSelection2);
                    EquipmentSelected3(equipmentSelection3);
                    EquipmentSelected4(equipmentSelection4);
                    EquipmentSelected5(equipmentSelection5);

                    equipmentSelection1.onValueChanged.AddListener(delegate { EquipmentSelected1(equipmentSelection1); });
                    equipmentSelection2.onValueChanged.AddListener(delegate { EquipmentSelected2(equipmentSelection2); });
                    equipmentSelection3.onValueChanged.AddListener(delegate { EquipmentSelected3(equipmentSelection3); });
                    equipmentSelection4.onValueChanged.AddListener(delegate { EquipmentSelected4(equipmentSelection4); });
                    equipmentSelection5.onValueChanged.AddListener(delegate { EquipmentSelected5(equipmentSelection5); });

                    break;
                }
            case 6:
                {
                    equipmentChoice4.gameObject.SetActive(true);
                    equipmentChoice5.gameObject.SetActive(true);
                    equipmentChoice6.gameObject.SetActive(true);

                    choiceText.gameObject.transform.position = choiceTextPos;
                    equipmentChoice1.gameObject.transform.position = equipmentChoicePos1;
                    equipmentChoice2.gameObject.transform.position = equipmentChoicePos2;
                    equipmentChoice3.gameObject.transform.position = equipmentChoicePos3;
                    equipmentChoice4.gameObject.transform.position = equipmentChoicePos4;
                    equipmentChoice5.gameObject.transform.position = equipmentChoicePos5;
                    equipmentChoice6.gameObject.transform.position = equipmentChoicePos6;

                    EquipmentDropMenu1();
                    EquipmentDropMenu2();
                    EquipmentDropMenu3();
                    EquipmentDropMenu4();
                    EquipmentDropMenu5();
                    EquipmentDropMenu6();

                    EquipmentSelected1(equipmentSelection1);
                    EquipmentSelected2(equipmentSelection2);
                    EquipmentSelected3(equipmentSelection3);
                    EquipmentSelected4(equipmentSelection4);
                    EquipmentSelected5(equipmentSelection5);
                    EquipmentSelected6(equipmentSelection6);

                    equipmentSelection1.onValueChanged.AddListener(delegate { EquipmentSelected1(equipmentSelection1); });
                    equipmentSelection2.onValueChanged.AddListener(delegate { EquipmentSelected2(equipmentSelection2); });
                    equipmentSelection3.onValueChanged.AddListener(delegate { EquipmentSelected3(equipmentSelection3); });
                    equipmentSelection4.onValueChanged.AddListener(delegate { EquipmentSelected4(equipmentSelection4); });
                    equipmentSelection5.onValueChanged.AddListener(delegate { EquipmentSelected5(equipmentSelection5); });
                    equipmentSelection6.onValueChanged.AddListener(delegate { EquipmentSelected6(equipmentSelection6); });

                    break;
                }
        }
    }

    private void SkillDropmenu1()
    {
        skillSelection1.options.Clear();

        foreach (string sk in skills)
        {
            skillSelection1.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }

    private void SkillDropmenu2()
    {
        skillSelection2.options.Clear();

        foreach (string sk in skills)
        {
            skillSelection2.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }
    private void SkillDropmenu3()
    {
        skillSelection3.options.Clear();

        foreach (string sk in skills)
        {
            skillSelection3.options.Add(new TMP_Dropdown.OptionData() { text = sk });
        }
    }

    private void SkillDropmenu4()
    {
        skillSelection4.options.Clear();

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

    private void EquipmentDropMenu1()
    {
        equipmentSelection1.options.Clear();

        foreach (string eq in e1)
        {
            equipmentSelection1.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }
    private void EquipmentDropMenu2()
    {
        equipmentSelection2.options.Clear();

        foreach (string eq in e2)
        {
            equipmentSelection2.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }

    private void EquipmentDropMenu3()
    {
        equipmentSelection3.options.Clear();

        foreach (string eq in e3)
        {
            equipmentSelection3.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }
    private void EquipmentDropMenu4()
    {
        equipmentSelection4.options.Clear();

        foreach (string eq in e4)
        {
            equipmentSelection4.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }

    private void EquipmentDropMenu5()
    {
        equipmentSelection5.options.Clear();

        foreach (string eq in e5)
        {
            equipmentSelection5.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }
    private void EquipmentDropMenu6()
    {
        equipmentSelection6.options.Clear();

        foreach (string eq in e6)
        {
            equipmentSelection6.options.Add(new TMP_Dropdown.OptionData() { text = eq });
        }
    }

    private void EquipmentSelected1(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice1.text = dropdownItem.options[index].text;
        equipmentSelection1.GetComponentInChildren<TMP_Text>().text = equipmentChoice1.text;

    }
    private void EquipmentSelected2(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice2.text = dropdownItem.options[index].text;
        equipmentSelection2.GetComponentInChildren<TMP_Text>().text = equipmentChoice2.text;

    }

    private void EquipmentSelected3(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice3.text = dropdownItem.options[index].text;
        equipmentSelection3.GetComponentInChildren<TMP_Text>().text = equipmentChoice3.text;

    }
    private void EquipmentSelected4(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice4.text = dropdownItem.options[index].text;
        equipmentSelection4.GetComponentInChildren<TMP_Text>().text = equipmentChoice4.text;

    }

    private void EquipmentSelected5(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice5.text = dropdownItem.options[index].text;
        equipmentSelection5.GetComponentInChildren<TMP_Text>().text = equipmentChoice5.text;

    }
    private void EquipmentSelected6(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        equipmentChoice6.text = dropdownItem.options[index].text;
        equipmentSelection6.GetComponentInChildren<TMP_Text>().text = equipmentChoice6.text;

    }

    private void ClearingLists()
    {
        skills.Clear();

        e1.Clear();
        e2.Clear();
        e3.Clear();
        if (e4.Count != 0)
        {
            e4.Clear();
        }
        if (e5.Count != 0)
        {
            e5.Clear();
        }
        if (e6.Count != 0)
        {
            e6.Clear();
        }
    }

    private void SettingTextFields()
    {
        className = GameObject.Find("ClassName").GetComponent<TMP_Text>();
        currentRaceName = GameObject.Find("CurrentRaceName").GetComponent<TMP_Text>();
        hitDiceInfo = GameObject.Find("HitDieTypeInfo").GetComponent<TMP_Text>();
        savingThrowsInfo = GameObject.Find("SavingThrowsInfo").GetComponent<TMP_Text>();
        weaponProficienciesInfo = GameObject.Find("WeaponProficienciesInfo").GetComponent<TMP_Text>();
        armorProficienciesInfo = GameObject.Find("ArmorProficienciesInfo").GetComponent<TMP_Text>();
        classFeaturesInfo = GameObject.Find("ClassFeaturesInfo").GetComponent<TMP_Text>();

        skillChoice1 = GameObject.Find("SkillProficienciesInfo1").GetComponent<TMP_Text>();
        skillChoice2 = GameObject.Find("SkillProficienciesInfo2").GetComponent<TMP_Text>();
        skillChoice3 = GameObject.Find("SkillProficienciesInfo3").GetComponent<TMP_Text>();
        skillChoice4 = GameObject.Find("SkillProficienciesInfo4").GetComponent<TMP_Text>();

        equipmentChoice1 = GameObject.Find("EquipmentChoiceInfo1").GetComponent<TMP_Text>();
        equipmentChoice2 = GameObject.Find("EquipmentChoiceInfo2").GetComponent<TMP_Text>();
        equipmentChoice3 = GameObject.Find("EquipmentChoiceInfo3").GetComponent<TMP_Text>();
        equipmentChoice4 = GameObject.Find("EquipmentChoiceInfo4").GetComponent<TMP_Text>();
        equipmentChoice5 = GameObject.Find("EquipmentChoiceInfo5").GetComponent<TMP_Text>();
        equipmentChoice6 = GameObject.Find("EquipmentChoiceInfo6").GetComponent<TMP_Text>();

        choiceText = GameObject.Find("ChoiceTXT").GetComponent<TMP_Text>();
    }

    private void SettingOriginalPositions()
    {
        skillChoicePos1 = new Vector2(skillChoice1.gameObject.transform.position.x, skillChoice1.gameObject.transform.position.y);
        skillChoicePos2 = new Vector2(skillChoice2.gameObject.transform.position.x, skillChoice2.gameObject.transform.position.y);
        skillChoicePos3 = new Vector2(skillChoice3.gameObject.transform.position.x, skillChoice3.gameObject.transform.position.y);
        skillChoicePos4 = new Vector2(skillChoice4.gameObject.transform.position.x, skillChoice4.gameObject.transform.position.y);

        skillSelectionPos1 = new Vector2(skillSelection1.gameObject.transform.position.x, skillSelection1.gameObject.transform.position.y);
        skillSelectionPos2 = new Vector2(skillSelection2.gameObject.transform.position.x, skillSelection2.gameObject.transform.position.y);
        skillSelectionPos3 = new Vector2(skillSelection3.gameObject.transform.position.x, skillSelection3.gameObject.transform.position.y);
        skillSelectionPos4 = new Vector2(skillSelection4.gameObject.transform.position.x, skillSelection4.gameObject.transform.position.y);

        equipmentChoicePos1 = new Vector2(equipmentChoice1.gameObject.transform.position.x, equipmentChoice1.gameObject.transform.position.y);
        equipmentChoicePos2 = new Vector2(equipmentChoice2.gameObject.transform.position.x, equipmentChoice2.gameObject.transform.position.y);
        equipmentChoicePos3 = new Vector2(equipmentChoice3.gameObject.transform.position.x, equipmentChoice3.gameObject.transform.position.y);
        equipmentChoicePos4 = new Vector2(equipmentChoice4.gameObject.transform.position.x, equipmentChoice4.gameObject.transform.position.y);
        equipmentChoicePos5 = new Vector2(equipmentChoice5.gameObject.transform.position.x, equipmentChoice5.gameObject.transform.position.y);
        equipmentChoicePos6 = new Vector2(equipmentChoice6.gameObject.transform.position.x, equipmentChoice6.gameObject.transform.position.y);

        choiceTextPos = new Vector2(choiceText.gameObject.transform.position.x, choiceText.gameObject.transform.position.y);
    }
    #endregion
}
