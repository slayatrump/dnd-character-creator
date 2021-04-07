using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// All this class does is to segment the list of weapons into specific list 
// depending on what weapon type they are.
// This is to easily place these list into drop menus later
public class WeaponListController : MonoBehaviour
{
    [Header("List of All Weapons")]
    public List<GameObject> weapons = new List<GameObject>();

    [Header("Segmented Lists of Weapons")]
    [SerializeField] public static List<GameObject> SMW = new List<GameObject>();
    [SerializeField] public static List<GameObject> SRW = new List<GameObject>();
    [SerializeField] public static List<GameObject> MMW = new List<GameObject>();
    [SerializeField] public static List<GameObject> MRW = new List<GameObject>();

    int index = 0;

    public void Awake()
    {
        SMW.Clear();
        SRW.Clear();
        MMW.Clear();
        MRW.Clear();

        SettingWeaponLists();
    }

    private void SettingWeaponLists()
    {
        foreach (GameObject weapon in weapons)
        {
            if (index >= 0 && index < 10)
            {
                SMW.Add(weapon);
                index++;
            }
            else if (index >= 10 && index < 15)
            {
                SRW.Add(weapon);
                index++;
            }
            else if (index >= 15 && index < 33)
            {
                MMW.Add(weapon);
                index++;
            }
            else if (index >= 33 && index < 38)
            {
                MRW.Add(weapon);
                index++;
            }
        }
    }
}
