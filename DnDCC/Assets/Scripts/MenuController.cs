using System.Collections;
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
            SceneManager.LoadScene(4);
        }
    }
    public void ASToFeatures()
    {
        if (AbilityScoreRoller.strFinalScore.text != "0" && AbilityScoreRoller.dexFinalScore.text != "0"
            && AbilityScoreRoller.conFinalScore.text != "0" && AbilityScoreRoller.intFinalScore.text != "0"
            && AbilityScoreRoller.wisFinalScore.text != "0" && AbilityScoreRoller.chaFinalScore.text != "0")
        {
            AbilityScoreRoller.SavingScore();
            SceneManager.LoadScene(7);
        }
        else
        {
            warning.SetActive(true);
        }
    }
}
