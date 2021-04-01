using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class AbilityScoreRoller : MonoBehaviour
{
    //Reroll Buttons
    public Button rr1;
    public Button rr2;

    //Checkmarks for reroll buttons
    public Image checkmark1;
    public Image checkmark2;

    //Some DM's alllow rerolling of low numbers
    public bool rerollOnes;
    public bool rerollTwos;

    //4d6 Scores 
    public int[] scores;

    //Event System name check
    string select;

    //Modifier and Reset Buttons
    public static Button modifier;
    public static Button reset;
    public static int asMethodChoice;

    #region 4d6 Scores
    private GameObject num1;
    private GameObject num2;
    private GameObject num3;
    private GameObject num4;
    private GameObject num5;
    private GameObject num6;
    #endregion

    #region 4d6 Score Text Fields
    TMP_Text randoNum1;
    TMP_Text randoNum2;
    TMP_Text randoNum3;
    TMP_Text randoNum4;
    TMP_Text randoNum5;
    TMP_Text randoNum6;
    #endregion

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

    #region Original positions of scores
    private Vector2 ogPos1;
    private Vector2 ogPos2;
    private Vector2 ogPos3;
    private Vector2 ogPos4;
    private Vector2 ogPos5;
    private Vector2 ogPos6;
    #endregion

    #region Dices
    private int die1;
    private int die2;
    private int die3;
    private int die4;
    #endregion

    public void Start()
    {

        rr1.GetComponentInChildren<TMP_Text>().text = "Reroll 1's: X";
        rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 2's: X";

        #region Finding Various Objects and Text Fields
        num1 = GameObject.Find("n1");
        num2 = GameObject.Find("n2");
        num3 = GameObject.Find("n3");
        num4 = GameObject.Find("n4");
        num5 = GameObject.Find("n5");
        num6 = GameObject.Find("n6");

        randoNum1 = GameObject.Find("Rando1").GetComponent<TMP_Text>();
        randoNum2 = GameObject.Find("Rando2").GetComponent<TMP_Text>();
        randoNum3 = GameObject.Find("Rando3").GetComponent<TMP_Text>();
        randoNum4 = GameObject.Find("Rando4").GetComponent<TMP_Text>();
        randoNum5 = GameObject.Find("Rando5").GetComponent<TMP_Text>();
        randoNum6 = GameObject.Find("Rando6").GetComponent<TMP_Text>();
        #endregion

        #region Setting original postions of score object
        ogPos1 = new Vector2(num1.transform.position.x, num1.transform.position.y);
        ogPos2 = new Vector2(num2.transform.position.x, num2.transform.position.y);
        ogPos3 = new Vector2(num3.transform.position.x, num3.transform.position.y);
        ogPos4 = new Vector2(num4.transform.position.x, num4.transform.position.y);
        ogPos5 = new Vector2(num5.transform.position.x, num5.transform.position.y);
        ogPos6 = new Vector2(num6.transform.position.x, num6.transform.position.y);
        #endregion

        modifier = GameObject.Find("Modifier").GetComponent<Button>();
        modifier.enabled = false;
        modifier.GetComponentInChildren<TMP_Text>().text = "Roll and Place Scores First";
        modifier.GetComponent<Image>().color = Color.gray;

        reset = GameObject.Find("ResetPosButton").GetComponent<Button>();
        reset.enabled = false;
        reset.GetComponent<Image>().color = Color.gray;

        checkmark1.gameObject.SetActive(false);

        rerollOnes = false;
        rerollTwos = false;

        scores = new int[6];
    }

    public void RollScoresButton()
    {
        RollScores();

        randoNum1.text = scores[0].ToString();
        randoNum2.text = scores[1].ToString();
        randoNum3.text = scores[2].ToString();
        randoNum4.text = scores[3].ToString();
        randoNum5.text = scores[4].ToString();
        randoNum6.text = scores[5].ToString();
    }

    private void RollScores()
    {
        reset.GetComponent<Image>().color = Color.gray;
        System.Random random = new System.Random();
        if(rerollOnes && !rerollTwos)
        {
            //calculates 6 scores
            for (int i = 0; i <= 5; i++)
            {
                die1 = random.Next(2, 7);
                die2 = random.Next(2, 7);
                die3 = random.Next(2, 7);
                die4 = random.Next(2, 7);

                //Finds total score minus the smallest roll
                scores[i] = die1 + die2 + die3 + die4 - Mathf.Min(die1, die2, die3, die4);
            }
        }
        else if(rerollOnes && rerollTwos)
        {
            rerollOnes = true;

            //calculates 6 scores
            for (int i = 0; i <= 5; i++)
            {
                die1 = random.Next(3, 7);
                die2 = random.Next(3, 7);
                die3 = random.Next(3, 7);
                die4 = random.Next(3, 7);

                //Finds total score minus the smallest roll
                scores[i] = die1 + die2 + die3 + die4 - Mathf.Min(die1, die2, die3, die4);
            }
        }
        else
        {
            //calculates 6 scores
            for(int i = 0; i <= 5; i ++)
            {
                die1 = random.Next(1, 7);
                die2 = random.Next(1, 7);
                die3 = random.Next(1, 7);
                die4 = random.Next(1, 7);

                //Finds total score minus the smallest roll
                scores[i] = die1 + die2 + die3 + die4 - Mathf.Min(die1, die2, die3, die4);
            }
        }
    }

    public void Reroll1Check()
    {
        select = EventSystem.current.currentSelectedGameObject.name;

        if (select == "Reroll1Button" && rerollOnes != true)
        {
            rerollOnes = true;
            rr1.GetComponentInChildren<TMP_Text>().text = "Reroll 1's:  _";
            rr1.GetComponentInChildren<Image>().gameObject.SetActive(true);
            rr1.GetComponent<Image>().color = Color.green;
            checkmark1.gameObject.SetActive(true);
            rr2.gameObject.SetActive(true);
            checkmark2.gameObject.SetActive(false);
        }
        else 
        {
            rerollOnes = false;
            rerollTwos = false;
            rr1.GetComponentInChildren<TMP_Text>().text = "Reroll 1's: X";
            rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 1's: X";
            rr1.GetComponent<Image>().color = Color.white;
            rr2.GetComponent<Image>().color = Color.white;
            rr2.gameObject.SetActive(false);
            checkmark1.gameObject.SetActive(false);
        }
    }

    public void Reroll2Check()
    {
        select = EventSystem.current.currentSelectedGameObject.name;

        if (select == "Reroll2Button" && rerollOnes == true && rerollTwos != true)
        {
            rerollTwos = true;
            rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 2's:  _";
            rr2.GetComponent<Image>().color = Color.green;
            checkmark2.gameObject.SetActive(true);
        }
        else
        {
            rerollTwos = false;
            rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 2's: X";
            rr2.GetComponent<Image>().color = Color.white;
            checkmark2.gameObject.SetActive(false);
        }
    }

    public void ResetPosition()
    {
        #region Resetting Positions, Buttons and Variables Values
        num1.transform.position = ogPos1;
        num2.transform.position = ogPos2;
        num3.transform.position = ogPos3;
        num4.transform.position = ogPos4;
        num5.transform.position = ogPos5;
        num6.transform.position = ogPos6;

        DropSlot.rollBTN.enabled = true;
        DropSlot.rollBTN.GetComponentInChildren<TMP_Text>().text = "Roll for scores to display";
        DropSlot.rollBTN.GetComponent<Image>().color = Color.white;

        modifier.enabled = false;
        modifier.GetComponentInChildren<TMP_Text>().text = "Roll and Place First";
        modifier.GetComponent<Image>().color = Color.gray;

        SaveManager.instance.gameData.strScore = 0;
        SaveManager.instance.gameData.dexScore = 0;
        SaveManager.instance.gameData.conScore = 0;
        SaveManager.instance.gameData.intScore = 0;
        SaveManager.instance.gameData.wisScore = 0;
        SaveManager.instance.gameData.chaScore = 0;

        for (int s = 0; s < 6; s++)
        {
            scores[s] = 0;
        }
        randoNum1.text = scores[0].ToString();
        randoNum2.text = scores[1].ToString();
        randoNum3.text = scores[2].ToString();
        randoNum4.text = scores[3].ToString();
        randoNum5.text = scores[4].ToString();
        randoNum6.text = scores[5].ToString();
        #endregion
    }

    public void FinalScores()
    {
        CalcModifiers();

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
        strModFinalScore.text = SaveManager.instance.gameData.strMod.ToString();
        dexFinalScore.text = SaveManager.instance.gameData.dexScore.ToString();
        dexModFinalScore.text = SaveManager.instance.gameData.dexMod.ToString();
        conFinalScore.text = SaveManager.instance.gameData.conScore.ToString();
        conModFinalScore.text = SaveManager.instance.gameData.conMod.ToString();
        intFinalScore.text = SaveManager.instance.gameData.intScore.ToString();
        intModFinalScore.text = SaveManager.instance.gameData.intMod.ToString();
        wisFinalScore.text = SaveManager.instance.gameData.wisScore.ToString();
        wisModFinalScore.text = SaveManager.instance.gameData.wisMod.ToString();
        chaFinalScore.text = SaveManager.instance.gameData.chaScore.ToString();
        chaModFinalScore.text = SaveManager.instance.gameData.chaMod.ToString();
        #endregion
    }

    private void CalcModifiers()
    {
        #region Str Mod Calc
        if (SaveManager.instance.gameData.strScore == 24)
        {
            SaveManager.instance.gameData.strMod = 7;
        }
        else if (SaveManager.instance.gameData.strScore == 22 || SaveManager.instance.gameData.strScore == 23)
        {
            SaveManager.instance.gameData.strMod = 6;
        }
        else if (SaveManager.instance.gameData.strScore == 20 || SaveManager.instance.gameData.strScore == 21)
        {
            SaveManager.instance.gameData.strMod = 5;
        }
        else if (SaveManager.instance.gameData.strScore == 18 || SaveManager.instance.gameData.strScore == 19)
        {
            SaveManager.instance.gameData.strMod = 4;
        }
        else if (SaveManager.instance.gameData.strScore == 16 || SaveManager.instance.gameData.strScore == 17)
        {
            SaveManager.instance.gameData.strMod = 3;
        }
        else if (SaveManager.instance.gameData.strScore == 14 || SaveManager.instance.gameData.strScore == 15)
        {
            SaveManager.instance.gameData.strMod = 2;
        }
        else if (SaveManager.instance.gameData.strScore == 12 || SaveManager.instance.gameData.strScore == 13)
        {
            SaveManager.instance.gameData.strMod = 1;
        }
        else if (SaveManager.instance.gameData.strScore == 10 || SaveManager.instance.gameData.strScore == 11)
        {
            SaveManager.instance.gameData.strMod = 0;
        }
        else if (SaveManager.instance.gameData.strScore == 8 || SaveManager.instance.gameData.strScore == 9)
        {
            SaveManager.instance.gameData.strMod = -1;
        }
        else if (SaveManager.instance.gameData.strScore == 6 || SaveManager.instance.gameData.strScore == 7)
        {
            SaveManager.instance.gameData.strMod = -2;
        }
        else if (SaveManager.instance.gameData.strScore == 4 || SaveManager.instance.gameData.strScore == 5)
        {
            SaveManager.instance.gameData.strMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.strMod = 0;
        }
        #endregion

        #region Dex Mod Calc
        if (SaveManager.instance.gameData.dexScore == 24)
        {
            SaveManager.instance.gameData.dexMod = 7;
        }
        else if (SaveManager.instance.gameData.dexScore == 22 || SaveManager.instance.gameData.dexScore == 23)
        {
            SaveManager.instance.gameData.dexMod = 6;
        }
        else if (SaveManager.instance.gameData.dexScore == 20 || SaveManager.instance.gameData.dexScore == 21)
        {
            SaveManager.instance.gameData.dexMod = 5;
        }
        else if (SaveManager.instance.gameData.dexScore == 18 || SaveManager.instance.gameData.dexScore == 19)
        {
            SaveManager.instance.gameData.dexMod = 4;
        }
        else if (SaveManager.instance.gameData.dexScore == 16 || SaveManager.instance.gameData.dexScore == 17)
        {
            SaveManager.instance.gameData.dexMod = 3;
        }
        else if (SaveManager.instance.gameData.dexScore == 14 || SaveManager.instance.gameData.dexScore == 15)
        {
            SaveManager.instance.gameData.dexMod = 2;
        }
        else if (SaveManager.instance.gameData.dexScore == 12 || SaveManager.instance.gameData.dexScore == 13)
        {
            SaveManager.instance.gameData.dexMod = 1;
        }
        else if (SaveManager.instance.gameData.dexScore == 10 || SaveManager.instance.gameData.dexScore == 11)
        {
            SaveManager.instance.gameData.dexMod = 0;
        }
        else if (SaveManager.instance.gameData.strScore == 8 || SaveManager.instance.gameData.strScore == 9)
        {
            SaveManager.instance.gameData.dexMod = -1;
        }
        else if (SaveManager.instance.gameData.strScore == 6 || SaveManager.instance.gameData.strScore == 7)
        {
            SaveManager.instance.gameData.dexMod = -2;
        }
        else if (SaveManager.instance.gameData.strScore == 4 || SaveManager.instance.gameData.strScore == 5)
        {
            SaveManager.instance.gameData.dexMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.dexMod = 0;
        }
        #endregion

        #region Con Mod Calc
        if (SaveManager.instance.gameData.conScore == 24)
        {
            SaveManager.instance.gameData.conMod = 7;
        }
        else if (SaveManager.instance.gameData.conScore == 22 || SaveManager.instance.gameData.conScore == 23)
        {
            SaveManager.instance.gameData.conMod = 6;
        }
        else if (SaveManager.instance.gameData.conScore == 20 || SaveManager.instance.gameData.conScore == 21)
        {
            SaveManager.instance.gameData.conMod = 5;
        }
        else if (SaveManager.instance.gameData.conScore == 18 || SaveManager.instance.gameData.conScore == 19)
        {
            SaveManager.instance.gameData.conMod = 4;
        }
        else if (SaveManager.instance.gameData.conScore == 16 || SaveManager.instance.gameData.conScore == 17)
        {
            SaveManager.instance.gameData.conMod = 3;
        }
        else if (SaveManager.instance.gameData.conScore == 14 || SaveManager.instance.gameData.conScore == 15)
        {
            SaveManager.instance.gameData.conMod = 2;
        }
        else if (SaveManager.instance.gameData.conScore == 12 || SaveManager.instance.gameData.conScore == 13)
        {
            SaveManager.instance.gameData.conMod = 1;
        }
        else if (SaveManager.instance.gameData.conScore == 10 || SaveManager.instance.gameData.conScore == 11)
        {
            SaveManager.instance.gameData.conMod = 0;
        }
        else if (SaveManager.instance.gameData.conScore == 8 || SaveManager.instance.gameData.conScore == 9)
        {
            SaveManager.instance.gameData.conMod = -1;
        }
        else if (SaveManager.instance.gameData.conScore == 6 || SaveManager.instance.gameData.conScore == 7)
        {
            SaveManager.instance.gameData.conMod = -2;
        }
        else if (SaveManager.instance.gameData.conScore == 4 || SaveManager.instance.gameData.conScore == 5)
        {
            SaveManager.instance.gameData.conMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.conMod = 0;
        }
        #endregion

        #region Int Mod Calc
        if (SaveManager.instance.gameData.intScore == 24)
        {
            SaveManager.instance.gameData.intMod = 7;
        }
        else if (SaveManager.instance.gameData.intScore == 22 || SaveManager.instance.gameData.intScore == 23)
        {
            SaveManager.instance.gameData.intMod = 6;
        }
        else if (SaveManager.instance.gameData.intScore == 20 || SaveManager.instance.gameData.intScore == 21)
        {
            SaveManager.instance.gameData.intMod = 5;
        }
        else if (SaveManager.instance.gameData.intScore == 18 || SaveManager.instance.gameData.intScore == 19)
        {
            SaveManager.instance.gameData.intMod = 4;
        }
        else if (SaveManager.instance.gameData.intScore == 16 || SaveManager.instance.gameData.intScore == 17)
        {
            SaveManager.instance.gameData.intMod = 3;
        }
        else if (SaveManager.instance.gameData.intScore == 14 || SaveManager.instance.gameData.intScore == 15)
        {
            SaveManager.instance.gameData.intMod = 2;
        }
        else if (SaveManager.instance.gameData.intScore == 12 || SaveManager.instance.gameData.intScore == 13)
        {
            SaveManager.instance.gameData.intMod = 1;
        }
        else if (SaveManager.instance.gameData.intScore == 10 || SaveManager.instance.gameData.intScore == 11)
        {
            SaveManager.instance.gameData.intMod = 0;
        }
        else if (SaveManager.instance.gameData.intScore == 8 || SaveManager.instance.gameData.intScore == 9)
        {
            SaveManager.instance.gameData.intMod = -1;
        }
        else if (SaveManager.instance.gameData.intScore == 6 || SaveManager.instance.gameData.intScore == 7)
        {
            SaveManager.instance.gameData.intMod = -2;
        }
        else if (SaveManager.instance.gameData.intScore == 4 || SaveManager.instance.gameData.intScore == 5)
        {
            SaveManager.instance.gameData.intMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.intMod = 0;
        }
        #endregion

        #region Wis Mod Calc
        if (SaveManager.instance.gameData.wisScore == 24)
        {
            SaveManager.instance.gameData.wisMod = 7;
        }
        else if (SaveManager.instance.gameData.wisScore == 22 || SaveManager.instance.gameData.wisScore == 23)
        {
            SaveManager.instance.gameData.wisMod = 6;
        }
        else if (SaveManager.instance.gameData.wisScore == 20 || SaveManager.instance.gameData.wisScore == 21)
        {
            SaveManager.instance.gameData.wisMod = 5;
        }
        else if (SaveManager.instance.gameData.wisScore == 18 || SaveManager.instance.gameData.wisScore == 19)
        {
            SaveManager.instance.gameData.wisMod = 4;
        }
        else if (SaveManager.instance.gameData.wisScore == 16 || SaveManager.instance.gameData.wisScore == 17)
        {
            SaveManager.instance.gameData.wisMod = 3;
        }
        else if (SaveManager.instance.gameData.wisScore == 14 || SaveManager.instance.gameData.wisScore == 15)
        {
            SaveManager.instance.gameData.wisMod = 2;
        }
        else if (SaveManager.instance.gameData.wisScore == 12 || SaveManager.instance.gameData.wisScore == 13)
        {
            SaveManager.instance.gameData.wisMod = 1;
        }
        else if (SaveManager.instance.gameData.wisScore == 10 || SaveManager.instance.gameData.wisScore == 11)
        {
            SaveManager.instance.gameData.wisMod = 0;
        }
        else if (SaveManager.instance.gameData.wisScore == 8 || SaveManager.instance.gameData.wisScore == 9)
        {
            SaveManager.instance.gameData.wisMod = -1;
        }
        else if (SaveManager.instance.gameData.wisScore == 6 || SaveManager.instance.gameData.wisScore == 7)
        {
            SaveManager.instance.gameData.wisMod = -2;
        }
        else if (SaveManager.instance.gameData.wisScore == 4 || SaveManager.instance.gameData.wisScore == 5)
        {
            SaveManager.instance.gameData.wisMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.wisMod = 0;
        }
        #endregion

        #region Cha Mod Calc
        if (SaveManager.instance.gameData.chaScore == 24)
        {
            SaveManager.instance.gameData.chaMod = 7;
        }
        else if (SaveManager.instance.gameData.chaScore == 22 || SaveManager.instance.gameData.chaScore == 23)
        {
            SaveManager.instance.gameData.chaMod = 6;
        }
        else if (SaveManager.instance.gameData.chaScore == 20 || SaveManager.instance.gameData.chaScore == 21)
        {
            SaveManager.instance.gameData.chaMod = 5;
        }
        else if (SaveManager.instance.gameData.chaScore == 18 || SaveManager.instance.gameData.chaScore == 19)
        {
            SaveManager.instance.gameData.chaMod = 4;
        }
        else if (SaveManager.instance.gameData.chaScore == 16 || SaveManager.instance.gameData.chaScore == 17)
        {
            SaveManager.instance.gameData.chaMod = 3;
        }
        else if (SaveManager.instance.gameData.chaScore == 14 || SaveManager.instance.gameData.chaScore == 15)
        {
            SaveManager.instance.gameData.chaMod = 2;
        }
        else if (SaveManager.instance.gameData.chaScore == 12 || SaveManager.instance.gameData.chaScore == 13)
        {
            SaveManager.instance.gameData.chaMod = 1;
        }
        else if (SaveManager.instance.gameData.chaScore == 10 || SaveManager.instance.gameData.chaScore == 11)
        {
            SaveManager.instance.gameData.chaMod = 0;
        }
        else if (SaveManager.instance.gameData.chaScore == 8 || SaveManager.instance.gameData.chaScore == 9)
        {
            SaveManager.instance.gameData.chaMod = -1;
        }
        else if (SaveManager.instance.gameData.chaScore == 6 || SaveManager.instance.gameData.chaScore == 7)
        {
            SaveManager.instance.gameData.chaMod = -2;
        }
        else if (SaveManager.instance.gameData.chaScore == 4 || SaveManager.instance.gameData.chaScore == 5)
        {
            SaveManager.instance.gameData.chaMod = -3;
        }
        else
        {
            SaveManager.instance.gameData.chaMod = 0;
        }
        #endregion
    }

    public static void SavingScores()
    {
        SaveManager.instance.Save();
    }
}
