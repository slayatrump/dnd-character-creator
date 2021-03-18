using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.IO;

public class Race : MonoBehaviour
{
    public enum ASType { Str, Dex, Con, Int, Wis, Cha, All, ChoicePool };
    public enum SizeType { Small, Medium, Large };

    [System.Serializable]
    public class ASIncrease
    {
        public ASType AbilityScore;
        public int IncreaseBy;
    }

    public ASIncrease AS1;
    public ASIncrease AS2;

    public SizeType Size;

    public int Speed;

    public string[] Languages;

    public string[] Features;

    private SelectionController sc;

    #region Private variables used for saving purposes
    private string languages = "";
    private string features = "";
    private string raceName;
    #endregion

    #region Race Text Variables
    private TMP_Text asScoreBonusInfo;
    private TMP_Text sizeSpeedInfo;
    private TMP_Text languagesInfo;
    private TMP_Text raceFeaturesInfo;
    private TMP_Text selectedRaceName;
    #endregion

    #region Race UI Functionality
    void Start()
    {
        asScoreBonusInfo = GameObject.Find("ASScoreBonus").GetComponent<TMP_Text>();
        sizeSpeedInfo = GameObject.Find("Speed&Size").GetComponent<TMP_Text>();
        languagesInfo = GameObject.Find("Languages").GetComponent<TMP_Text>();
        raceFeaturesInfo = GameObject.Find("RaceFeatures").GetComponent<TMP_Text>();
        selectedRaceName = GameObject.Find("RaceName").GetComponent<TMP_Text>();
        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();

        LoadRace();
    }

    public void RaceSelected()
    {
        sc.selected = EventSystem.current.currentSelectedGameObject.name;

        switch (sc.selected)
        {
            case "s1":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Dragonborn";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                            + ", " + this.Features[2];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s2":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Forest Gnome";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                            + ", " + this.Features[2] + ", " + this.Features[3];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s3":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Half-Elf";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1]
                            + ", " + this.Languages[2];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                            + ", " + this.Features[2];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s4":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Half-Orc";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                            + ", " + this.Features[2] + ", " + this.Features[3];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s5":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "High Elf";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1]
                                + ", " + this.Languages[2];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3] + ", " + this.Features[4]
                                + ", " + this.Features[5] + ", " + this.Features[6];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s6":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Hill Dwarf";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3] + ", " + this.Features[4]
                                + ", " + this.Features[5];
                    }
                    else
                    {
                        Deselect();
                    }
                    

                    break;
                }
            case "s7":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Human";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: N/A";
                    }
                    else
                    {
                        Deselect();
                    }
                    

                    break;
                }
            case "s8":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Lightfoot Halfling";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3];
                    }
                    else
                    {
                        Deselect();
                    }
                    
                    break;
                }
            case "s9":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Mountain Drawf";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3] + ", " + this.Features[4]
                                + ", " + this.Features[5];
                    }
                    else
                    {
                        Deselect();
                    }
                    

                    break;
                }
            case "s10":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Rock Gnome";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3];
                    }
                    else
                    {
                        Deselect();
                    }
                    

                    break;
                }
            case "s11":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Stout Halfling";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3];
                    }
                    else
                    {
                        Deselect();
                    }
                    

                    break;
                }
            case "s12":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Tiefling";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2];
                    }
                    else
                    {
                        Deselect();
                    }

                    break;
                }
            case "s13":
                {
                    if (SelectionController.isSelected == true)
                    {
                        raceName = "Wood Elf";
                        selectedRaceName.text = raceName;
                        asScoreBonusInfo.text = "AS Bonus 1: " + this.AS1.AbilityScore + " +" + this.AS1.IncreaseBy +
                        "\nAS Bonus 2: " + this.AS2.AbilityScore + " +" + this.AS2.IncreaseBy;
                        sizeSpeedInfo.text = "Size: " + this.Size + "\nSpeed: " + this.Speed;
                        languagesInfo.text = "Languages: \n" + this.Languages[0] + ", " + this.Languages[1];
                        raceFeaturesInfo.text = "Features: \n" + this.Features[0] + ", " + this.Features[1]
                                + ", " + this.Features[2] + ", " + this.Features[3] + ", " + this.Features[4]
                                + ", " + this.Features[5] + ", " + this.Features[6];
                    }
                    else
                    {
                        Deselect();
                    }

                    break;
                }

        }
    }

    private void Deselect()
    {
        asScoreBonusInfo.text = "";
        sizeSpeedInfo.text = "";
        languagesInfo.text = "";
        raceFeaturesInfo.text = "";
    }

    private void LoadRace()
    {
        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + SaveManager.instance.gameData.saveName + ".dat"))
        {
            selectedRaceName.text = SaveManager.instance.gameData.raceName;
            asScoreBonusInfo.text = "AS Bonus 1: " + SaveManager.instance.gameData.raceASType1 +
            " +" + SaveManager.instance.gameData.raceASIncrease1 + "\nAS Bouns 2: "
            + SaveManager.instance.gameData.raceASType2 + " +" + SaveManager.instance.gameData.raceASIncrease2;
            sizeSpeedInfo.text = "Size: " + SaveManager.instance.gameData.raceBuild + "\nSpeed: " +
                SaveManager.instance.gameData.raceSpeed;
            foreach (string l in SaveManager.instance.gameData.raceLanguages)
            {
                languages = languages.ToString() + l.ToString() + "\n";
            }
            languagesInfo.text = "Languages: \n" + languages;
            foreach (string f in SaveManager.instance.gameData.raceFeatures)
            {
                features = features.ToString() + f.ToString() + ", ";
            }
            raceFeaturesInfo.text = "Features: \n" + features;
        }
    }

    public void SaveRace()
    {
        SaveManager.instance.gameData.raceLanguages.Clear();
        SaveManager.instance.gameData.raceFeatures.Clear();

        SaveManager.instance.gameData.raceName = this.raceName;
        SaveManager.instance.gameData.raceASType1 = this.AS1.AbilityScore.ToString();
        SaveManager.instance.gameData.raceASType2 = this.AS2.AbilityScore.ToString();
        SaveManager.instance.gameData.raceASIncrease1 = this.AS1.IncreaseBy;
        SaveManager.instance.gameData.raceASIncrease2 = this.AS2.IncreaseBy;
        SaveManager.instance.gameData.raceBuild = this.Size.ToString();
        SaveManager.instance.gameData.raceSpeed = this.Speed;
        foreach (string l in this.Languages)
        {
            SaveManager.instance.gameData.raceLanguages.Add(l);
        }
        foreach (string f in this.Features)
        {
            SaveManager.instance.gameData.raceFeatures.Add(f);
        }
        SaveManager.instance.Save();
    }
    #endregion
}
