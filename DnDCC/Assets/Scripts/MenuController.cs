using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject warning;

    public void RaceToClass()
    {
        if (SelectionController.isSelected == false)
        {
            warning.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(4);
            SelectionController.isSelected = false;
        }
    }
}
