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
    public TMP_Text randoNum;

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

    private int die1;
    private int die2;
    private int die3;
    private int die4;

    public void Start()
    {
        rr1.GetComponentInChildren<TMP_Text>().text = "Reroll 1's: X";
        rr2.GetComponentInChildren<TMP_Text>().text = "Reroll 2's: X";

        checkmark1.gameObject.SetActive(false);

        rerollOnes = false;
        rerollTwos = false;

        scores = new int[6];
        //RollScores();
    }

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
}
