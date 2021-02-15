using System.Collections;
using System.Collections.Generic;
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
        SceneManager.LoadScene(3);
    }

    public void LoadCharacter()
    {
        SceneManager.LoadScene(14);
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
