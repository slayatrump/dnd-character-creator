using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class FinishCharacterController : MonoBehaviour
{
    [Header("Finished Character Info Panels")]
    public GameObject raceInfoPanel;
    public GameObject classInfoPanel;
    public GameObject backgroundInfoPanel;
    public GameObject abilityScoresInfoPanel;
    public GameObject classFeaturesInfoPanel;
    public GameObject equipmentInfoPanel;
    public GameObject spellListInfoPanel;
    public GameObject personalityInfoPanel;

    [Header("Character Race Info")]
    public TMP_Text rName;
    public TMP_Text rASIncreaseType;
    public TMP_Text rBuildSpeed;
    public TMP_Text rLanguages;
    public TMP_Text rFeatures;

    [Header("Character Class Info")]
    public TMP_Text cName;
    public TMP_Text cSavingThrows;
    public TMP_Text cFeatures;

    [Header("Character Background Info")]
    public TMP_Text bName;
    public TMP_Text bToolsPref;
    public TMP_Text bFeatures;

    [Header("Character Ability Scores Info")]
    public TMP_Text strScore;
    public TMP_Text dexScore;
    public TMP_Text conScore;
    public TMP_Text intScore;
    public TMP_Text wisScore;
    public TMP_Text chaScore;

    public TMP_Text strScoreIncrease;
    public TMP_Text dexScoreIncrease;
    public TMP_Text conScoreIncrease;
    public TMP_Text intScoreIncrease;
    public TMP_Text wisScoreIncrease;
    public TMP_Text chaScoreIncrease;

    public TMP_Text strScoreMod;
    public TMP_Text dexScoreMod;
    public TMP_Text conScoreMod;
    public TMP_Text intScoreMod;
    public TMP_Text wisScoreMod;
    public TMP_Text chaScoreMod;

    [Header("Character Class Features Info")]
    public TMP_Text cf1;
    public TMP_Text cf2;

    [Header("Character Personality Info")]
    public TMP_Text pCharacterName;
    public TMP_Text pPlayerName;
    public TMP_Text pPersonalityTrails;
    public TMP_Text pIdeals;
    public TMP_Text pBonds;
    public TMP_Text pFlaws;

    [Header("UI Stuff")]
    public GameObject textPrefab;

    private void Start()
    {
        #region Filling Out Saved Data Lists
        foreach (string skills in SaveManager.instance.gameData.skillPreficiencies)
        {
            GameObject skillName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("ClassSkillPref/ScrollPanel/SkillPrefList/Scroll").transform;

            skillName.transform.SetParent(parent, false);

            skillName.GetComponentInChildren<TMP_Text>().text = skills;
        }

        foreach (string addSkills in SaveManager.instance.gameData.extraSkillProf)
        {
            GameObject addskillName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("AdditionalSkillProf/ScrollPanel/SkillPrefList/Scroll").transform;

            addskillName.transform.SetParent(parent, false);

            addskillName.GetComponentInChildren<TMP_Text>().text = addSkills;
        }

        foreach (string addLanguage in SaveManager.instance.gameData.extraLanguageSelection)
        {
            GameObject addLanguageName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("AdditionalLanguages/ScrollPanel/LanguageList/Scroll").transform;

            addLanguageName.transform.SetParent(parent, false);

            addLanguageName.GetComponentInChildren<TMP_Text>().text = addLanguage;
        }

        foreach (string equipment in SaveManager.instance.gameData.equipmentChoices)
        {
            GameObject equipmentName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("Equipment/ScrollPanel/EquipmentList/Scroll").transform;

            equipmentName.transform.SetParent(parent, false);

            equipmentName.GetComponentInChildren<TMP_Text>().text = equipment;
        }

        foreach (string exequipment in SaveManager.instance.gameData.extraEquipment)
        {
            GameObject exequipmentName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("EXEquipment/ScrollPanel/EXEquipmentList/Scroll").transform;

            exequipmentName.transform.SetParent(parent, false);

            exequipmentName.GetComponentInChildren<TMP_Text>().text = exequipment;
        }

        foreach (string cantrip in SaveManager.instance.gameData.cantripList)
        {
            GameObject cantripName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("Cantrips/ScrollPanel/CantripList/Scroll").transform;

            cantripName.transform.SetParent(parent, false);

            cantripName.GetComponentInChildren<TMP_Text>().text = cantrip;
        }

        foreach (string spell in SaveManager.instance.gameData.spellList)
        {
            GameObject spellName = Instantiate(textPrefab);
            Transform parent = GameObject.Find("L1Spells/ScrollPanel/SpellList/Scroll").transform;

            spellName.transform.SetParent(parent, false);

            spellName.GetComponentInChildren<TMP_Text>().text = spell;
        }
        #endregion
    }

    public void InfoSelected()
    {
        string selected = EventSystem.current.currentSelectedGameObject.name;

        switch (selected)
        {
            case "s1":
                {
                    DisplayRaceInfo();
                    break;
                }
            case "s2":
                {
                    DisplayClassInfo();
                    break;
                }
            case "s3":
                {
                    DisplayBackgroundInfo();
                    break;
                }
            case "s4":
                {
                    DisplayAbilityScoresInfo();
                    break;
                }
            case "s5":
                {
                    DisplayClassFeaturesInfo();
                    break;
                }
            case "s6":
                {
                    DisplayEquipmentInfo();
                    break;
                }
            case "s7":
                {
                    DisplaySpellListInfo();
                    break;
                }
            case "s8":
                {
                    DisplayPersonalityInfo();
                    break;
                }
        }
    }

    public void DisplayRaceInfo()
    {
        raceInfoPanel.SetActive(true);

        rName.text = $"Race: {SaveManager.instance.gameData.raceName}";
        rASIncreaseType.text = $"AS Increase Type 1: {SaveManager.instance.gameData.raceASType1} by +{SaveManager.instance.gameData.raceASIncrease1}" +
            $"\nAS Increase Type 2: {SaveManager.instance.gameData.raceASType2} by +{SaveManager.instance.gameData.raceASIncrease2}";
        rBuildSpeed.text = $"{SaveManager.instance.gameData.raceName} Build: {SaveManager.instance.gameData.raceBuild}\n" +
            $"{SaveManager.instance.gameData.raceName} Speed: {SaveManager.instance.gameData.raceSpeed}";

        rLanguages.text = $"{SaveManager.instance.gameData.raceName} Languages:\n";
        int index = 0;

        foreach (string languages in SaveManager.instance.gameData.raceLanguages)
        {
            index++;

            if (index != SaveManager.instance.gameData.raceLanguages.Count)
            {
                rLanguages.text += languages + ", ";
            }
            else
            {
                rLanguages.text += languages;
            }
        }

        rFeatures.text = $"{SaveManager.instance.gameData.raceName} Features:\n";
        index = 0;

        foreach (string features in SaveManager.instance.gameData.raceFeatures)
        {
            index++;

            if (index != SaveManager.instance.gameData.raceFeatures.Count)
            {
                rFeatures.text += features + ", ";
            }
            else
            {
                rFeatures.text += features;
            }
        }
    }
    public void DisplayClassInfo()
    {
        classInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);

        cName.text = $"Class: {SaveManager.instance.gameData.className}";
        cSavingThrows.text = $"Hit Dice : d{SaveManager.instance.gameData.hitDieType}\n" +
            $"\nSaving Throw 1: {SaveManager.instance.gameData.ASTypeSavingThrow1}\n" +
            $"Saving Throw 2: {SaveManager.instance.gameData.ASTypeSavingThrow2}";

        cFeatures.text = $"{SaveManager.instance.gameData.className} Features:\n";

        int index = 0;
        foreach (string features in SaveManager.instance.gameData.classFeatures)
        {
            index++;
            if (index != SaveManager.instance.gameData.classFeatures.Count)
            {
                cFeatures.text += features + ", ";
            }
            else
            {
                cFeatures.text += features;
            }
        }
    }
    public void DisplayBackgroundInfo()
    {
        backgroundInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);
        classInfoPanel.SetActive(false);

        bName.text = $"Background: {SaveManager.instance.gameData.backgroundName}";

        bToolsPref.text = $"{SaveManager.instance.gameData.backgroundName} Tool Proficiencies:\n";

        int index = 0;

        if (SaveManager.instance.gameData.toolPreficiencies.Count == 0)
        {
            bToolsPref.text += "N/A";
        }
        else 
        {
            foreach (string tool in SaveManager.instance.gameData.toolPreficiencies)
            {
                if (SaveManager.instance.gameData.toolPreficiencies.Count == 0)
                {
                    bToolsPref.text += "N/A";
                    break;
                }

                index++;
                if (index != SaveManager.instance.gameData.toolPreficiencies.Count)
                {
                    bToolsPref.text += tool + ", ";
                }
                else
                {
                    bToolsPref.text += tool;
                }
            }
        }

        index = 0;

        bFeatures.text = $"{SaveManager.instance.gameData.backgroundName} Features:\n{SaveManager.instance.gameData.backgroundFeatures}";
    }
    public void DisplayAbilityScoresInfo()
    {
        abilityScoresInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);
        classInfoPanel.SetActive(false);
        backgroundInfoPanel.SetActive(false);

        strScore.text = $"{SaveManager.instance.gameData.strScore}";
        dexScore.text = $"{SaveManager.instance.gameData.dexScore}";
        conScore.text = $"{SaveManager.instance.gameData.conScore}";
        intScore.text = $"{SaveManager.instance.gameData.intScore}";
        wisScore.text = $"{SaveManager.instance.gameData.wisScore}";
        chaScore.text = $"{SaveManager.instance.gameData.chaScore}";

        if (SaveManager.instance.gameData.raceASType1 == "Str" || SaveManager.instance.gameData.raceASType2 == "Str")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Str")
            {
                strScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Str")
            {
                strScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }
        if (SaveManager.instance.gameData.raceASType1 == "Dex" || SaveManager.instance.gameData.raceASType2 == "Dex")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Dex")
            {
                dexScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Dex")
            {
                dexScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }
        if (SaveManager.instance.gameData.raceASType1 == "Con" || SaveManager.instance.gameData.raceASType2 == "Con")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Con")
            {
                conScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Con")
            {
                conScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }
        if (SaveManager.instance.gameData.raceASType1 == "Int" || SaveManager.instance.gameData.raceASType2 == "Int")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Int")
            {
                intScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Int")
            {
                intScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }
        if (SaveManager.instance.gameData.raceASType1 == "Wis" || SaveManager.instance.gameData.raceASType2 == "Wis")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Wis")
            {
                wisScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Wis")
            {
                wisScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }
        if (SaveManager.instance.gameData.raceASType1 == "Cha" || SaveManager.instance.gameData.raceASType2 == "Cha")
        {
            if (SaveManager.instance.gameData.raceASType1 == "Cha")
            {
                chaScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease1}";
            }
            else if (SaveManager.instance.gameData.raceASType2 == "Cha")
            {
                chaScoreIncrease.text = $"+{SaveManager.instance.gameData.raceASIncrease2}";
            }
        }

        strScoreMod.text = $"Mod: {SaveManager.instance.gameData.strMod}";
        dexScoreMod.text = $"Mod: {SaveManager.instance.gameData.dexMod}";
        conScoreMod.text = $"Mod: {SaveManager.instance.gameData.conMod}";
        intScoreMod.text = $"Mod: {SaveManager.instance.gameData.intMod}";
        wisScoreMod.text = $"Mod: {SaveManager.instance.gameData.wisMod}";
        chaScoreMod.text = $"Mod: {SaveManager.instance.gameData.chaMod}";
    }
    public void DisplayClassFeaturesInfo()
    {
        classFeaturesInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);
        classInfoPanel.SetActive(false);
        backgroundInfoPanel.SetActive(false);
        abilityScoresInfoPanel.SetActive(false);

        cf1.text = $"Class Feature 1:\n{SaveManager.instance.gameData.classFeaturesChoice1}";
        cf2.text = $"Class Feature 2:\n{SaveManager.instance.gameData.classFeaturesChoice2}";
    }
    public void DisplayEquipmentInfo()
    {
        equipmentInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);
        classInfoPanel.SetActive(false);
        backgroundInfoPanel.SetActive(false);
        abilityScoresInfoPanel.SetActive(false);
        classFeaturesInfoPanel.SetActive(false);
    }
    public void DisplaySpellListInfo()
    {
        spellListInfoPanel.SetActive(true);
        classInfoPanel.SetActive(false);
        raceInfoPanel.SetActive(false);
        backgroundInfoPanel.SetActive(false);
        abilityScoresInfoPanel.SetActive(false);
        classFeaturesInfoPanel.SetActive(false);
        equipmentInfoPanel.SetActive(false);
    }
    public void DisplayPersonalityInfo()
    {
        personalityInfoPanel.SetActive(true);
        raceInfoPanel.SetActive(false);
        classInfoPanel.SetActive(false);
        backgroundInfoPanel.SetActive(false);
        abilityScoresInfoPanel.SetActive(false);
        classFeaturesInfoPanel.SetActive(false);
        equipmentInfoPanel.SetActive(false);
        spellListInfoPanel.SetActive(false);

        pCharacterName.text = $"Character Name: {SaveManager.instance.gameData.characterName}";
        pPlayerName.text = $"Player Name: {SaveManager.instance.gameData.playerName}";
        pPersonalityTrails.text = $"Personality Trails: \n{SaveManager.instance.gameData.personalityTraits}";
        pIdeals.text = $"Ideals: \n{SaveManager.instance.gameData.ideals}";
        pBonds.text = $"Bonds: \n{SaveManager.instance.gameData.bonds}";
        pFlaws.text = $"Flaws: \n{SaveManager.instance.gameData.flaws}";
    }
}
