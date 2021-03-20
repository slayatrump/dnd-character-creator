using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointBuyScript : MonoBehaviour
{

    //Might be better for this to have its own script for use in other areas, but ill keep it here for now
    public class Attribute
    {
        public int score;
        public int modifier;
    }

    public int points;
    public Attribute Str = new Attribute();
    public Attribute Dex = new Attribute();
    public Attribute Con = new Attribute();
    public Attribute Int = new Attribute();
    public Attribute Wis = new Attribute();
    public Attribute Cha = new Attribute();

    Text totalPointsText;
    Text str;
    Text dex;
    Text con;
    Text inte;
    Text wis;
    Text cha;

    Text strMod;
    Text dexMod;
    Text conMod;
    Text inteMod;
    Text wisMod;
    Text chaMod;

    #region Final Score and Modifiers Text Fields
    public static TMP_Text strFinalScore;
    public static TMP_Text dexFinalScore;
    public static TMP_Text conFinalScore;
    public static TMP_Text intFinalScore;
    public static TMP_Text wisFinalScore;
    public static TMP_Text chaFinalScore;

    TMP_Text strModFinalScore;
    TMP_Text dexModFinalScore;
    TMP_Text conModFinalScore;
    TMP_Text intModFinalScore;
    TMP_Text wisModFinalScore;
    TMP_Text chaModFinalScore;
    #endregion

    private string select;

    public void Start()
    {
        //For loading a character, this may need to change
        Str.score = 8;
        Dex.score = 8;
        Con.score = 8;
        Int.score = 8;
        Wis.score = 8;
        Cha.score = 8;

        Str.modifier = -1;
        Dex.modifier = -1;
        Con.modifier = -1;
        Int.modifier = -1;
        Wis.modifier = -1;
        Cha.modifier = -1;

        points = 27;

        totalPointsText = GameObject.Find("Points").GetComponent<Text>();

        str = GameObject.Find("StrengthPoints").GetComponent<Text>();
        dex = GameObject.Find("DexterityPoints").GetComponent<Text>();
        con = GameObject.Find("ConsitutionPoints").GetComponent<Text>();
        inte = GameObject.Find("IntelligencePoints").GetComponent<Text>();
        wis = GameObject.Find("WisdomPoints").GetComponent<Text>();
        cha = GameObject.Find("CharismaPoints").GetComponent<Text>();

        strMod = GameObject.Find("StrengthMod").GetComponent<Text>();
        dexMod = GameObject.Find("DexterityMod").GetComponent<Text>();
        conMod = GameObject.Find("ConsitutionMod").GetComponent<Text>();
        inteMod = GameObject.Find("IntelligenceMod").GetComponent<Text>();
        wisMod = GameObject.Find("WisdomMod").GetComponent<Text>();
        chaMod = GameObject.Find("CharismaMod").GetComponent<Text>();

        str.text = Str.score.ToString();
        dex.text = Dex.score.ToString();
        con.text = Con.score.ToString();
        inte.text = Int.score.ToString();
        wis.text = Wis.score.ToString();
        cha.text = Cha.score.ToString();

        strMod.text = Str.modifier.ToString();
        dexMod.text = Dex.modifier.ToString();
        conMod.text = Con.modifier.ToString();
        inteMod.text = Int.modifier.ToString();
        wisMod.text = Wis.modifier.ToString();
        chaMod.text = Cha.modifier.ToString();

        totalPointsText.text = points.ToString();
    }

    public void AddButton()
    {
        select = EventSystem.current.currentSelectedGameObject.name;

        switch(select)
        {
            case "Str+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Str.score < 13)
                        {
                            points -= 1;
                            Str.score += 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Str.score == 13 || Str.score == 12)
                            {
                                Str.modifier = 1;
                                strMod.text = "+" + Str.modifier.ToString();
                            }
                            if (Str.score == 11 || Str.score == 10)
                            {
                                Str.modifier = 0;
                                strMod.text = "+" + Str.modifier.ToString();
                            }
                            if (Str.score == 9 || Str.score == 8)
                            {
                                Str.modifier = -1;
                                strMod.text = Str.modifier.ToString();
                            }
                        }
                        else if (Str.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Str.score += 1;

                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();

                            Str.modifier = 2;
                            strMod.text = "+" + Str.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
            case "Dex+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Dex.score < 13)
                        {
                            points -= 1;
                            Dex.score += 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Dex.score == 13 || Dex.score == 12)
                            {
                                Dex.modifier = 1;
                                dexMod.text = "+" + Dex.modifier.ToString();
                            }
                            if (Dex.score == 11 || Dex.score == 10)
                            {
                                Dex.modifier = 0;
                                dexMod.text = "+" + Dex.modifier.ToString();
                            }
                            if (Dex.score == 9 || Dex.score == 8)
                            {
                                Dex.modifier = -1;
                                dexMod.text = Dex.modifier.ToString();
                            }
                        }
                        else if (Dex.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Dex.score += 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();

                            Dex.modifier = 2;
                            dexMod.text = "+" + Dex.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
            case "Con+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Con.score < 13)
                        {
                            points -= 1;
                            Con.score += 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Con.score == 13 || Con.score == 12)
                            {
                                Con.modifier = 1;
                                conMod.text = "+" + Con.modifier.ToString();
                            }
                            if (Con.score == 11 || Con.score == 10)
                            {
                                Con.modifier = 0;
                                conMod.text = "+" + Con.modifier.ToString();
                            }
                            if (Con.score == 9 || Con.score == 8)
                            {
                                Con.modifier = -1;
                                conMod.text = Con.modifier.ToString();
                            }
                        }
                        else if (Con.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Con.score += 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();

                            Con.modifier = 2;
                            conMod.text = "+" + Con.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
            case "Int+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Int.score < 13)
                        {
                            points -= 1;
                            Int.score += 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Int.score == 13 || Int.score == 12)
                            {
                                Int.modifier = 1;
                                inteMod.text = "+" + Int.modifier.ToString();
                            }
                            if (Int.score == 11 || Int.score == 10)
                            {
                                Int.modifier = 0;
                                inteMod.text = "+" + Int.modifier.ToString();
                            }
                            if (Int.score == 9 || Int.score == 8)
                            {
                                Int.modifier = -1;
                                inteMod.text = Int.modifier.ToString();
                            }
                        }
                        else if (Int.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Int.score += 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();

                            Int.modifier = 2;
                            inteMod.text = "+" + Int.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
            case "Wis+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Wis.score < 13)
                        {
                            points -= 1;
                            Wis.score += 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Wis.score == 13 || Wis.score == 12)
                            {
                                Wis.modifier = 1;
                                wisMod.text = "+" + Wis.modifier.ToString();
                            }
                            if (Wis.score == 11 || Wis.score == 10)
                            {
                                Wis.modifier = 0;
                                wisMod.text = "+" + Wis.modifier.ToString();
                            }
                            if (Wis.score == 9 || Wis.score == 8)
                            {
                                Wis.modifier = -1;
                                wisMod.text = Wis.modifier.ToString();
                            }
                        }
                        else if (Wis.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Wis.score += 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();

                            Wis.modifier = 2;
                            wisMod.text = "+" + Wis.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
            case "Cha+":
                {
                    //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
                    if (points > 0)
                    {
                        if (Cha.score < 13)
                        {
                            points -= 1;
                            Cha.score += 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Cha.score == 13 || Cha.score == 12)
                            {
                                Cha.modifier = 1;
                                chaMod.text = "+" + Cha.modifier.ToString();
                            }
                            if (Cha.score == 11 || Cha.score == 10)
                            {
                                Cha.modifier = 0;
                                chaMod.text = "+" + Cha.modifier.ToString();
                            }
                            if (Cha.score == 9 || Cha.score == 8)
                            {
                                Cha.modifier = -1;
                                chaMod.text = Cha.modifier.ToString();
                            }
                        }
                        else if (Cha.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Cha.score += 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();

                            Cha.modifier = 2;
                            chaMod.text = "+" + Cha.modifier.ToString();
                        }
                        else
                        {
                            //cant go over 15
                        }
                    }

                    break;
                }
        }
    }

    public void SubtractButton()
    {
        select = EventSystem.current.currentSelectedGameObject.name;

        switch (select)
        {
            case "Str-":
                {
                    if (Str.score > 8)
                    {
                        if (Str.score == 15)
                        {
                            points += 2;
                            Str.score -= 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();

                            Str.modifier = 2;
                            strMod.text = "+" + Str.modifier.ToString();
                        }
                        else if (Str.score == 14)
                        {
                            points += 2;
                            Str.score -= 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();

                            Str.modifier = 1;
                            strMod.text = "+" + Str.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Str.score -= 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Str.score == 13 || Str.score == 12)
                            {
                                Str.modifier = 1;
                                strMod.text = "+" + Str.modifier.ToString();
                            }
                            if (Str.score == 11 || Str.score == 10)
                            {
                                Str.modifier = 0;
                                strMod.text = "+" + Str.modifier.ToString();
                            }
                            if (Str.score == 9 || Str.score == 8)
                            {
                                Str.modifier = -1;
                                strMod.text = Str.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }
                    break;
                }
            case "Dex-":
                {
                    if (Dex.score > 8)
                    {
                        if (Dex.score == 15)
                        {
                            points += 2;
                            Dex.score -= 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();

                            Dex.modifier = 2;
                            dexMod.text = "+" + Dex.modifier.ToString();
                        }
                        else if (Dex.score == 14)
                        {
                            points += 2;
                            Dex.score -= 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();

                            Dex.modifier = 1;
                            dexMod.text = "+" + Dex.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Dex.score -= 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Dex.score == 13 || Dex.score == 12)
                            {
                                Dex.modifier = 1;
                                dexMod.text = "+" + Dex.modifier.ToString();
                            }
                            if (Dex.score == 11 || Dex.score == 10)
                            {
                                Dex.modifier = 0;
                                dexMod.text = "+" + Dex.modifier.ToString();
                            }
                            if (Dex.score == 9 || Dex.score == 8)
                            {
                                Dex.modifier = -1;
                                dexMod.text = Dex.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }

                    break;
                }
            case "Con-":
                {
                    if (Con.score > 8)
                    {
                        if (Con.score == 15)
                        {
                            points += 2;
                            Con.score -= 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();

                            Con.modifier = 2;
                            conMod.text = "+" + Con.modifier.ToString();
                        }
                        else if (Con.score == 14)
                        {
                            points += 2;
                            Con.score -= 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();

                            Con.modifier = 1;
                            conMod.text = "+" + Con.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Con.score -= 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Con.score == 13 || Con.score == 12)
                            {
                                Con.modifier = 1;
                                conMod.text = "+" + Con.modifier.ToString();
                            }
                            if (Con.score == 11 || Con.score == 10)
                            {
                                Con.modifier = 0;
                                conMod.text = "+" + Con.modifier.ToString();
                            }
                            if (Con.score == 9 || Con.score == 8)
                            {
                                Con.modifier = -1;
                                conMod.text = Con.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }

                    break;
                }
            case "Int-":
                {
                    if (Int.score > 8)
                    {
                        if (Int.score == 15)
                        {
                            points += 2;
                            Int.score -= 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();

                            Int.modifier = 2;
                            inteMod.text = "+" + Int.modifier.ToString();
                        }
                        else if (Int.score == 14)
                        {
                            points += 2;
                            Int.score -= 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();

                            Int.modifier = 1;
                            inteMod.text = "+" + Int.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Int.score -= 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Int.score == 13 || Int.score == 12)
                            {
                                Int.modifier = 1;
                                inteMod.text = "+" + Int.modifier.ToString();
                            }
                            if (Int.score == 11 || Int.score == 10)
                            {
                                Int.modifier = 0;
                                inteMod.text = "+" + Int.modifier.ToString();
                            }
                            if (Int.score == 9 || Int.score == 8)
                            {
                                Int.modifier = -1;
                                inteMod.text = Int.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }

                    break;
                }
            case "Wis-":
                {
                    if (Wis.score > 8)
                    {
                        if (Wis.score == 15)
                        {
                            points += 2;
                            Wis.score -= 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();

                            Wis.modifier = 2;
                            wisMod.text = "+" + Wis.modifier.ToString();
                        }
                        else if (Wis.score == 14)
                        {
                            points += 2;
                            Wis.score -= 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();

                            Wis.modifier = 1;
                            wisMod.text = "+" + Wis.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Wis.score -= 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Wis.score == 13 || Wis.score == 12)
                            {
                                Wis.modifier = 1;
                                wisMod.text = "+" + Wis.modifier.ToString();
                            }
                            if (Wis.score == 11 || Wis.score == 10)
                            {
                                Wis.modifier = 0;
                                wisMod.text = "+" + Wis.modifier.ToString();
                            }
                            if (Wis.score == 9 || Wis.score == 8)
                            {
                                Wis.modifier = -1;
                                wisMod.text = Wis.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }

                    break;
                }
            case "Cha-":
                {
                    if (Cha.score > 8)
                    {
                        if(Cha.score == 15)
                        {
                            points += 2;
                            Cha.score -= 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();

                            Cha.modifier = 2;
                            chaMod.text = "+" + Cha.modifier.ToString();
                        }
                        else if (Cha.score == 14)
                        {
                            points += 2;
                            Cha.score -= 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();

                            Cha.modifier = 1;
                            chaMod.text = "+" + Cha.modifier.ToString();
                        }
                        else
                        {
                            points += 1;
                            Cha.score -= 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();

                            if (Cha.score == 13 || Cha.score == 12)
                            {
                                Cha.modifier = 1;
                                chaMod.text = "+" + Cha.modifier.ToString();
                            }
                            if (Cha.score == 11 || Cha.score == 10)
                            {
                                Cha.modifier = 0;
                                chaMod.text = "+" + Cha.modifier.ToString();
                            }
                            if (Cha.score == 9 || Cha.score == 8)
                            {
                                Cha.modifier = -1;
                                chaMod.text = Cha.modifier.ToString();
                            }
                        }
                    }
                    else
                    {
                        //cant go under 8
                    }

                    break;
                }
        }
    }

    public void FinalScores()
    {
        #region Setting Save AS Scores
        SaveManager.instance.gameData.strScore = Str.score;
        SaveManager.instance.gameData.strMod = Str.modifier;
        SaveManager.instance.gameData.dexScore = Dex.score;
        SaveManager.instance.gameData.dexMod = Dex.modifier;
        SaveManager.instance.gameData.conScore = Con.score;
        SaveManager.instance.gameData.conMod = Con.modifier;
        SaveManager.instance.gameData.intScore = Int.score;
        SaveManager.instance.gameData.intMod = Int.modifier;
        SaveManager.instance.gameData.wisScore = Wis.score;
        SaveManager.instance.gameData.wisMod = Wis.modifier;
        SaveManager.instance.gameData.chaScore = Cha.score;
        SaveManager.instance.gameData.chaMod = Cha.modifier;
        #endregion

        #region Locating the Final Score text fields
        strFinalScore = GameObject.Find("ScoreNumStr").GetComponent<TMP_Text>();
        strModFinalScore = GameObject.Find("ModNumStr").GetComponent<TMP_Text>();
        dexFinalScore = GameObject.Find("ScoreNumDex").GetComponent<TMP_Text>();
        dexModFinalScore = GameObject.Find("ModNumDex").GetComponent<TMP_Text>();
        conFinalScore = GameObject.Find("ScoreNumCon").GetComponent<TMP_Text>();
        conModFinalScore = GameObject.Find("ModNumCon").GetComponent<TMP_Text>();
        intFinalScore = GameObject.Find("ScoreNumInt").GetComponent<TMP_Text>();
        intModFinalScore = GameObject.Find("ModNumInt").GetComponent<TMP_Text>();
        wisFinalScore = GameObject.Find("ScoreNumWis").GetComponent<TMP_Text>();
        wisModFinalScore = GameObject.Find("ModNumWis").GetComponent<TMP_Text>();
        chaFinalScore = GameObject.Find("ScoreNumCha").GetComponent<TMP_Text>();
        chaModFinalScore = GameObject.Find("ModNumCha").GetComponent<TMP_Text>();
        #endregion

        #region Setting the Final Scores to the text fields
        strFinalScore.text = SaveManager.instance.gameData.strScore.ToString();
        if (SaveManager.instance.gameData.strMod > 0)
        {
            strModFinalScore.text = "+" + SaveManager.instance.gameData.strMod.ToString();
        }
        else 
        {
            strModFinalScore.text = SaveManager.instance.gameData.strMod.ToString();
        }
        dexFinalScore.text = SaveManager.instance.gameData.dexScore.ToString();
        if (SaveManager.instance.gameData.dexMod > 0)
        {
            dexModFinalScore.text = "+" + SaveManager.instance.gameData.dexMod.ToString();
        }
        else 
        {
            dexModFinalScore.text = SaveManager.instance.gameData.dexMod.ToString();
        }
        conFinalScore.text = SaveManager.instance.gameData.conScore.ToString();
        if (SaveManager.instance.gameData.conMod > 0)
        {
            conModFinalScore.text = "+" + SaveManager.instance.gameData.conMod.ToString();
        }
        else
        {
            conModFinalScore.text = SaveManager.instance.gameData.conMod.ToString();
        }
        intFinalScore.text = SaveManager.instance.gameData.intScore.ToString();
        if (SaveManager.instance.gameData.intMod > 0)
        {
            intModFinalScore.text = "+" + SaveManager.instance.gameData.intMod.ToString();
        }
        else
        {
            intModFinalScore.text = SaveManager.instance.gameData.intMod.ToString();
        }
        wisFinalScore.text = SaveManager.instance.gameData.wisScore.ToString();
        if (SaveManager.instance.gameData.wisMod > 0)
        {
            wisModFinalScore.text = "+" + SaveManager.instance.gameData.wisMod.ToString();
        }
        else
        {
            wisModFinalScore.text = SaveManager.instance.gameData.wisMod.ToString();
        }
        chaFinalScore.text = SaveManager.instance.gameData.chaScore.ToString();
        if (SaveManager.instance.gameData.chaMod > 0)
        {
            chaModFinalScore.text = "+" + SaveManager.instance.gameData.chaMod.ToString();
        }
        else
        {
            chaModFinalScore.text = SaveManager.instance.gameData.chaMod.ToString();
        }
        #endregion
    }

    public static void SavingScores()
    {
        SaveManager.instance.Save();
    }
}
