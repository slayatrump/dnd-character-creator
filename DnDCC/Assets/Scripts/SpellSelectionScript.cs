using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalEnums;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class SpellSelectionScript : SpellListController
{
    //the checkbox prefab will be set in the inspector so that it can be instantiated during the population methods
    public GameObject checkboxPrefab;

    Spell spell;

    public int[] numList; //The numbers associated with classes for cantrips and spells

    public string[] allCantrips; //All cantrips
    public string[] allFirstLevel; //All First Level spells

    GameObject[] displayThese; //the cantrips to display

    //Test case at the moment
    //When functional, it should just take the class name from the current save data and use that instead
    public string chosenClass = "Bard"; //SaveManager.instance.gameData.className;

    // Start is called before the first frame update
    void Start()
    {
        numList = new int[2];

        SetNumbers(chosenClass);

        PopCantripList();
        PopSpellList();
    }

    //Methods to set the Cantrip and First Level spell numbers according to chosen class
    #region Setting Spell Numbers
    public void SetNumbers(string chosenClass)
    {
        //array can be increased to 3 if spell slots are needed
        int[] numList = new int[2];

        //Only classes that have spellcasting at the start are shown
        switch (chosenClass)
        {
            case "Bard":
                //spot 0 is Cantrips
                numList[0] = 2;
                //spot 1 is 1st level spells
                numList[1] = 4;
                break;
            case "Cleric":
                //spot 0 is Cantrips
                numList[0] = 3;
                //spot 1 is 1st level spells
                numList[1] = 0;
                break;
            case "Druid":
                //spot 0 is Cantrips
                numList[0] = 2;
                //spot 1 is 1st level spells
                numList[1] = 0;
                break;
            case "Sorcerer":
                //spot 0 is Cantrips
                numList[0] = 4;
                //spot 1 is 1st level spells
                numList[1] = 2;
                break;
            case "Warlock":
                //spot 0 is Cantrips
                numList[0] = 2;
                //spot 1 is 1st level spells
                numList[1] = 2;
                break;
            case "Wizard":
                //spot 0 is Cantrips
                numList[0] = 3;
                //spot 1 is 1st level spells
                numList[1] = 0;
                break;
        }

        //get the text component of labels and change it to array values
        GameObject.Find("Cantrips Number").GetComponent<TextMeshProUGUI>().text = $"{numList[0]}";
        GameObject.Find("1L Number").GetComponent<TextMeshProUGUI>().text = $"{numList[1]}";
    }
    #endregion

    //Methods to grab the appropriate cantrips for the class and then populate the scroll list with them
    #region Cantrips Methods
    public void PopCantripList()
    {
        List<GameObject> popList = new List<GameObject>();

        switch (chosenClass)
        {
            case "Bard":
                popList = bardCantripList;
                break;
            case "Cleric":
                popList = clericCantripList;
                break;
            case "Druid":
                popList = druidCantripList;
                break;
            case "Sorcerer":
                popList = sorcererCantripList;
                break;
            case "Warlock":
                popList = warlockCantripList;
                break;
            case "Wizard":
                popList = wizardCantripList;
                break;
        }

        foreach (GameObject cantrip in popList)
        {
            spell = GameObject.Find("spell").GetComponent<Spell>();

            //Create the game object that will be displayed
            GameObject cantripCheckbox = Instantiate(checkboxPrefab);
            Transform parent = GameObject.Find("CantripPanel/CantripList/Scroll").transform;

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            //The scroll panel object in the project has components that will organize things properly, so the only thing that has to be done
            //is setting the new checkbox as a parent of the right panel, no need for more transofrmation edits past that.
            cantripCheckbox.transform.SetParent(parent, false);

            //The text of the textbox should be the text of the spell name
            cantripCheckbox.GetComponentInChildren<Text>().text = cantrip.name;

            cantripCheckbox.GetComponent<Toggle>().onValueChanged.AddListener(delegate { spell.DisplayInfo(); });
        }
    }
    #endregion

    //Methods to grab the appropriate first level spells for the class and then populate the scroll list with them
    #region First Level Spells Methods
    public void PopSpellList()
    {
        List<GameObject> popList = new List<GameObject>();

        switch (chosenClass)
        {
            case "Bard":
                popList = bardSpellList;
                break;
            case "Cleric":
                popList = clericSpellList;
                break;
            case "Druid":
                popList = druidSpellList;
                break;
            case "Sorcerer":
                popList = sorcererSpellList;
                break;
            case "Warlock":
                popList = warlockSpellList;
                break;
            case "Wizard":
                popList = wizardSpellList;
                break;
        }

        foreach (GameObject cantrip in popList)
        {
            //Create the game object that will be displayed
            GameObject cantripCheckbox = Instantiate(checkboxPrefab);
            Transform parent = GameObject.Find("SpellPanel/SpellList/Scroll").transform;

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            //The scroll panel object in the project has components that will organize things properly, so the only thing that has to be done
            //is setting the new checkbox as a parent of the right panel, no need for more transofrmation edits past that.
            cantripCheckbox.transform.SetParent(parent, false);

            //The text of the textbox should be the text of the spell name
            cantripCheckbox.GetComponentInChildren<Text>().text = cantrip.name;
        }
    }
    #endregion
}
