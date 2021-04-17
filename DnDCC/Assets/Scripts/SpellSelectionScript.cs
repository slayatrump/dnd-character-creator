using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GlobalEnums;
using UnityEngine.EventSystems;
using System.Diagnostics;

public class SpellSelectionScript : MonoBehaviour
{
    //the checkbox prefab will be set in the inspector so that it can be instantiated during the population methods
    public GameObject checkboxPrefab;

    public int[] numList; //The numbers associated with classes for cantrips and spells

    public string[] allCantrips; //All cantrips
    public string[] allFirstLevel; //All First Level spells

    GameObject[] displayThese; //the cantrips to display

    //Two arrays for each section of components and descriptions of the spells
    string[] spellComponentsArray;
    string[] spellDescriptionArray;

    //This is the spell that is chosen when the user hits the checkbox
    string selectedSpellText;
    GameObject selectedSpell;

    //Test case at the moment
    //When functional, it should just take the class name from the current save data and use that instead
    public string chosenClass = "Bard"; //SaveManager.instance.gameData.className;

    // Start is called before the first frame update
    void Start()
    {
        numList = new int[2];

        //TODO: Get this to display the right numbers instead of zeroes
        SetNumbers(chosenClass);

        FindCantrips(chosenClass);
        FindFirstLevel(chosenClass);

        //TODO: Get population to work right
        PopCantripList();
        PopFirstLevelList();

        //get the text component of labels and change it to array values
        GameObject.Find("Cantrips Number").GetComponent<TextMeshProUGUI>().text = $"{numList[0]}";
        GameObject.Find("1L Number").GetComponent<TextMeshProUGUI>().text = $"{numList[1]}";
    }

    //Methods to set the Cantrip and First Level spell numbers according to chosen class
    #region Setting Spell Numbers
    public int[] SetNumbers(string chosenClass)
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

        return numList;
    }
    #endregion

    //Methods to grab the appropriate cantrips for the class and then populate the scroll list with them
    #region Cantrips Methods
    public GameObject[] FindCantrips(string chosenClass)
    {
        GameObject[] theCantrips = GameObject.FindGameObjectsWithTag("Cantrip"); //find every cantrip
        string[] spellClasses; //temporary cantrip class holder

        //For each cantrip, find ones that have the right class name in it
        for (int i = 0; i < theCantrips.Length; i++)
        {
            spellClasses = new string[] { theCantrips[i].GetComponent<Spell>().SpellName };

            foreach (string element in spellClasses)
            {
                if (element == chosenClass)
                {
                    //Should input the cantrip that matches into the array we will want to display
                    displayThese = new GameObject[] { theCantrips[i] };
                }
            }
        }

        return displayThese;
    }

    //TODO: Something needs to be set to an instance of an object here, but I can't figure out what
    public void PopCantripList()
    {
        //for each element that passed the check, create a checkbox for it
        for (int i = 0; i < displayThese.Length; i++)
        {
            //Create the game object that will be displayed
            GameObject cantripCheckbox = Instantiate(checkboxPrefab);

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            //The scroll panel object in the project has components that will organize things properly, so the only thing that has to be done
            //is setting the new checkbox as a parent of the right panel, no need for more transofrmation edits past that.
            cantripCheckbox.transform.parent = GameObject.Find("CantripPanel/CantripList/Scroll/ScrollPanel").transform;

            //The text of the textbox should be the text of the spell name
            cantripCheckbox.GetComponentInChildren<Text>().text = displayThese[i].name;
        }
    }
    #endregion

    //TODO: Once the Cantrips methods are solved, copy past the information into the First Level methods and replace names appropriately
    //Methods to grab the appropriate first level spells for the class and then populate the scroll list with them
    #region First Level Spells Methods
    public GameObject[] FindFirstLevel(string chosenClass)
    {
        GameObject[] theCantrips = GameObject.FindGameObjectsWithTag("Cantrip"); //find every cantrip
        string[] spellClasses; //temporary cantrip class holder

        //For each cantrip, find ones that have the right class name in it
        for (int i = 0; i < theCantrips.Length; i++)
        {
            spellClasses = new string[] { theCantrips[i].GetComponent<Spell>().SpellName };

            foreach (string element in spellClasses)
            {
                if (element == chosenClass)
                {
                    //Should input the cantrip that matches into the array we will want to display
                    displayThese = new GameObject[] { theCantrips[i] };
                }
            }
        }

        return displayThese;
    }

    public void PopFirstLevelList()
    {
        //for each element that passed the check, create a checkbox for it
        for (int i = 0; i < displayThese.Length; i++)
        {
            //Create the game object that will be displayed
            GameObject cantripCheckbox = Instantiate(checkboxPrefab);

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            cantripCheckbox.transform.parent = GameObject.Find("CantripPanel/CantripList/Scroll/ScrollPanel").transform;

            //The text of the textbox should be the text of the spell name
            cantripCheckbox.GetComponentInChildren<Text>().text = displayThese[i].name;
        }
    }
    #endregion

    //Methods to display the spell information when the user selects a spell
    #region Spell Information Methods
    //This method should be called when the checkbox is checked or unchecked.
    //There is an onvaluechanged feature with the unity checkbox, but I am unsure how to get it to work with this
    public void SpellInformation(GameObject[] displayThese)
    {
        //the string selectedSpell needs to be set based on text of the checkbox that was just clicked
        //the following code isn't functional

        //selectedSpellText is the item used to compare

        for (int i = 0; i < displayThese.Length; i++)
        {
            //if both texts match up, make the GameObject selectedSpell equal displayThese[i]
            if (selectedSpellText == displayThese[i].GetComponent<Text>().text)
            {
                selectedSpell = displayThese[i];
            }
        }

        //Sets the text of each respective object in the scene to the text of the respective property
        GameObject.Find("NText").GetComponent<Text>().text = 
            selectedSpell.GetComponent<Spell>().SpellName.ToString();
        GameObject.Find("SText").GetComponent<Text>().text = 
            selectedSpell.GetComponent<Spell>().SchoolType.ToString();
        GameObject.Find("CTText").GetComponent<Text>().text = 
            selectedSpell.GetComponent<Spell>().CastingTime.ToString();
        GameObject.Find("RText").GetComponent<Text>().text = 
            selectedSpell.GetComponent<Spell>().Range.ToString();

        //Should go through the list of items in components and get then display the text properly
        for (int i = 0; i < selectedSpell.GetComponent<Spell>().Components.Count; i++)
        {
            spellComponentsArray[i] = selectedSpell.GetComponent<Spell>().Components[i].ToString();
            GameObject.Find("CompText").GetComponent<Text>().text =
                string.Join(spellComponentsArray[i], "/n");
        }

        //same as above but for the descriptions instead
        for (int i = 0; i < selectedSpell.GetComponent<Spell>().DescriptionParagraphs.Count; i++)
        {
            spellDescriptionArray[i] = selectedSpell.GetComponent<Spell>().DescriptionParagraphs[i];
            GameObject.Find("DText").GetComponent<Text>().text =
                string.Join(spellDescriptionArray[i], "/n");
        }
    }
    #endregion
}
