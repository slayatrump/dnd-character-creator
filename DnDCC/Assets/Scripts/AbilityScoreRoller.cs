using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScoreRoller : MonoBehaviour
{
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
        scores = new int[6];
        RollScores();
    }

    //Dont know if this will actually get used, but ill keep it here just in case
    public void RollScoresButton()
    {
        RollScores();
    }

    private void RollScores()
    {
        System.Random random = new System.Random();
        if(rerollOnes)
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
        else if(rerollTwos)
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
}
