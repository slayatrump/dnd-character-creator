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

    string isSimpleOrMarital;

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

        TMP_Text damageInfo = GameObject.Find("DamageInfo").GetComponent<TMP_Text>();
        damageInfo.text = $"Damage: {this.Damage}";
        TMP_Text damageTypeInfo = GameObject.Find("DamageTypeInfo").GetComponent<TMP_Text>();
        damageTypeInfo.text = $"Damage Type: {this.DamageType}";
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

        TMP_Text damageInfo = GameObject.Find("DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("DamageTypeInfo").GetComponent<TMP_Text>();

        switch (SMWTXT.text)
        {
            case "Club":
                {
                    Weapon w = GameObject.Find("Club").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Dagger":
                {
                    Weapon w = GameObject.Find("Dagger").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Greatclub":
                {
                    Weapon w = GameObject.Find("Greatclub").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Handaxe":
                {
                    Weapon w = GameObject.Find("Handaxe").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Javelin":
                {
                    Weapon w = GameObject.Find("Javelin").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Light Hammer":
                {
                    Weapon w = GameObject.Find("Light Hammer").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Mace":
                {
                    Weapon w = GameObject.Find("Mace").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Quarterstaff":
                {
                    Weapon w = GameObject.Find("Quarterstaff").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Sickle":
                {
                    Weapon w = GameObject.Find("Sickle").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Spear":
                {
                    Weapon w = GameObject.Find("Spear").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
        }
    }

    private void WeaponSelected2(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        SRWTXT.text = dropdownItem.options[index].text;
        SRWDropMenu.GetComponentInChildren<TMP_Text>().text = SRWTXT.text;

        TMP_Text damageInfo = GameObject.Find("DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("DamageTypeInfo").GetComponent<TMP_Text>();
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

    public void SimpleAndMartialWeaponCheck()
    {
        foreach (string w in SaveManager.instance.gameData.equipmentChoices)
        {
            isSimpleOrMarital = w;

            if (isSimpleOrMarital.Contains("Simple") == true)
            {
                if (isSimpleOrMarital.Contains("2 Simple Melee") == true)
                {
                    //weapon1 = GameObject.Find("Weapon1");
                    //Vector3 weapon1Pos = new Vector3(weapon1.transform.position.x, weapon1.transform.position.y, weapon1.transform.position.z);
                    //GameObject weaponClone = Instantiate<GameObject>(weapon1, new Vector3(weapon1Pos.x, weapon1Pos.y - 300, weapon1Pos.z),
                    //    Quaternion.identity);
                    SimpleWeapons();
                    break;
                }
            }
            if (isSimpleOrMarital.Contains("Martial") == true)
            {
                MartialWeapons();
                break;
            }
        }
    }

    private void SimpleWeapons()
    {
        GameObject SRW = GameObject.Find("SRWPanel");
        GameObject MMW = GameObject.Find("MMWPanel");
        GameObject MRW = GameObject.Find("MRWPanel");
        SRW.SetActive(false);
        MMW.SetActive(false);
        MRW.SetActive(false);
    }

    private void MartialWeapons()
    {
        GameObject SRW = GameObject.Find("SRWPanel");
        GameObject SMW = GameObject.Find("SMWPanel");
        GameObject MRW = GameObject.Find("MRWPanel");
        SRW.SetActive(false);
        SMW.SetActive(false);
        MRW.SetActive(false);
    }
    #endregion
}
