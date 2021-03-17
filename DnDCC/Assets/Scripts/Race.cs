using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

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

    #region Race Text Variables
    private TMP_Text asScoreBonusInfo;
    private TMP_Text sizeSpeedInfo;
    private TMP_Text languagesInfo;
    private TMP_Text raceFeaturesInfo;
    #endregion

    #region Race UI Functionality
    void Start()
    {
        asScoreBonusInfo = GameObject.Find("ASScoreBonus").GetComponent<TMP_Text>();
        sizeSpeedInfo = GameObject.Find("Speed&Size").GetComponent<TMP_Text>();
        languagesInfo = GameObject.Find("Languages").GetComponent<TMP_Text>();
        raceFeaturesInfo = GameObject.Find("RaceFeatures").GetComponent<TMP_Text>();
        sc = GameObject.Find("SelectionController").GetComponent<SelectionController>();
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
    #endregion
}
