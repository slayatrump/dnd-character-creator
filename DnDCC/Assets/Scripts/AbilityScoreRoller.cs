using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AbilityScoreRoller : MonoBehaviour
{
    //Textbox for the scores to display on
    public TMP_Text randoNum;

    //Checkboxes
    public Toggle rr1;
    public Toggle rr2;

    //Some DM's alllow rerolling of low numbers
    public bool rerollOnes;
    public bool rerollTwos;

    /*public int score1;
    public int score2;
    public int score3;
    public int score4;
    public int score5;
    public int score6;*/

    public int[] scores;
    public int sum;

    private int die1;
    private int die2;
    private int die3;
    private int die4;

    /*public AbilityScoreRoller(bool rerollones, bool rerolltwos)
    {
        rerollOnes = rerollones;
        rerollTwos = rerolltwos;
    }*/

    public void Start()
    {
        rr1.GetComponentInChildren<Text>().text = "Reroll 1's: X";
        rr2.GetComponentInChildren<Text>().text = "Reroll 2's: X";

        scores = new int[6];
        RollScores();
    }

    //Dont know if this will actually get used, but ill keep it here just in case
    public void RollScoresButton()
    {
        RollScores();
        randoNum.text = scores[0].ToString() + ", " + scores[1].ToString() + ", " + scores[2].ToString()
            + ", " + scores[3].ToString() + ", " + scores[4].ToString() + ", " + scores[5].ToString()
            + " = " + sum;

        //randoNum.text = "Score 1: " + die1;
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
    }

    public void Reroll1Check()
    {
        //Checks if the checkbox 1 is checked or not
        if (rr1.isOn)
        {
            rerollOnes = true;
            rr1.GetComponentInChildren<Text>().text = "Reroll 1's: ✓";
            rr2.gameObject.SetActive(true);
        }
        else
        {
            rerollOnes = false;
            rr1.GetComponentInChildren<Text>().text = "Reroll 1's: X";
            rr2.gameObject.SetActive(false);
            rr2.isOn = false;
        }
    }

    public void Reroll2Check()
    {
        //Checks if the checkbox 2 is checked or not
        if (rr2.isOn)
        {
            rerollTwos = true;
            rr2.GetComponentInChildren<Text>().text = "Reroll 2's: ✓";
        }
        else
        {
            rerollTwos = false;
            rr2.GetComponentInChildren<Text>().text = "Reroll 2's: X";
        }
    }
}
