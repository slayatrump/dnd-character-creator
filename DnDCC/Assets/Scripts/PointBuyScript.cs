using System.Collections;
using System.Collections.Generic;
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
                            Str.modifier = 2;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        }
                        else if (Dex.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Dex.score += 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        }
                        else if (Con.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Con.score += 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        }
                        else if (Int.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Int.score += 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        }
                        else if (Wis.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Wis.score += 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        }
                        else if (Cha.score < 15 && points >= 2)
                        {
                            points -= 2;
                            Cha.score += 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Str.score > 13)
                        {
                            points += 2;
                            Str.score -= 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Str.score -= 1;
                            str.text = Str.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Dex.score > 13)
                        {
                            points += 2;
                            Dex.score -= 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Dex.score -= 1;
                            dex.text = Dex.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Con.score > 13)
                        {
                            points += 2;
                            Con.score -= 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Con.score -= 1;
                            con.text = Con.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Int.score > 13)
                        {
                            points += 2;
                            Int.score -= 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Int.score -= 1;
                            inte.text = Int.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Wis.score > 13)
                        {
                            points += 2;
                            Wis.score -= 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Wis.score -= 1;
                            wis.text = Wis.score.ToString();
                            totalPointsText.text = points.ToString();
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
                        if (Cha.score > 13)
                        {
                            points += 2;
                            Cha.score -= 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();
                        }
                        else
                        {
                            points += 1;
                            Cha.score -= 1;
                            cha.text = Cha.score.ToString();
                            totalPointsText.text = points.ToString();
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

    public void FinishButton()
    {
        bool playerIsSure = true;
        if(points > 0)
        {
            //show something asking if player is sure they want to continue even with extra points left behind

            if(points > 420)//if player chooses yes, current code there to reduce errors
            {
                playerIsSure = true;
            }
            else
            {
                playerIsSure = false;
            }
        }

        if(playerIsSure == true)
        {
            //racialBonus = character.raceBonuses;???
            //add racialBonus to respective ability scores
            //save the scores to a character sheet or something
            //move to next scene
        }

    }
}
