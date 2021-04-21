using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExtraLanguageSelection : MonoBehaviour
{
    List<string> languages;

    public GameObject checkBox;

    private void Start()
    {
        languages = new List<string>();

        languages.Clear();

        languages.Add("Common");
        languages.Add("Dwarvish");
        languages.Add("Elvish");
        languages.Add("Giant");
        languages.Add("Gnomish");
        languages.Add("Goblin");
        languages.Add("Halfling");
        languages.Add("Orc");

        foreach (string l in languages)
        {
            GameObject check = Instantiate(checkBox);
            Transform parent = GameObject.Find("ExtraWarning/ScrollPanel/LanguagesList/Scroll").transform;

            check.transform.SetParent(parent, false);

            check.GetComponentInChildren<TMP_Text>().text = l;
            check.name = l;
        }

        GameObject[] checkboxes = GameObject.FindGameObjectsWithTag("SpellCheckbox");

        foreach (GameObject c in checkboxes)
        {
            if (SaveManager.instance.gameData.raceLanguages.Contains(c.name))
            {
                c.SetActive(false);
            }
        }
    }

    public void SelectingLanguage(bool isActive)
    {
        if (isActive)
        {
            SaveManager.instance.gameData.extraLanguageOptions -= 1;
        }
        else
        {
            SaveManager.instance.gameData.extraLanguageOptions += 1;
        }

        GameObject[] checkboxes = GameObject.FindGameObjectsWithTag("SpellCheckbox");

        if (SaveManager.instance.gameData.extraLanguageOptions == 0)
        {
            foreach (GameObject c in checkboxes)
            {
                if (!c.GetComponent<Toggle>().isOn)
                {
                    c.GetComponent<Toggle>().interactable = false;

                    if (SaveManager.instance.gameData.extraLanguageSelection.Contains(c.name))
                    {
                        SaveManager.instance.gameData.extraLanguageSelection.Remove(c.name);
                    }
                }
                else
                {
                    if (!SaveManager.instance.gameData.extraLanguageSelection.Contains(c.name))
                    {
                        SaveManager.instance.gameData.extraLanguageSelection.Add(c.name);
                    }
                }
            }
        }
        else if (SaveManager.instance.gameData.extraLanguageOptions > 0)
        {
            foreach (GameObject c in checkboxes)
            {
                if (!c.GetComponent<Toggle>().isOn)
                {
                    c.GetComponent<Toggle>().interactable = true;

                    if (SaveManager.instance.gameData.extraLanguageSelection.Contains(c.name))
                    {
                        SaveManager.instance.gameData.extraLanguageSelection.Remove(c.name);
                    }
                }
                else
                {
                    if (!SaveManager.instance.gameData.extraLanguageSelection.Contains(c.name))
                    {
                        SaveManager.instance.gameData.extraLanguageSelection.Add(c.name);
                    }
                }
            }
        }
    }
}
