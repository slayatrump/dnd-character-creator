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
            SceneManager.LoadScene(4);
            SelectionController.isSelected = false;
        }
    }
    public void ASToFeatures()
    {
        SceneManager.LoadScene(7);
    }
}
