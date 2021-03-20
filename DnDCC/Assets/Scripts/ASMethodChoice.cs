using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASMethodChoice : MonoBehaviour
{
    public GameObject ASRollerPanel;
    public GameObject PointBuyPanel;
    public GameObject ASMethodChoicePanel;

    private void Start()
    {
        //if (SaveManager.instance.gameData.asMethodChoice == "4d6 Method")
        //{
        //    ASMethodChoicePanel.SetActive(false);
        //    ASRollerPanel.SetActive(true);
        //}
        //if (SaveManager.instance.gameData.asMethodChoice == "Point Buy Method")
        //{
        //    ASMethodChoicePanel.SetActive(false);
        //    PointBuyPanel.SetActive(true);
        //}
    }

    public void RandoRollChoice()
    {
        SaveManager.instance.gameData.asMethodChoice = "4d6 Method";
        SaveManager.instance.Save();
    }

    public void PointBuyMethodChoice()
    {
        SaveManager.instance.gameData.asMethodChoice = "Point Buy Method";
        SaveManager.instance.Save();
    }
}
