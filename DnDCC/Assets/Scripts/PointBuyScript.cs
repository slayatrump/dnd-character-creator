using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBuyScript : MonoBehaviour
{

    //Might be better for this to have its own script for use in other areas, but ill keep it here for now
    public class Attribute
    {
        public int score;
        public int modifier;
    }

    public int points;
    public Attribute Str;
    public Attribute Dex;
    public Attribute Con;
    public Attribute Int;
    public Attribute Wis;
    public Attribute Cha;

    public void Start()
    {
        //For loading a character, this may need to change
        Str.score = 8;
        Dex.score = 8;
        Con.score = 8;
        Int.score = 8;
        Wis.score = 8;
        Cha.score = 8;

        points = 27;
    }

    public void AddButton(Attribute scor)
    {
        //0-13 costs 1 point, 14-15 costs 2, cant go over 15 with point buy
        if (points > 0)
        {
            if(scor.score < 13)
            {
                points -= 1;
                scor.score += 1;
            }
            else if (scor.score < 15 && points >= 2)
            {
                points -= 2;
                scor.score += 1;
            }
            else
            {
                //cant go over 15
            }
        }
    }

    public void SubtractButton(Attribute scor)
    {
        if(scor.score > 8)
        {
            if(scor.score > 13)
            {
                points += 2;
                scor.score -= 1;
            }
            else
            {
                points += 1;
                scor.score -= 1;
            }
        }
        else
        {
            //cant go under 8
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
