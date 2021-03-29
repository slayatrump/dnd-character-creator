﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class MenuController : MonoBehaviour
{
    public GameObject warning;

    private void Start()
    {
        if (warning == null)
        {
            return;
        }
    }

    public void RaceToClass()
    {
        string savePath = Application.persistentDataPath;

        if (SelectionController.isSelected == false && !File.Exists(savePath + "/" + SaveManager.instance.gameData.saveName + ".dat"))
        {
            warning.SetActive(true);
        }
        else
        {
            Race.SaveRace();
            SelectionController.isSelected = false;
            SceneManager.LoadScene(2);
        }
    }

    public void ClassToBackground()
    {
        FirstLevelClass.SavingClassData();
        SceneManager.LoadScene(3);
    }

    public void ASToFeatures()
    {
        if (SaveManager.instance.gameData.asMethodChoice == "4d6 Method")
        {
            if (AbilityScoreRoller.strFinalScore.text != "0" && AbilityScoreRoller.dexFinalScore.text != "0"
            && AbilityScoreRoller.conFinalScore.text != "0" && AbilityScoreRoller.intFinalScore.text != "0"
            && AbilityScoreRoller.wisFinalScore.text != "0" && AbilityScoreRoller.chaFinalScore.text != "0")
            {
                AbilityScoreRoller.SavingScores();
                SceneManager.LoadScene(5);
            }
            else
            {
                warning.SetActive(true);
            }
        }
        if (SaveManager.instance.gameData.asMethodChoice == "Point Buy Method")
        {
            if (PointBuyScript.strFinalScore.text != "0" && PointBuyScript.dexFinalScore.text != "0"
            && PointBuyScript.conFinalScore.text != "0" && PointBuyScript.intFinalScore.text != "0"
            && PointBuyScript.wisFinalScore.text != "0" && PointBuyScript.chaFinalScore.text != "0")
            {
                PointBuyScript.SavingScores();
                SceneManager.LoadScene(5);
            }
            else
            {
                warning.SetActive(true);
            }
        }
        
    }
}
