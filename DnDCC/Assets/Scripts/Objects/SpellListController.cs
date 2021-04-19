using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellListController : MonoBehaviour
{
    public List<GameObject> spells = new List<GameObject>();
    public List<GameObject> cantrips = new List<GameObject>();

    [SerializeField] public static List<GameObject> bardSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> bardCantripList = new List<GameObject>();

    [SerializeField] public static List<GameObject> clericSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> clericCantripList = new List<GameObject>();

    [SerializeField] public static List<GameObject> druidSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> druidCantripList = new List<GameObject>();

    [SerializeField] public static List<GameObject> sorcererSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> sorcererCantripList = new List<GameObject>();

    [SerializeField] public static List<GameObject> warlockSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> warlockCantripList = new List<GameObject>();

    [SerializeField] public static List<GameObject> wizardSpellList = new List<GameObject>();
    [SerializeField] public static List<GameObject> wizardCantripList = new List<GameObject>();

    private void Awake()
    {
        SettingClassSpells();
        SettingClassCantrips();
    }

    public void SettingClassSpells()
    {
        foreach (GameObject spell in spells)
        {
            switch (spell.name)
            {
                case "Alarm":
                    {
                        wizardSpellList.Add(spell);
                        break; 
                    }
                case "Animal Friendship":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Armor of Agathys":
                    {
                        warlockSpellList.Add(spell);
                        break;
                    }
                case "Arms of Hadar":
                    {
                        warlockSpellList.Add(spell);
                        break;
                    }
                case "Bane":
                    {
                        bardSpellList.Add(spell);
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Bless":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Burning Hands":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Charm Person":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        break;
                    }
                case "Chromatic Orb":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Color Spray":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Command":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Compelled Duel":
                    {
                        break;
                    }
                case "Comprehend Languages":
                    {
                        bardSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Create or Destroy Water":
                    {
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Cure Wounds":
                    {
                        bardSpellList.Add(spell);
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Detect Evil and Good":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Detect Magic":
                    {
                        bardSpellList.Add(spell);
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Detect Poison and Disease":
                    {
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Disguise Self":
                    {
                        bardSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Dissonant Whispers":
                    {
                        bardSpellList.Add(spell);
                        break;
                    }
                case "Divine Favor":
                    {
                        break;
                    }
                case "Ensnaring Strike":
                    {
                        break;
                    }
                case "Entangle Spell":
                    {
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Expeditious Retreat":
                    {
                        sorcererSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Faerie Fire":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "False Life":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Feather Fall":
                    {
                        bardSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Find Familiar":
                    {
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Floating Disk":
                    {
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Fog Cloud":
                    {
                        druidSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Goodberry":
                    {
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Grease":
                    {
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Guiding Bolt":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Hail of Thorns":
                    {
                        break;
                    }
                case "Healing Word":
                    {
                        bardSpellList.Add(spell);
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Hellish Rebuke":
                    {
                        warlockSpellList.Add(spell);
                        break;
                    }
                case "Heroism":
                    {
                        bardSpellList.Add(spell);
                        break;
                    }
                case "Hex":
                    {
                        warlockSpellList.Add(spell);
                        break;
                    }
                case "Hideous Laughter":
                    {
                        bardSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Hunter's Mark":
                    {
                        break;
                    }
                case "Identify":
                    {
                        bardSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Illusory Script":
                    {
                        bardSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Inflict Wounds":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Jump":
                    {
                        druidSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Longstrider":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Mage Armor":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Magic Missile":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Protection from Evil and Good":
                    {
                        clericSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Purify Food and Drink":
                    {
                        clericSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Ray of Sickness":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Sanctuary":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Searing Smite":
                    {
                        break;
                    }
                case "Shield of Faith":
                    {
                        clericSpellList.Add(spell);
                        break;
                    }
                case "Shield":
                    {
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Silent Image":
                    {
                        bardSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Sleep":
                    {
                        bardSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Speak with Animals":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        break;
                    }
                case "Tasha's Hideous Laughter":
                    {
                        bardSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Tenser's Floating Disk":
                    {
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Thunderous Smite":
                    {
                        break;
                    }
                case "Thunderwave":
                    {
                        bardSpellList.Add(spell);
                        druidSpellList.Add(spell);
                        sorcererSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Unseen Servant":
                    {
                        bardSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Witch Bolt":
                    {
                        sorcererSpellList.Add(spell);
                        warlockSpellList.Add(spell);
                        wizardSpellList.Add(spell);
                        break;
                    }
                case "Wrathful Smite":
                    {
                        break;
                    }
            }
        }
    }

    public void SettingClassCantrips()
    {
        foreach (GameObject cantrip in cantrips)
        {
            switch (cantrip.name)
            {
                case "Acid Splash":
                    {
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Blade Ward":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Chill Touch":
                    {
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Dancing Lights":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Druidcraft":
                    {
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "Eldritch Blast":
                    {
                        warlockCantripList.Add(cantrip);
                        break;
                    }
                case "Fire Bolt":
                    {
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Friends":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Guidance":
                    {
                        clericCantripList.Add(cantrip);
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "Light":
                    {
                        bardCantripList.Add(cantrip);
                        clericCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Mage Hand":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Mending":
                    {
                        bardCantripList.Add(cantrip);
                        clericCantripList.Add(cantrip);
                        druidCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Message":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Minor Illusion":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Poison Spray":
                    {
                        druidCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Prestidigitation":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Produce Flame":
                    {
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "Ray of Frost":
                    {
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Resistance":
                    {
                        clericCantripList.Add(cantrip);
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "Sacred Flame":
                    {
                        clericCantripList.Add(cantrip);
                        break;
                    }
                case "Shillelagh":
                    {
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "Shocking Grasp":
                    {
                        sorcererCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Spare the Dying":
                    {
                        clericCantripList.Add(cantrip);
                        break;
                    }
                case "Thaumaturgy":
                    {
                        clericCantripList.Add(cantrip);
                        break;
                    }
                case "Thorn Whip":
                    {
                        druidCantripList.Add(cantrip);
                        break;
                    }
                case "True Strike":
                    {
                        bardCantripList.Add(cantrip);
                        sorcererCantripList.Add(cantrip);
                        warlockCantripList.Add(cantrip);
                        wizardCantripList.Add(cantrip);
                        break;
                    }
                case "Vicious Mockery":
                    {
                        bardCantripList.Add(cantrip);
                        break;
                    }
            }
        }

        
    }
}
