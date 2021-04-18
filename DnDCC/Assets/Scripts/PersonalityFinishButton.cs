using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersonalityFinishButton : MonoBehaviour
{
    private GameObject canva;
    // Start is called before the first frame update
    void Start()
    {
        canva = transform.parent.GetChild(1).gameObject;
    }

    public void FinishButton()
    {
        //Check if character name has an input yet
        if(canva.transform.GetChild(4).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text == "")
        {
            return;
        }
        //Set all the save data
        SaveManager.instance.gameData.personalityTraits = canva.transform.GetChild(0).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;
        SaveManager.instance.gameData.ideals = canva.transform.GetChild(1).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;
        SaveManager.instance.gameData.bonds = canva.transform.GetChild(2).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;
        SaveManager.instance.gameData.flaws = canva.transform.GetChild(3).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;
        SaveManager.instance.gameData.characterName = canva.transform.GetChild(4).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;
        SaveManager.instance.gameData.playerName = canva.transform.GetChild(5).GetChild(0).GetChild(2).GetComponentInChildren<Text>().text;

        //Move to display scene
        SceneManager.LoadScene("FinishedCharacter");
    }
}
