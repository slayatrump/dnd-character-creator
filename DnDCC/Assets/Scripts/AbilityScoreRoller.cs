using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class AbilityScoreRoller : MonoBehaviour
{
    //Textbox for the scores to display on
    //public TMP_Text randoNum;

    //Checkboxes
    public Button rr1;
    public Button rr2;

    public Image checkmark1;
    public Image checkmark2;

    //Some DM's alllow rerolling of low numbers
    public bool rerollOnes;
    public bool rerollTwos;

    public int[] scores;
    public int sum;

    string select;


    TMP_Text randoNum1;
    TMP_Text randoNum2;
    TMP_Text randoNum3;
    TMP_Text randoNum4;
    TMP_Text randoNum5;
    TMP_Text randoNum6;

    TMP_Text savedStrScore;

    #region Final Score Text and Modifiers Text
    TMP_Text strFinalScore;
    TMP_Text dexFinalScore;
    TMP_Text conFinalScore;
    TMP_Text intFinalScore;
    TMP_Text wisFinalScore;
    TMP_Text chaFinalScore;

    TMP_Text strModFinalScore;
    TMP_Text dexModFinalScore;
    TMP_Text conModFinalScore;
    TMP_Text intModFinalScore;
    TMP_Text wisModFinalScore;
    TMP_Text chaModFinalScore;
    #endregion

    private Vector2 ogPos1;
    private Vector2 ogPos2;
    private Vector2 ogPos3;
    private Vector2 ogPos4;
    private Vector2 ogPos5;
    private Vector2 ogPos6;

    private GameObject num1;
    private GameObject num2;
    private GameObject num3;
    private GameObject num4;
    private GameObject num5;
    private GameObject num6;

    private int die1;
    private int die2;
    private int die3;
    private int die4;

    public void Start()
    {

        rr1.GetComponentInChildren<TMP_Text>().text = "Reroll 1's: X";
        rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 2's: X";

        num1 = GameObject.Find("n1");
        num2 = GameObject.Find("n2");
        num3 = GameObject.Find("n3");
        num4 = GameObject.Find("n4");
        num5 = GameObject.Find("n5");
        num6 = GameObject.Find("n6");

        ogPos1 = new Vector2(num1.transform.position.x, num1.transform.position.y);
        ogPos2 = new Vector2(num2.transform.position.x, num2.transform.position.y);
        ogPos3 = new Vector2(num3.transform.position.x, num3.transform.position.y);
        ogPos4 = new Vector2(num4.transform.position.x, num4.transform.position.y);
        ogPos5 = new Vector2(num5.transform.position.x, num5.transform.position.y);
        ogPos6 = new Vector2(num6.transform.position.x, num6.transform.position.y);

        randoNum1 = GameObject.Find("Rando1").GetComponent<TMP_Text>();
        randoNum2 = GameObject.Find("Rando2").GetComponent<TMP_Text>();
        randoNum3 = GameObject.Find("Rando3").GetComponent<TMP_Text>();
        randoNum4 = GameObject.Find("Rando4").GetComponent<TMP_Text>();
        randoNum5 = GameObject.Find("Rando5").GetComponent<TMP_Text>();
        randoNum6 = GameObject.Find("Rando6").GetComponent<TMP_Text>();
        savedStrScore = GameObject.Find("SavedStrScore").GetComponent<TMP_Text>();

        //savedStrScore.text = "Str Score: " + SaveManager.instance.gameData.strScore.ToString();

        checkmark1.gameObject.SetActive(false);

        rerollOnes = false;
        rerollTwos = false;

        scores = new int[6];
    }

    public void RollScoresButton()
    {
        RollScores();
        //randoNum.text = scores[0].ToString() + ", " + scores[1].ToString() + ", " + scores[2].ToString()
        //    + ", " + scores[3].ToString() + ", " + scores[4].ToString() + ", " + scores[5].ToString()
        //    + " = " + sum;

        randoNum1.text = scores[0].ToString();
        randoNum2.text = scores[1].ToString();
        randoNum3.text = scores[2].ToString();
        randoNum4.text = scores[3].ToString();
        randoNum5.text = scores[4].ToString();
        randoNum6.text = scores[5].ToString();
    }

    private void RollScores()
    {
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
        sum = scores.Sum();
        savedStrScore.text = "Str Score: " + SaveManager.instance.gameData.strScore.ToString();
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
        num1.transform.position = ogPos1;
        num2.transform.position = ogPos2;
        num3.transform.position = ogPos3;
        num4.transform.position = ogPos4;
        num5.transform.position = ogPos5;
        num6.transform.position = ogPos6;

        DropSlot.rollBTN.enabled = true;
        DropSlot.rollBTN.GetComponentInChildren<TMP_Text>().text = "ROLL DAMNIT!";
        DropSlot.rollBTN.GetComponent<Image>().color = Color.white;
    }

    public void FinalScores()
    {
        CalcModifiers();

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
    }

    private void CalcModifiers()
    {
        #region Str Mod
        if (SaveManager.instance.gameData.strScore == 16 || SaveManager.instance.gameData.strScore == 17)
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
        #endregion

        #region Dex Mod
        if (SaveManager.instance.gameData.dexScore == 16 || SaveManager.instance.gameData.dexScore == 17)
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
        else if (SaveManager.instance.gameData.dexScore == 8 || SaveManager.instance.gameData.dexScore == 9)
        {
            SaveManager.instance.gameData.dexMod = -1;
        }
        else if (SaveManager.instance.gameData.dexScore == 6 || SaveManager.instance.gameData.dexScore == 7)
        {
            SaveManager.instance.gameData.dexMod = -2;
        }
        #endregion

        #region Con Mod
        if (SaveManager.instance.gameData.conScore == 16 || SaveManager.instance.gameData.conScore == 17)
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
        #endregion

        #region Int Mod
        if (SaveManager.instance.gameData.intScore == 16 || SaveManager.instance.gameData.intScore == 17)
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
        #endregion

        #region Wis Mod
        if (SaveManager.instance.gameData.wisScore == 16 || SaveManager.instance.gameData.wisScore == 17)
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
        #endregion

        #region Cha Mod
        if (SaveManager.instance.gameData.chaScore == 16 || SaveManager.instance.gameData.chaScore == 17)
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
        #endregion
    }
}
