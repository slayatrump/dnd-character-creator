using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalEnums;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour
{
    #region Background Prefab Info
    //Background objects should be saved as "[background name] Background Object"

    public string Name;
    
    public SkillType SkillProficiency1;
    public SkillType SkillProficiency2;

    //"None" if its empty in the excel sheet
    public string[] ToolProficiencies;

    public int ExtraLanguagesKnown;

    public string[] Equipment;

    public int Gold;

    public string BackgroundFeature;
    #endregion

    #region Background UI Functionality
    private TMP_Text backgroundNameInfo;
    private TMP_Text goldAmountInfo;
    private TMP_Text skillInfoTXT;
    private TMP_Text skillchoiceInfo1;
    private TMP_Text skillchoiceInfo2;
    private TMP_Text extraLanguagesInfo;
    private TMP_Text toolProficienciesInfo;
    private TMP_Text backgroundFeaturesInfo;
    private TMP_Text equipmentInfoTXT;
    private TMP_Text equipmentInfo;

    Button toEquipment;

    private SelectionController sc;

    private void Awake()
    {
        toEquipment = GameObject.Find("ToEquipmentInfoBTN").GetComponent<Button>();
    }

    private void Start()
    {
        SettingTextFields();

        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();

        toEquipment.gameObject.SetActive(false);
    }

    public void BackgroundSelection()
    {
        sc.selected = EventSystem.current.currentSelectedGameObject.name;

        switch (sc.selected)
        {
            case "s1":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = "Tool's: \n" + "None";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}" +
                        $", {this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s2":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s3":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s4":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s5":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s6":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s7":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}, " +
                        $"{this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s8":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s9":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n None";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s10":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s11":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s12":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s13":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s14":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n None";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}, {this.Equipment[5]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s15":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s16":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s17":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
            case "s18":
                {
                    backgroundNameInfo.text = $"Background: {this.Name}";
                    goldAmountInfo.text = "Gold: " + this.Gold.ToString();
                    skillInfoTXT.text = $"{this.Name} Addtional Skils";
                    skillchoiceInfo1.text = $"Skill 1: {SkillProficiency1}";
                    skillchoiceInfo2.text = $"Skill 2: {SkillProficiency2}";
                    extraLanguagesInfo.text = $"{this.Name}s can learn {this.ExtraLanguagesKnown} extra languages";
                    toolProficienciesInfo.text = $"Tool's: \n {this.ToolProficiencies[0]}, {this.ToolProficiencies[1]}";
                    backgroundFeaturesInfo.text = $"{this.Name} Features: \n {BackgroundFeature}";
                    equipmentInfoTXT.text = $"{this.Name} Equipment:";
                    equipmentInfo.text = $"{this.Equipment[0]}, {this.Equipment[1]}, {this.Equipment[2]}, {this.Equipment[3]}," +
                        $"{this.Equipment[4]}, {this.Equipment[5]}";

                    toEquipment.gameObject.SetActive(true);

                    SettingBackgroundData();

                    break;
                }
        }
    }

    private void SettingBackgroundData()
    {
        SaveManager.instance.gameData.toolPreficiencies.Clear();
        SaveManager.instance.gameData.extraEquipment.Clear();

        SaveManager.instance.gameData.backgroundName = this.Name;
        SaveManager.instance.gameData.goldAmount = this.Gold;
        SaveManager.instance.gameData.additionalSkill1 = this.SkillProficiency1.ToString();
        SaveManager.instance.gameData.additionalSkill2 = this.SkillProficiency2.ToString();
        SaveManager.instance.gameData.extraLanguageOptions = this.ExtraLanguagesKnown;
        foreach (string t in this.ToolProficiencies)
        {
            SaveManager.instance.gameData.toolPreficiencies.Add(t);
        }
        SaveManager.instance.gameData.backgroundFeatures = this.BackgroundFeature;
        foreach (string eq in this.Equipment)
        {
            SaveManager.instance.gameData.extraEquipment.Add(eq);
        }
    }

    public static void SavingBackgroundInfoData()
    {
        SaveManager.instance.Save();
    }

    private void SettingTextFields()
    {
        backgroundNameInfo = GameObject.Find("BackgroundName").GetComponent<TMP_Text>();
        goldAmountInfo = GameObject.Find("GoldAmountInfo").GetComponent<TMP_Text>();
        skillInfoTXT = GameObject.Find("AdditionalSkillsTXT").GetComponent<TMP_Text>();
        skillchoiceInfo1 = GameObject.Find("SkillChoice1").GetComponent<TMP_Text>();
        skillchoiceInfo2 = GameObject.Find("SkillChoice2").GetComponent<TMP_Text>();
        extraLanguagesInfo = GameObject.Find("ExtraLanguagesInfo").GetComponent<TMP_Text>();
        toolProficienciesInfo = GameObject.Find("ToolProficienciesInfo").GetComponent<TMP_Text>();
        backgroundFeaturesInfo = GameObject.Find("BackgroundFeatureInfo").GetComponent<TMP_Text>();
        equipmentInfoTXT = GameObject.Find("EquipmentInfoTXT").GetComponent<TMP_Text>();
        equipmentInfo = GameObject.Find("EquipmentInfo").GetComponent<TMP_Text>();      
    }
    #endregion
}
