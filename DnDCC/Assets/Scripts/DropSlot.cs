using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DropSlot : MonoBehaviour, IDropHandler
{
    private string dropSlotName;
    private string dropedScoreName;
    public static int savedScore;

    public AbilityScoreRoller asr;

    public void OnDrop(PointerEventData eventData)
    {
        dropSlotName = this.gameObject.name;

        //Debug.Log(dropSlotName);
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition 
                = GetComponent<RectTransform>().anchoredPosition;

            switch (dropSlotName)
            {
                case "StrDrop":
                    {
                        dropedScoreName = eventData.pointerDrag.name;
                        switch (dropedScoreName)
                        {
                            case "n1":
                                {
                                    savedScore = asr.scores[0];
                                    
                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                            case "n2":
                                {
                                    savedScore = asr.scores[1];

                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                            case "n3":
                                {
                                    savedScore = asr.scores[2];

                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                            case "n4":
                                {
                                    savedScore = asr.scores[3];

                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                            case "n5":
                                {
                                    savedScore = asr.scores[4];

                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                            case "n6":
                                {
                                    savedScore = asr.scores[5];

                                    SaveManager.instance.gameData.strScore = savedScore;
                                    //SaveManager.instance.Save();

                                    Debug.Log(SaveManager.instance.gameData.strScore.ToString());
                                    break;
                                }
                        }
                        break;
                    }
            }
        }


    }
}
