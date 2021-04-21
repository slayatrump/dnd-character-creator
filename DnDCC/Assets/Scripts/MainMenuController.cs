using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    GameObject mStrips;

    public GameObject warningPanel;
    public TMP_Text message;

    public Button back1;
    public Button back2;
    public Button cont1;

    public void Start()
    {
        mStrips = GameObject.Find("MMStrips");
    }

    public void NewCharacter()
    {
        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + SaveManager.instance.gameData.saveName + ".dat"))
        {
            warningPanel.SetActive(true);
            message.text = "There is already a save file on this machine.\n" +
                "If you wish to continue with creating a new character, " +
                "that existing file will be deleted.\n" +
                "Continue On or Go Back?";
            back1.gameObject.SetActive(true);
            back2.gameObject.SetActive(false);
            cont1.gameObject.SetActive(true);
        }
        else
        {
            SaveManager.instance.DeleteSavedData();
            SceneManager.LoadScene(1);
        }
    }

    public void LoadCharacter()
    {
        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + SaveManager.instance.gameData.saveName + ".dat"))
        {
            SceneManager.LoadScene(8);
        }
        else
        {
            warningPanel.SetActive(true);
            message.text = "There is no saved file on this machine.\n" +
                "Please go back and select New Character.";
            back1.gameObject.SetActive(false);
            back2.gameObject.SetActive(true);
            cont1.gameObject.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
