using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    [SerializeField] private TMP_Dropdown SMWDropMenu1;
    [SerializeField] private TMP_Dropdown SMWDropMenu2;
    [SerializeField] private TMP_Dropdown SRWDropMenu1;
    [SerializeField] private TMP_Dropdown SRWDropMenu2;
    [SerializeField] private TMP_Dropdown MMWDropMenu1;
    [SerializeField] private TMP_Dropdown MMWDropMenu2;
    [SerializeField] private TMP_Dropdown MRWDropMenu1;
    [SerializeField] private TMP_Dropdown MRWDropMenu2;

    [Header("Weapon Selection Text")]
    public TMP_Text SMWTXT1;
    public TMP_Text SMWTXT2;
    public TMP_Text SRWTXT1;
    public TMP_Text SRWTXT2;
    public TMP_Text MMWTXT1;
    public TMP_Text MMWTXT2;
    public TMP_Text MRWTXT1;
    public TMP_Text MRWTXT2;

    [Header("Simple Or Martial Weapon Choices Panels")]
    public GameObject simpleWeaponChoicePanel;
    public GameObject martialWeaponChoicePanel;

    //Argument Variables
    string isSimpleOrMarital;
    bool isMelee;
    bool isRanged;
    bool isRemoved;
    bool isNext;
    bool isSingle;
    bool isTwo;

    Button nextWeapon1;
    Button nextWeapon2;
    Button nextWeapon3;
    Button nextWeapon4;

    Button continue1;
    Button continue2;
    Button continue3;
    Button continue4;

    private void Start()
    {
        WeaponDropmenu1();
        WeaponDropmenu2();
        WeaponDropmenu3();
        WeaponDropmenu4();

        //SMWWeaponSelected(SMWDropMenu1);
        //SMWWeaponSelected(SMWDropMenu2);
        //WeaponSelected2(SRWDropMenu);
        //WeaponSelected3(MMWDropMenu);
        //WeaponSelected4(MRWDropMenu);

        //SMWDropMenu1.onValueChanged.AddListener(delegate { SMWWeaponSelected(SMWDropMenu1); });
        //SRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected2(SRWDropMenu); });
        //MMWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected3(MMWDropMenu); });
        //MRWDropMenu.onValueChanged.AddListener(delegate { WeaponSelected4(MRWDropMenu); });

        TMP_Text damageInfo = GameObject.Find("DamageInfo").GetComponent<TMP_Text>();
        damageInfo.text = $"Damage: {this.Damage}";
        TMP_Text damageTypeInfo = GameObject.Find("DamageTypeInfo").GetComponent<TMP_Text>();
        damageTypeInfo.text = $"Damage Type: {this.DamageType}";

        nextWeapon1 = GameObject.Find("SMWPanel/NextWeapon").GetComponent<Button>();
        nextWeapon2 = GameObject.Find("SRWPanel/NextWeapon").GetComponent<Button>();
        nextWeapon3 = GameObject.Find("MMWPanel/NextWeapon").GetComponent<Button>();
        nextWeapon4 = GameObject.Find("MRWPanel/NextWeapon").GetComponent<Button>();

        continue1 = GameObject.Find("SMWPanel/Continue").GetComponent<Button>();
        continue2 = GameObject.Find("SRWPanel/Continue").GetComponent<Button>();
        continue3 = GameObject.Find("MMWPanel/Continue").GetComponent<Button>();
        continue4 = GameObject.Find("MRWPanel/Continue").GetComponent<Button>();
    }

    public void WeaponSelected()
    {
        SMWWeaponSelected(SMWDropMenu1);
        if (SMWDropMenu2 != null)
        {
            SMWWeaponSelected(SMWDropMenu2);
            SMWDropMenu1.onValueChanged.AddListener(delegate { SMWWeaponSelected(SMWDropMenu2); });
        }
        
        SRWWeaponSelected(SRWDropMenu1);
        if (SRWDropMenu2 != null)
        {
            SRWWeaponSelected(SRWDropMenu2);
            SRWDropMenu1.onValueChanged.AddListener(delegate { SRWWeaponSelected(SRWDropMenu2); });
        }

        MMWWeaponSelected(MMWDropMenu1);
        if (MMWDropMenu2 != null)
        {
            MMWWeaponSelected(MMWDropMenu2);
            MMWDropMenu1.onValueChanged.AddListener(delegate { MMWWeaponSelected(MMWDropMenu2); });
        }

        MRWWeaponSelected(MRWDropMenu1);
        if (MRWDropMenu2 != null)
        {
            MRWWeaponSelected(MRWDropMenu2);
            MRWDropMenu1.onValueChanged.AddListener(delegate { MRWWeaponSelected(MRWDropMenu2); });
        }

        SMWDropMenu1.onValueChanged.AddListener(delegate { SMWWeaponSelected(SMWDropMenu1); });
        SRWDropMenu1.onValueChanged.AddListener(delegate { SRWWeaponSelected(SRWDropMenu1); });
        MMWDropMenu1.onValueChanged.AddListener(delegate { MMWWeaponSelected(MMWDropMenu1); });
        MRWDropMenu1.onValueChanged.AddListener(delegate { MRWWeaponSelected(MRWDropMenu1); });
    }

    private void WeaponDropmenu1()
    {
        SMWDropMenu1.options.Clear();
        SMWDropMenu2.options.Clear();

        foreach (GameObject w in WeaponListController.SMW)
        {
            SMWDropMenu1.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
            SMWDropMenu2.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    private void WeaponDropmenu2()
    {
        SRWDropMenu1.options.Clear();
        SRWDropMenu2.options.Clear();

        foreach (GameObject w in WeaponListController.SRW)
        {
            SRWDropMenu1.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
            SRWDropMenu2.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }
    private void WeaponDropmenu3()
    {
        MMWDropMenu1.options.Clear();
        MMWDropMenu2.options.Clear();

        foreach (GameObject w in WeaponListController.MMW)
        {
            MMWDropMenu1.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
            MMWDropMenu2.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    private void WeaponDropmenu4()
    {
        MRWDropMenu1.options.Clear();
        MRWDropMenu2.options.Clear();

        foreach (GameObject w in WeaponListController.MRW)
        {
            MRWDropMenu1.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
            MRWDropMenu2.options.Add(new TMP_Dropdown.OptionData() { text = w.name.ToString() });
        }
    }

    public void SMWWeaponSelected(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        foreach (string weapon in SaveManager.instance.gameData.equipmentChoices)
        {
            if (weapon.Contains("2 Simple Melee Weapon") == true)
            {
                nextWeapon1.gameObject.SetActive(true);
                isNext = true;
                break;
            }
            else if (isNext == true)
            {
                continue1.gameObject.SetActive(true);
                isNext = false;
            }
        }
        
        SMWTXT1.text = dropdownItem.options[index].text;
        SMWDropMenu1.GetComponentInChildren<TMP_Text>().text = SMWTXT1.text;

        if (SMWDropMenu2 != null)
        {
            SMWTXT2.text = dropdownItem.options[index].text;
            SMWDropMenu2.GetComponentInChildren<TMP_Text>().text = SMWTXT2.text;
        }

        TMP_Text damageInfo = GameObject.Find("SMWPanel/DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("SMWPanel/DamageTypeInfo").GetComponent<TMP_Text>();

        switch (SMWTXT1.text)
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

    public void SRWWeaponSelected(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        nextWeapon2.gameObject.SetActive(true);

        SRWTXT1.text = dropdownItem.options[index].text;
        SRWDropMenu1.GetComponentInChildren<TMP_Text>().text = SRWTXT1.text;

        if (SRWDropMenu2 != null)
        {
            SRWTXT2.text = dropdownItem.options[index].text;
            SRWDropMenu2.GetComponentInChildren<TMP_Text>().text = SRWTXT2.text;
        }

        TMP_Text damageInfo = GameObject.Find("SRWPanel/DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("SRWPanel/DamageTypeInfo").GetComponent<TMP_Text>();

        switch (SRWTXT1.text)
        {
            case "Boomerang":
                {
                    Weapon w = GameObject.Find("Boomerang").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Dart":
                {
                    Weapon w = GameObject.Find("Dart").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Light Crossbow":
                {
                    Weapon w = GameObject.Find("Light Crossbow").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Shortbow":
                {
                    Weapon w = GameObject.Find("Shortbow").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Sling":
                {
                    Weapon w = GameObject.Find("Sling").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
        }
    }
    public void MMWWeaponSelected(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        if (isSimpleOrMarital.Contains("2"))
        {
            nextWeapon3.gameObject.SetActive(true);
        }
        else
        {
            continue3.gameObject.SetActive(true);
        }

        MMWTXT1.text = dropdownItem.options[index].text;
        MMWDropMenu1.GetComponentInChildren<TMP_Text>().text = MMWTXT1.text;

        if (MMWDropMenu2 != null)
        {
            MMWTXT2.text = dropdownItem.options[index].text;
            MMWDropMenu2.GetComponentInChildren<TMP_Text>().text = MMWTXT2.text;
        }

        TMP_Text damageInfo = GameObject.Find("MMWPanel/DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("MMWPanel/DamageTypeInfo").GetComponent<TMP_Text>();

        switch (MMWTXT1.text)
        {
            case "Battleaxe":
                {
                    Weapon w = GameObject.Find("Battleaxe").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Flail":
                {
                    Weapon w = GameObject.Find("Flail").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Glaive":
                {
                    Weapon w = GameObject.Find("Glaive").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Greataxe":
                {
                    Weapon w = GameObject.Find("Greataxe").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Greatsword":
                {
                    Weapon w = GameObject.Find("Greatsword").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Halberd":
                {
                    Weapon w = GameObject.Find("Halberd").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Lance":
                {
                    Weapon w = GameObject.Find("Lance").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Longsword":
                {
                    Weapon w = GameObject.Find("Longsword").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Maul":
                {
                    Weapon w = GameObject.Find("Maul").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Morningstar":
                {
                    Weapon w = GameObject.Find("Morningstar").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Pike":
                {
                    Weapon w = GameObject.Find("Pike").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Rapier":
                {
                    Weapon w = GameObject.Find("Rapier").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Scimitar":
                {
                    Weapon w = GameObject.Find("Scimitar").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Shortsword":
                {
                    Weapon w = GameObject.Find("Shortsword").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Trident":
                {
                    Weapon w = GameObject.Find("Trident").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "War Pike":
                {
                    Weapon w = GameObject.Find("War Pike").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Warhammer":
                {
                    Weapon w = GameObject.Find("Warhammer").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Whip":
                {
                    Weapon w = GameObject.Find("Whip").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
        }
    }
    public void MRWWeaponSelected(TMP_Dropdown dropdownItem)
    {
        int index = dropdownItem.value;

        nextWeapon4.gameObject.SetActive(true);

        MRWTXT1.text = dropdownItem.options[index].text;
        MRWDropMenu1.GetComponentInChildren<TMP_Text>().text = MRWTXT1.text;

        if (MRWDropMenu2 != null)
        {
            MRWTXT2.text = dropdownItem.options[index].text;
            MRWDropMenu2.GetComponentInChildren<TMP_Text>().text = MRWTXT2.text;
        }

        TMP_Text damageInfo = GameObject.Find("MRWPanel/DamageInfo").GetComponent<TMP_Text>();
        TMP_Text damageTypeInfo = GameObject.Find("MRWPanel/DamageTypeInfo").GetComponent<TMP_Text>();

        switch (MRWTXT1.text)
        {
            case "Blowgun":
                {
                    Weapon w = GameObject.Find("Blowgun").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Hand Crossbow":
                {
                    Weapon w = GameObject.Find("Hand Crossbow").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Heavy Crossbow":
                {
                    Weapon w = GameObject.Find("Heavy Crossbow").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Longbow":
                {
                    Weapon w = GameObject.Find("Longbow").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
            case "Net":
                {
                    Weapon w = GameObject.Find("Net").GetComponent<Weapon>();
                    damageInfo.text = $"Damage: {w.Damage}";
                    damageTypeInfo.text = $"Damage Type: {w.DamageType}";
                    break;
                }
        }
    }

    public void SimpleAndMartialWeaponCheck()
    {
        continue1.gameObject.SetActive(false);
        continue2.gameObject.SetActive(false);
        continue3.gameObject.SetActive(false);
        continue4.gameObject.SetActive(false);

        foreach (string w in SaveManager.instance.gameData.equipmentChoices)
        {
            isSimpleOrMarital = w;

            if (isSimpleOrMarital.Contains("Simple") == true)
            {
                if (isSimpleOrMarital.Contains("2 Simple Weapon") == true && isSimpleOrMarital.Contains("Melee") == false
                    && isSimpleOrMarital.Contains("Ranged") == false)
                {
                    martialWeaponChoicePanel.SetActive(false);
                    TMP_Text choice1 = GameObject.Find("SimpleWeaponChoice/Choice1").GetComponent<TMP_Text>();
                    TMP_Text choice12 = GameObject.Find("SimpleWeaponChoice/Choice1.2").GetComponent<TMP_Text>();
                    choice1.gameObject.SetActive(false);
                    choice12.gameObject.SetActive(false);
                    isTwo = true;
                    isSingle = false;
                    break;
                }
                else if (isSimpleOrMarital.Contains("2 Simple Melee") == true)
                {
                    isMelee = true;
                    simpleWeaponChoicePanel.SetActive(false);
                    martialWeaponChoicePanel.SetActive(false);
                    isTwo = true;
                    isSingle = false;
                    SimpleWeapons();
                    break;
                }
                else if (isSimpleOrMarital.Contains("2 Simple Ranged") == true)
                {
                    isRanged = true;
                    simpleWeaponChoicePanel.SetActive(false);
                    martialWeaponChoicePanel.SetActive(false);
                    isTwo = true;
                    isSingle = false;
                    SimpleWeapons();
                    break;
                }

                TMP_Text choice2 = GameObject.Find("SimpleWeaponChoice/Choice2").GetComponent<TMP_Text>();
                TMP_Text choice3 = GameObject.Find("SimpleWeaponChoice/Choice3").GetComponent<TMP_Text>();
                TMP_Text choice4 = GameObject.Find("SimpleWeaponChoice/Choice4").GetComponent<TMP_Text>();
                choice2.gameObject.SetActive(false);
                choice3.gameObject.SetActive(false);
                choice4.gameObject.SetActive(false);
                martialWeaponChoicePanel.SetActive(false);
                isSingle = true;
                isTwo = false;
                break;
            }

            if (isSimpleOrMarital.Contains("Martial") == true)
            {
                if (isSimpleOrMarital.Contains("2 Martial Weapon") == true && isSimpleOrMarital.Contains("Melee") == false
                    && isSimpleOrMarital.Contains("Ranged") == false)
                {
                    simpleWeaponChoicePanel.SetActive(false);
                    TMP_Text choice1 = GameObject.Find("MartialWeaponChoice/Choice1").GetComponent<TMP_Text>();
                    TMP_Text choice12 = GameObject.Find("MartialWeaponChoice/Choice1.2").GetComponent<TMP_Text>();
                    choice1.gameObject.SetActive(false);
                    choice12.gameObject.SetActive(false);
                    isTwo = true;
                    break;
                }
                else if (isSimpleOrMarital.Contains("2 Martial Melee") == true)
                {
                    isMelee = true;
                    simpleWeaponChoicePanel.SetActive(false);
                    martialWeaponChoicePanel.SetActive(false);
                    isTwo = true;
                    isSingle = false;
                    MartialWeapons();
                    break;
                }
                else if (isSimpleOrMarital.Contains("2 Martial Ranged") == true)
                {
                    isRanged = true;
                    simpleWeaponChoicePanel.SetActive(false);
                    martialWeaponChoicePanel.SetActive(false);
                    isTwo = true;
                    isSingle = false;
                    MartialWeapons();
                    break;
                }
                TMP_Text choice2 = GameObject.Find("MartialWeaponChoice/Choice2").GetComponent<TMP_Text>();
                TMP_Text choice3 = GameObject.Find("MartialWeaponChoice/Choice3").GetComponent<TMP_Text>();
                TMP_Text choice4 = GameObject.Find("MartialWeaponChoice/Choice4").GetComponent<TMP_Text>();
                choice2.gameObject.SetActive(false);
                choice3.gameObject.SetActive(false);
                choice4.gameObject.SetActive(false);
                simpleWeaponChoicePanel.SetActive(false);
                isSingle = true;
                isTwo = false;
                break;
            }
        }
    }

    public void SimpleWeapons()
    {
        //isMelee = false;
        //isRanged = false;

        string selected;
        selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "s1":
                {
                    GameObject weapon2 = GameObject.Find("SMWPanel/Weapon2");
                    weapon2.SetActive(false);
                    isMelee = true;
                    isRanged = false;
                    simpleWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s2":
                {
                    GameObject weapon2 = GameObject.Find("SRWPanel/Weapon2");
                    weapon2.SetActive(false);
                    isRanged = true;
                    isMelee = false;
                    simpleWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s3":
                {
                    isMelee = true;
                    isRanged = true;
                    GameObject weapon2 = GameObject.Find("SMWPanel/Weapon2");
                    weapon2.SetActive(false);
                    GameObject weapon3 = GameObject.Find("SMWPanel/Weapon3");
                    weapon3.SetActive(true);
                    simpleWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s4":
                {
                    GameObject weapon2 = GameObject.Find("SMWPanel/Weapon2");
                    weapon2.SetActive(false);
                    isMelee = true;
                    isRanged = false;
                    simpleWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s5":
                {
                    GameObject weapon2 = GameObject.Find("SRWPanel/Weapon2");
                    weapon2.SetActive(false);
                    isRanged = true;
                    isMelee = false;
                    simpleWeaponChoicePanel.SetActive(false);
                    break;
                }
        }

        if (isMelee == true && isRanged == false)
        {
            GameObject SRW = GameObject.Find("SRWPanel");
            GameObject MMW = GameObject.Find("MMWPanel");
            GameObject MRW = GameObject.Find("MRWPanel");
            SRW.SetActive(false);
            MMW.SetActive(false);
            MRW.SetActive(false);
            GameObject w2 = GameObject.Find("Weapon2");
            w2.SetActive(false);
        }
        if (isRanged == true && isMelee == false)
        {
            GameObject SMW = GameObject.Find("SMWPanel");
            GameObject MMW = GameObject.Find("MMWPanel");
            GameObject MRW = GameObject.Find("MRWPanel");
            SMW.SetActive(false);
            MMW.SetActive(false);
            MRW.SetActive(false);
        }
        if (isMelee == true && isRanged == true)
        {
            GameObject SRW = GameObject.Find("SRWPanel");
            GameObject MMW = GameObject.Find("MMWPanel");
            GameObject MRW = GameObject.Find("MRWPanel");
            SRW.SetActive(false);
            MMW.SetActive(false);
            MRW.SetActive(false);
            GameObject w2 = GameObject.Find("Weapon2");
            w2.SetActive(false);
        }
    }

    public void MartialWeapons()
    {
        isMelee = false;
        isRanged = false;

        string selected;
        selected = EventSystem.current.currentSelectedGameObject.name;
        switch (selected)
        {
            case "s1":
                {
                    isMelee = true;
                    isRanged = false;
                    martialWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s2":
                {
                    isRanged = true;
                    isMelee = false;
                    martialWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s3":
                {
                    isMelee = true;
                    isRanged = true;
                    martialWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s4":
                {
                    isMelee = true;
                    isRanged = false;
                    martialWeaponChoicePanel.SetActive(false);
                    break;
                }
            case "s5":
                {
                    isRanged = true;
                    isMelee = false;
                    martialWeaponChoicePanel.SetActive(false);
                    break;
                }
        }

        if (isMelee == true && isRanged == false)
        {
            GameObject SRW = GameObject.Find("SRWPanel");
            GameObject SMW = GameObject.Find("SMWPanel");
            GameObject MRW = GameObject.Find("MRWPanel");
            SRW.SetActive(false);
            SMW.SetActive(false);
            MRW.SetActive(false);
        }
        if (isRanged == true && isMelee == false)
        {
            GameObject SRW = GameObject.Find("SRWPanel");
            GameObject SMW = GameObject.Find("SMWPanel");
            GameObject MMW = GameObject.Find("MMWPanel");
            SRW.SetActive(false);
            SMW.SetActive(false);
            MMW.SetActive(false);
        }
        if (isMelee == true && isRanged == true)
        {
            GameObject SRW = GameObject.Find("SRWPanel");
            GameObject SMW = GameObject.Find("SMWPanel");
            GameObject MRW = GameObject.Find("MRWPanel");
            SRW.SetActive(false);
            SMW.SetActive(false);
            MRW.SetActive(false);
            GameObject w2 = GameObject.Find("Weapon2");
            w2.SetActive(false);
        }
    }

    public void SettingNewWeapon()
   {
        foreach (string weapon in SaveManager.instance.gameData.equipmentChoices)
        {
            if (weapon.Contains("Simple") == true && isRemoved == false)
            {
                if (weapon.Contains("Simple Melee") == true)
                {
                    if (isSingle == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(SMWTXT1.text);
                        MenuController.isDone = true;
                        break;
                    }
                    else if (isTwo == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(SMWTXT1.text);
                        isRemoved = true;
                        break;
                    }
                }
                else if (weapon.Contains("Simple Ranged") == true)
                {
                    if (isSingle == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(SRWTXT1.text);
                        MenuController.isDone = true;
                        break;
                    }
                    else if (isTwo == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(SRWTXT1.text);
                        isRemoved = true;
                        break;
                    }
                }
            }
            else if(weapon.Contains("Simple") == false && isRemoved == true && isTwo == true)
            {
                if (isMelee == true)
                {
                    SaveManager.instance.gameData.equipmentChoices.Add(SMWTXT2.text);
                    MenuController.isDone = true;
                }
                SRWTXT1 = GetComponent<TMP_Text>();
                if (isRanged == true && SRWTXT1 != null)
                {
                    SaveManager.instance.gameData.equipmentChoices.Add(SRWTXT1.text);
                    MenuController.isDone = true;
                }
                break;
            }

            if (weapon.Contains("Martial") == true && isRemoved == false)
            {
                if(weapon.Contains("Martial Melee") == true)
                {
                    if (isSingle == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(MMWTXT1.text);
                        MenuController.isDone = true;
                        break;
                    }
                    else if (isTwo == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(MMWTXT2.text);
                        isRemoved = true;
                        break;
                    }
                }
                else if (weapon.Contains("Martial Ranged") == true)
                {
                    if (isSingle == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(MRWTXT1.text);
                        MenuController.isDone = true;
                        break;
                    }
                    else if (isTwo == true)
                    {
                        SaveManager.instance.gameData.equipmentChoices.Remove(isSimpleOrMarital);
                        SaveManager.instance.gameData.equipmentChoices.Add(MRWTXT2.text);
                        isRemoved = true;
                        break;
                    }
                }
            }
            else if (weapon.Contains("Martial") == false && isRemoved == true && isTwo == true)
            {
                if (isMelee == true)
                {
                    SaveManager.instance.gameData.equipmentChoices.Add(MMWTXT2.text);
                    MenuController.isDone = true;
                }
                MRWTXT1.GetComponent<TMP_Text>();
                if (isRanged == true && MRWTXT1 != null)
                {
                    SaveManager.instance.gameData.equipmentChoices.Add(MRWTXT1.text);
                    MenuController.isDone = true;
                }
                break;
            }
        }
    }
    #endregion
}
