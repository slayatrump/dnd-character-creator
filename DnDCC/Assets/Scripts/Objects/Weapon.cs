using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;
using TMPro;

public class Weapon : MonoBehaviour
{
    //https://roll20.net/compendium/dnd5e/Weapons#content This has all the weapons listed

    public string WeaponName;

    public enum WeaponTypes { SimpleMelee, SimpleRanged, MartialMelee, MartialRanged };
    public WeaponTypes WeaponType;

    //Numcost is the number, Costtype is gp, sp, cp, etc.
    public int NumCost;
    public string CostType;

    //1d4, 2d6, 1d8, etc.
    public string Damage;
    public DamageTypes DamageType;

    public float Weight;

    public List<string> Properties;

    #region Weapon UI Stuff
    [Header("Drop Menus")]
    [SerializeField] private TMP_Dropdown SMWDropMenu;
    [SerializeField] private TMP_Dropdown SRWDropMenu;
    [SerializeField] private TMP_Dropdown MMWDropMenu;
    [SerializeField] private TMP_Dropdown MRWDropMenu;

    [Header("Weapon Selection Text")]
    public TMP_Text SMWTXT;
    public TMP_Text SRWTXT;
    public TMP_Text MMWTXT;
    public TMP_Text MRWTXT;

    private void Start()
    {
        WeaponDropmenu1();
        WeaponDropmenu2();
        WeaponDropmenu3();
        WeaponDropmenu4();

        WeaponSelected1(SMWDropMenu);
        WeaponSelected2(SRWDropMenu);
        WeaponSelected3(MMWDropMenu);
        WeaponSelected4(MRWDropMenu);

        SMWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected1(SMWDropMenu); });
        SRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected2(SRWDropMenu); });
        MMWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected3(MMWDropMenu); });
        MRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected4(MRWDropMenu); });
    }

    public void WeaponSelected()
    {
        WeaponSelected1(SMWDropMenu);
        WeaponSelected2(SRWDropMenu);
        WeaponSelected3(MMWDropMenu);
        WeaponSelected4(MRWDropMenu);

        SMWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected1(SMWDropMenu); });
        SRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected2(SRWDropMenu); });
        MMWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected3(MMWDropMenu); });
        MRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected4(MRWDropMenu); });
    }

    private void WeaponDropmenu1()
    {
        SMWDropMenu.options.Clear();

        foreach (GameObject w in WeaponListController.SMW)
        {
            SMWDropMenu.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    private void WeaponDropmenu2()
    {
        SRWDropMenu.options.Clear();

        foreach (GameObject w in WeaponListController.SRW)
        {
            SRWDropMenu.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }
    private void WeaponDropmenu3()
    {
        MMWDropMenu.options.Clear();

        foreach (GameObject w in WeaponListController.MMW)
        {
            MMWDropMenu.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    private void WeaponDropmenu4()
    {
        MRWDropMenu.options.Clear();

        foreach (GameObject w in WeaponListController.MRW)
        {
            MRWDropMenu.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    private void WeaponSelected1(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        SMWTXT.text = dropdownItem.options[index].text;
        SMWDropMenu.GetComponentInChildren<TMP_Text>().text = SMWTXT.text;
    }

    private void WeaponSelected2(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        SRWTXT.text = dropdownItem.options[index].text;
        SRWDropMenu.GetComponentInChildren<TMP_Text>().text = SRWTXT.text;

    }
    private void WeaponSelected3(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        MMWTXT.text = dropdownItem.options[index].text;
        MMWDropMenu.GetComponentInChildren<TMP_Text>().text = MMWTXT.text;

    }
    private void WeaponSelected4(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        MRWTXT.text = dropdownItem.options[index].text;
        MRWDropMenu.GetComponentInChildren<TMP_Text>().text = MRWTXT.text;

    }
    #endregion
}
