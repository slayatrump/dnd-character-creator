using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class FinishCharacterController : MonoBehaviour
{
    public GameObject raceInfoPanel;
    public GameObject classInfoPanel;
    public GameObject backgroundInfoPanel;
    public GameObject abilityScoresInfoPanel;
    public GameObject classFeaturesInfoPanel;
    public GameObject equipmentInfoPanel;
    public GameObject spellListInfoPanel;
    public GameObject personalityInfoPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayRaceInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayClassInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayBackgroundInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayAbilityScoresInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayClassFeaturesInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayEquipmentInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplaySpellListInfo()
    {
        raceInfoPanel.SetActive(true);
    }
    public void DisplayPersonalityInfo()
    {
        raceInfoPanel.SetActive(true);
    }
}
