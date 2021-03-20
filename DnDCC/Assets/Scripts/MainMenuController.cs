using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    GameObject mStrips;
    GameObject oStrips;

    private bool isOptionsActive;

    public void Start()
    {
        mStrips = GameObject.Find("MMStrips");
        oStrips = GameObject.Find("OptionsStrips");

        oStrips.SetActive(false);
        isOptionsActive = false;
    }

    public void NewCharacter()
    {
        SaveManager.instance.DeleteSavedData();
        SaveManager.instance.gameData.saveName = "save1.dat";
        SaveManager.instance.Save();
        SceneManager.LoadScene(1);
    }

    public void LoadCharacter()
    {
        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + SaveManager.instance.gameData.saveName + ".dat"))
        {
            SceneManager.LoadScene(12);
        }
    }

    public void Options()
    {
        if (isOptionsActive == true)
        {
            mStrips.SetActive(true);
            oStrips.SetActive(false);
            isOptionsActive = false;
        }
        else
        {
            mStrips.SetActive(false);
            oStrips.SetActive(true);
            isOptionsActive = true;
        }
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
