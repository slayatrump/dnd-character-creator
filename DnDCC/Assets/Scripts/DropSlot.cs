using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    //Switch checks
    private string dropSlotName;
    private string dropedScoreName;

    public static Button rollBTN;

    //Variable to help with saving scores
    public static int savedScore;

    //Access to the 6 AS score rolls
    public AbilityScoreRoller asr;

    public void OnDrop(PointerEventData eventData)
    {
        dropSlotName = this.gameObject.name;

        Debug.Log("OnDrop");

        //Checks if the the object being drop is not null
        if (eventData.pointerDrag != null)
        {
            rollBTN = GameObject.Find("Roll").GetComponent<Button>();
            rollBTN.enabled = false;
            rollBTN.GetComponentInChildren<TMP_Text>().text = "Press Reset Button";
            rollBTN.GetComponent<Image>().color = Color.gray;

            //Snaps the droped object into the anchored position of the slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition
                = GetComponent<RectTransform>().anchoredPosition;

            //Checks the drop slot name which calls a method that checks 
            //the name of the dropped object. This then saves the score number 
            //that is inside the dropped object
            switch (dropSlotName)
            {
                case "StrDrop":
                    {
                        StrDrop(eventData);
                        break;
                    }
                case "DexDrop":
                    {
                        DexDrop(eventData);
                        break;
                    }
                case "ConDrop":
                    {
                        ConDrop(eventData);
                        break;
                    }
                case "IntDrop":
                    {
                        IntDrop(eventData);
                        break;
                    }
                case "WisDrop":
                    {
                        WisDrop(eventData);
                        break;
                    }
                case "ChaDrop":
                    {
                        ChaDrop(eventData);
                        break;
                    }
            }
        }
    }
    //Resets the savedScore variable to be used for the next 
    void ResetSavedNumber()
    {
        savedScore = 0;
    }

    private void StrDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;

        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.strScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Strength AS Score is: " +
                        SaveManager.instance.gameData.strScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
    private void DexDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;
        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.dexScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Dexterity AS Score is: " +
                        SaveManager.instance.gameData.dexScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
    private void ConDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;
        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.conScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Constitution AS Score is: " +
                        SaveManager.instance.gameData.conScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
    private void IntDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;
        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.intScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Intelligence AS Score is: " +
                        SaveManager.instance.gameData.intScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
    private void WisDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;
        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.wisScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Wisdom AS Score is: " +
                        SaveManager.instance.gameData.wisScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
    private void ChaDrop(PointerEventData eventData)
    {
        dropedScoreName = eventData.pointerDrag.name;
        switch (dropedScoreName)
        {
            case "n1":
                {
                    savedScore = asr.scores[0];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n2":
                {
                    savedScore = asr.scores[1];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n3":
                {
                    savedScore = asr.scores[2];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n4":
                {
                    savedScore = asr.scores[3];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n5":
                {
                    savedScore = asr.scores[4];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
            case "n6":
                {
                    savedScore = asr.scores[5];

                    SaveManager.instance.gameData.chaScore = savedScore;
                    //SaveManager.instance.Save();

                    Debug.Log("Charisma AS Score is: " +
                        SaveManager.instance.gameData.chaScore.ToString());
                    ResetSavedNumber();
                    break;
                }
        }
    }
}
