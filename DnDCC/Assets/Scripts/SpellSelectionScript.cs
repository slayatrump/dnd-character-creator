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
    public GameObject spellCheckboxPrefab;
    public GameObject cantripCheckboxPrefab;

    public static int[] numList; //The numbers associated with classes for cantrips and spells

    public static int maxCants;
    public static int maxSpells;

    public string[] allCantrips; //All cantrips
    public string[] allFirstLevel; //All First Level spells

    //When functional, it should just take the class name from the current save data and use that instead
    public string chosenClass;

    GameObject cantripCheckbox;
    GameObject spellCheckbox;

    public Spell spell;

    // Start is called before the first frame update
    void Start()
    {
        chosenClass = SaveManager.instance.gameData.className;

        if (SaveManager.instance.gameData.spellList.Count != 0)
        {
            SaveManager.instance.gameData.spellList.Clear();
        }
        if (SaveManager.instance.gameData.cantripList.Count != 0)
        {
            SaveManager.instance.gameData.cantripList.Clear();
        }

        numList = new int[2];

        SetNumbers(chosenClass);

        PopCantripList();
        PopSpellList();
    }

    //Methods to set the Cantrip and First Level spell numbers according to chosen class
    #region Setting Spell Numbers
    public void SetNumbers(string chosenClass)
    {
        //Only classes that have spellcasting at the start are shown
        switch (chosenClass)
        {
            case "Bard":
                //spot 0 is Cantrips
                maxCants = 2;
                //spot 1 is 1st level spells
                maxSpells = 4;
                break;
            case "Cleric":
                //spot 0 is Cantrips
                maxCants = 3;
                //spot 1 is 1st level spells
                maxSpells = 0;
                break;
            case "Druid":
                //spot 0 is Cantrips
                maxCants = 2;
                //spot 1 is 1st level spells
                maxSpells = 0;
                break;
            case "Sorcerer":
                //spot 0 is Cantrips
                maxCants = 4;
                //spot 1 is 1st level spells
                maxSpells = 2;
                break;
            case "Warlock":
                //spot 0 is Cantrips
                maxCants = 2;
                //spot 1 is 1st level spells
                maxSpells = 2;
                break;
            case "Wizard":
                //spot 0 is Cantrips
                maxCants = 3;
                //spot 1 is 1st level spells
                maxSpells = 0;
                break;
        }

        //get the text component of labels and change it to array values
        GameObject.Find("Cantrips Number").GetComponent<TMP_Text>().text = $"{maxCants}";
        GameObject.Find("1L Number").GetComponent<TMP_Text>().text = $"{maxSpells}";
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
            //Create the game object that will be displayed
            cantripCheckbox = Instantiate(cantripCheckboxPrefab);
            Transform parent = GameObject.Find("CantripPanel/CantripList/Scroll").transform;

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            //The scroll panel object in the project has components that will organize things properly, so the only thing that has to be done
            //is setting the new checkbox as a parent of the right panel, no need for more transofrmation edits past that.
            cantripCheckbox.transform.SetParent(parent, false);

            //The text of the textbox should be the text of the spell name
            cantripCheckbox.GetComponentInChildren<TMP_Text>().text = cantrip.name;

            ResettingCantripInfo(cantrip.name);
        }
    }

    public void ResettingCantripInfo(string CantripName)
    {
        switch (CantripName)
        {
            case "Acid Splash":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Saving throw or take 1d6 acid damage. " +
                        "Creature within range, or choose two creatures within range that are within 5 feet of each other. " +
                        "A target must succeed on a Dexterity saving throw or take 1d6 acid damage.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell’s damage increases by 1d6 when you reach 5th level (2d6), " +
                        "11th level (3d6), and 17th level (4d6).");
                    break;
                }
            case "Blade Ward":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Self";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You extend your hand and trace a sigil of warding in the air. " +
                        "Until the end of your next turn, you have resistance against bludgeoning, piercing, and slashing damage dealt by weapon attacks.");
                    break;
                }
            case "Chill Touch":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Necromancy;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create a ghostly, skeletal hand in the space of a creature within range. " +
                        "Make a ranged spell attack against the creature to assail it with the chill of the grave. " +
                        "On a hit, the target takes 1d8 necrotic damage, and it can’t regain hit points until the start of your next turn. " +
                        "Until then, the hand clings to the target. " +
                        "If you hit an undead target, it also has disadvantage on attack rolls against you until the end of your next turn.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "this spell’s damage increases by 1d8 when you reach " +
                        "5th level (2d8), 11th level (3d8), and 17th level (4d8).");
                    break;
                }
            case "Dancing Lights":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A bit of phosphorous or wychwood, or a glowworm");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create up to four torch-sized lights within range, making them appear as torches, lanterns, or glowing orbs that hover in the air for the duration. " +
                        "You can also combine the four lights into one glowing vaguely humanoid form of Medium size. " +
                        "Whichever form you choose, each light sheds dim light in a 10-foot radius.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("As a bonus action on your turn, you can move the lights up to 60 feet to a new spot within range. " +
                        "A light must be within 20 feet of another light created by this spell, and a light winks out if it exceeds the spell’s range.");
                    break;
                }
            case "Druidcraft":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Whispering to the spirits of nature, you create one of the following effects within range:\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create a tiny, harmless sensory effect that predicts what the weather will be at your location for the next 24 hours. " +
                        "The effect might manifest as a golden orb  for clear skies, a cloud for rain, falling snowflakes for snow, and so on. This effect persists for 1 round.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You instantly make a flower blossom, a seed pod open, or a leaf bud bloom.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create an instantaneous, harmless sensory effect, such as falling leaves, a puff of wind, the sound of a small animal, or the faint odor of skunk. " +
                        "The effect  must fit in a 5-foot cube.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You instantly light or snuff out a candle, a torch, or a small campfire.");
                    break;
                }
            case "Eldritch Blast":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A beam of crackling energy streaks toward a creature within range. " +
                        "Make a ranged spell attack against the target. On a hit, the target takes 1d10 force damage.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "The spell creates more than one beam when you reach higher levels: Two beams at 5th level. Three beams at 11th level. " +
                        "Four beams at 17th level. You can direct the beams at the same target or at different ones. Make a separate attack roll for each beam.");
                    break;
                }
            case "Fire Bolt":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You hurl a mote of fire at a creature or object within range. Make a ranged spell attack against the target. On a hit, the target takes 1d10 fire damage. " +
                        "A flammable object hit by this spell ignites if it isn’t being worn or carried.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "This spell’s damage increases by 1d10 when you reach 5th level (2d10), 11th level (3d10), and 17th level (4d10).");
                    break;
                }
            case "Friends":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Self";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A small amount of makeup applied to the face as this spell is cast");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("For the duration, you have advantage on all Charisma checks directed at one creature of your choice that isn’t hostile toward you. " +
                        "When the spell ends, the creature realizes that you used magic to influence its mood and becomes hostile toward you. A creature prone to violence might attack you. " +
                        "Another creature might seek retribution in other ways (at the DM’s discretion), depending on the nature of your interaction with it.");
                    break;
                }
            case "Guidance":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch one willing creature. " +
                        "Once before the spell ends, the target can roll a d4 and add the number rolled to one ability check of its choice. " +
                        "It can roll the die before or after making the ability check. The spell then ends.");
                    break;
                }
            case "Light":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A firefly or phosphorescent moss");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch one object that is no larger than 10 feet in any dimension. " +
                        "Until the spell ends, the object sheds bright light in a 20-foot radius and dim light for an additional 20 feet. The light can be colored as you like. " +
                        "Completely covering the object with something opaque blocks the light. The spell ends if you cast it again or dismiss it as an action.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you target an object held or worn by a hostile creature, " +
                        "that creature must succeed on a Dexterity saving throw to avoid the spell.");
                    break;
                }
            case "Mage Hand":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A spectral, floating hand appears at a point you choose within range. " +
                        "The hand lasts for the duration or until you dismiss it as an action. " +
                        "The hand vanishes if it is ever more than 30 feet away from you or if you cast this spell again.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You can use your action to control the hand. " +
                        "You can use the hand to manipulate an object, open an unlocked door or container, stow or retrieve an item from an open container, or pour the contents out of a vial. " +
                        "You can move the hand up to 30 feet each time you use it.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The hand can’t attack, activate magical items, or carry more than 10 pounds.");
                    break;
                }
            case "Mending":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("Two lodestones");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell repairs a single break or tear in an object you touch, such as a broken chain link, two halves of a broken key, a torn cloak, or a leaking wineskin. " +
                        "As long as the break or tear is no larger than 1 foot in any dimension, you mend it, leaving no trace of the former damage.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell can also physically repair a magic item or construct, " +
                        "but the spell can’t restore magic to such an object.");
                    break;
                }
            case "Message":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A short piece of copper wire");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You point your finger toward a creature within range and whisper a message. " +
                        "The target (and only the target) hears the message and can reply in a whisper that only you can hear.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You can cast this spell through solid objects if you are familiar with the target and know it is beyond the barrier. " +
                        "Magical silence, 1 foot of stone, 1 inch of common metal, a thin sheet of lead, or 3 feet of wood blocks the spell. " +
                        "The spell doesn’t have to follow a straight line and can travel freely around corners or through openings.");
                    break;
                }
            case "Minor Illusion":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Illusion;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A bit of fleece");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create a sound or an image of an object within range that lasts for the duration. " +
                        "The illusion also ends if you dismiss it as an action or cast this spell again.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you create a sound, its volume can range from a whisper to a scream. " +
                        "It can be your voice, someone else’s voice, a lion’s roar, a beating of drums, or any other sound you choose. " +
                        "The sound continues unabated throughout the duration, or you can make discrete sounds at different times before the spell ends.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you create an image of an object such as a chair, muddy footprints, or a small chest it must be no larger than a 5-foot cube. " +
                        "The image can’t create sound, light, smell, or any other sensory effect. " +
                        "Physical interaction with the image reveals it to be an illusion, because things can pass through it.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If a creature uses its action to examine the sound or image, the creature can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. " +
                        "If a creature discerns the illusion for what it is, the illusion becomes faint to the creature.");
                    break;
                }
            case "Poison Spray":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "10 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You extend your hand toward a creature you can see within range and project a puff of noxious gas from your palm. " +
                        "The creature must succeed on a Constitution saving throw or take 1d12 poison damage.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "This spell’s damage increases by 1d12 when you reach " +
                        "5th level (2d12), 11th level (3d12), 17th level (4d12).");
                    break;
                }
            case "Prestidigitation":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "10 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell is a minor magical trick that novice spellcasters use for practice. " +
                        "You create one of the following magical effects within range:\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You create an instantaneous, harmless sensory effect, such as a shower of sparks, a puff of wind, faint musical notes, or an odd odor.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You instantaneously light or snuff out a candle, a torch, or a small campfire.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You instantaneously clean or soil an object no larger than 1 cubic foot.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You chill, warm, or flavor up to 1 cubic foot of nonliving material for 1 hour.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You make a color, a small mark, or a symbol appear on an object or a surface for 1 hour.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "You create a nonmagical trinket or an illusory image that can fit in your hand and that lasts until the end of your next turn.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "If you cast this spell multiple times, you can have up to three of its non-instantaneous effects active at a time, and you can dismiss such an effect as an action.");
                    break;
                }
            case "Produce Flame":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Self";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A flickering flame appears in your hand. " +
                        "The flame remains there for the duration and harms neither you nor your equipment. " +
                        "The flame sheds bright light in a 10-foot radius and dim light for an additional 10 feet. " +
                        "The spell ends if you dismiss it as an action or if you cast it again.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You can also attack with the flame, although doing so ends the spell. " +
                        "When you cast this spell, or as an action on a later turn, you can hurl the flame at a creature within 30 feet of you. " +
                        "Make a ranged spell attack. On a hit, the target takes 1d8 fire damage.");
                    break;
                }
            case "Ray of Frost":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A frigid beam of blue-white light streaks toward a creature within range. " +
                        "Make a ranged spell attack against the target. " +
                        "On a hit, it takes 1d8 cold damage, and its speed is reduced by 10 feet until the start of your next turn.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "The spell’s damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).");
                    break;
                }
            case "Resistance":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("A miniature cloak");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch one willing creature. " +
                        "Once before the spell ends, the target can roll a d4 and add the number rolled to one saving throw of its choice. " +
                        "It can roll the die before or after the saving throw. The spell then ends.");
                    break;
                }
            case "Sacred Flame":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Flame-like radiance descends on a creature that you can see within range. " +
                        "The target must succeed on a Dexterity saving throw or take 1d8 radiant damage. " +
                        "The target gains no benefit from cover for this saving throw.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "The spell’s damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).");
                    break;
                }
            case "Shillelagh":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("Mistletoe, a shamrock leaf, and a club or quarterstaff");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The wood of a club or quarterstaff you are holding is imbued with nature’s power. " +
                        "For the duration, you can use your spellcasting ability instead of Strength for the attack and damage rolls of melee attacks using that weapon, and the weapon’s damage die becomes a d8. " +
                        "The weapon also becomes magical, if it isn’t already. " +
                        "The spell ends if you cast it again or if you let go of the weapon.");
                    break;
                }
            case "Shocking Grasp":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Lightning springs from your hand to deliver a shock to a creature you try to touch. " +
                        "Make a melee spell attack against the target. You have advantage on the attack roll if the target is wearing armor made of metal. " +
                        "On a hit, the target takes 1d8 lightning damage, and it can’t take reactions until the start of its next turn. " +
                        "The spell ends if you cast it again or if you let go of the weapon.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        " The spell’s damage increases by 1d8 when you reach 5th level (2d8), 11th level (3d8), and 17th level (4d8).");
                    break;
                }
            case "Spare the Dying":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Necromancy;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "Touch";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch a living creature that has 0 hit points. " +
                        "The creature becomes stable. This spell has no effect on undead or constructs.");
                    break;
                }
            case "Thaumaturgy":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You manifest a minor wonder, a sign of supernatural power, within range. " +
                        "You create one of the following magical effects within range: \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Your voice booms up to three times as loud as normal for 1 minute. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You cause flames to flicker, brighten, dim, or change color for 1 minute. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You cause harmless tremors in the ground for 1 minute. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create an instantaneous sound that originates from a point of your choice within range, such as a rumble of thunder, the cry of a raven, or ominous whispers. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You instantaneously cause an unlocked door or window to fly open or slam shut. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You alter the appearance of your eyes for 1 minute. \n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you cast this spell multiple times, you can have up to three of its 1 minute effects active at a time, and you can dismiss such an effect as an action.");
                    break;
                }
            case "Thorn Whip":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    cantripCheckbox.GetComponent<Spell>().Components.Add("The stem off a plant with thorns");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create a long, vine-like whip covered in thorns that lashes out at your command toward a creature in range. " +
                        "Make a melee spell attack against the target. " +
                        "If the attack hits, the creature takes 1d6 piercing damage, " +
                        "and if the creature is Large or smaller, you pull the creature up to 10 feet closer to you.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "This spell’s damage increases by 1d6 when you reach 5th level (2d6), 11th level (3d6), and 17th level (4d6).");
                    break;
                }
            case "True Strike":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("S");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You extend your hand and point a finger at a target in range. " +
                        "Your magic grants you a brief insight into the target’s defenses. " +
                        "On your next turn, you gain advantage on your first attack roll against the target, provided that this spell hasn’t ended.");
                    break;
                }
            case "Vicious Mockery":
                {
                    cantripCheckbox.GetComponent<Spell>().SpellName = $"{CantripName}";
                    cantripCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    cantripCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    cantripCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    cantripCheckbox.GetComponent<Spell>().Components.Add("V");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You unleash a string of insults laced with subtle enchantments at a creature you can see within range. " +
                        "If the target can hear you (thought it need not understand you), " +
                        "it must succeed on a Wisdom saving throw or take 1d4 psychic damage and have " +
                        "disadvantage on the next attack roll it makes before the end of its next turn.\n");
                    cantripCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "This spell’s damage increases by 1d4 when you reach 5th level (2d4), 11th level (3d4), and 17th level (4d4).");
                    break;
                }
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

        foreach (GameObject spell in popList)
        {
            //Create the game object that will be displayed
            spellCheckbox = Instantiate(spellCheckboxPrefab);
            Transform parent = GameObject.Find("SpellPanel/SpellList/Scroll").transform;

            //checkbox needs to be a parent of the right scrollpanel so it populates properly
            //The scroll panel object in the project has components that will organize things properly, so the only thing that has to be done
            //is setting the new checkbox as a parent of the right panel, no need for more transofrmation edits past that.
            spellCheckbox.transform.SetParent(parent, false);

            //The text of the textbox should be the text of the spell name
            spellCheckbox.GetComponentInChildren<TMP_Text>().text = spell.name;

            ResettingSpellInfo(spell.name);
        }
    }

    public void ResettingSpellInfo(string SpellName)
    {
        switch (SpellName)
        {
            case "Alarm":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Minute";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A tiny bell and a piece of fine silver wire");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You set an alarm against unwanted intrusion. " +
                        "Choose a door, a window, or an area within range that is no larger than a 20-foot cube. " +
                        "Until the spell ends, an alarm alerts you whenever a Tiny or larger creature touches or enters the warded area. " +
                        "When you cast the spell, you can designate creatures that won’t set off the alarm. " +
                        "You also choose whether the alarm is mental or audible. ");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A mental alarm alerts you with a ping in your mind if you are within 1 mile of the warded area. " +
                        "This ping awakens you if you are sleeping. ");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("An audible alarm produces the sound of a hand bell for 10 seconds within 60 feet.");
                    break;
                }
            case "Animal Friendship":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A morsel of food");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell lets you convince a beast that you mean it no harm. " +
                        "Choose a beast that you can see within range. " +
                        "It must see and hear you. If the beast’s Intelligence is 4 or higher, the spell fails. " +
                        "Otherwise, the beast must succeed on a Wisdom saving throw or be charmed by you for the spell’s duration. " +
                        "If you or one of your companions harms the target, the spell ends. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can affect one additional beast for each slot level above 1st.");
                    break;
                }
            case "Armor of Agathys":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A cup of water");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A protective magical force surrounds you, manifesting as a spectral frost that covers you and your gear. " +
                        "You gain 5 temporary hit points for the duration. " +
                        "If a creature hits you with a melee attack while you have these hit points, the creature takes 5 cold damage. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can affect one additional beast for each slot level above 1st.");
                    break;
                }
            case "Arms of Hadar":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self & 10-foot radius";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You invoke the power of Hadar, the Dark Hunger. " +
                        "Tendrils of dark energy erupt from you and batter all creatures within 10 feet of you. " +
                        "Each creature in that area must make a Strength saving throw. " +
                        "On a failed save, a target takes 2d6 necrotic damage and can’t take reactions until its next turn. " +
                        "On a successful save, the creature takes half damage, but suffers no other effect. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st. ");
                    break;
                }
            case "Bane":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A drop of blood");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Up to three creatures of your choice that you can see within range must make Charisma saving throws. " +
                        "Whenever a target that fails this saving throw makes an attack roll or a saving throw before the spell ends, the target must roll a d4 and subtract the number rolled from the attack roll or saving throw. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.");
                    break;
                }
            case "Bless":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A sprinkling of holy water");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You bless up to three creatures of your choice within range. " +
                        "Whenever a target makes an attack roll or a saving throw before the spell ends, the target can roll a d4 and add the number rolled to the attack roll or saving throw. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.");
                    break;
                }
            case "Burning Hands":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("As you hold your hands with thumbs touching and fingers spread, a thin sheet of flames shoots forth from your outstretched fingertips. " +
                        "Each creature in a 15-foot cone must make a Dexterity saving throw. " +
                        "A creature takes 3d6 fire damage on a failed save, or half as much damage on a successful one. ");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The fire ignites any flammable objects in the area that aren’t being worn or carried. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st.");
                    break;
                }
            case "Charm Person":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You attempt to charm a humanoid you can see within range. ");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("It must make a Wisdom saving throw, and does so with advantage if you or your companions are fighting it. " +
                        "If it fails the saving throw, it is charmed by you until the spell ends or until you or your companions do anything harmful to it. " +
                        "The charmed creature regards you as a friendly acquaintance. When the spell ends, the creature knows it was charmed by you. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st. " +
                        "The creatures must be within 30 feet of each other when you target them.");
                    break;
                }
            case "Chromatic Orb":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "90 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A diamond worth at least 50 GP");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You hurl a 4-inch-diameter sphere of energy at a creature that you can see within range. " +
                        "You choose acid, cold, fire, lightning, poison, or thunder for the type of orb you create, and then make a ranged spell attack against the target. " +
                        "If the attack hits, the creature takes 3d8 damage of the type you chose. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st.");
                    break;
                }
            case "Color Spray":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Illusion;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "90 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A pinch of powder or sand that is colored red, yellow, and blue");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A dazzling array of flashing, colored light springs from your hand. " +
                        "Roll 6d10, the total is how many hit points of creatures this spell can effect. " +
                        "Creatures in a 15-foot cone originating from you are affected in ascending order of their current hit points (ignoring unconscious creatures and creatures that can’t see). ");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Starting with the creature that has the lowest current hit points, each creature affected by this spell is blinded until the spell ends. " +
                        "Subtract each creature’s hit points from the total before moving on to the creature with the next lowest hit points. " +
                        "A creature’s hit points must be equal to or less than the remaining total for the creature to be affected. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d10 for each slot level above 1st.");
                    break;
                }
            case "Command":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You speak a one-word command to a creature you can see within range. " +
                        "The target must succeed on a Wisdom saving throw or follow the command on its next turn. " +
                        "The spell has no effect if the target is undead, if it doesn’t understand your language, or if your command is directly harmful to it. Some typical commands and their effects follow. " +
                        "If the target can’t follow your command, the spell ends. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("" +
                        "Approach: The target moves toward you by the shortest and most direct route, ending its turn if it moves within 5 feet of you. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Drop: The target drops whatever it is holding and then ends its turn. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Flee: The target spends its turn moving away from you by the fastest available means. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Grovel: The target falls prone and then ends its turn. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Halt: The target doesn’t move and takes no actions. A flying creature stays aloft, provided that it is able to do so. " +
                        "If it must move to stay aloft, it flies the minimum distance needed to remain in the air.  \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can affect one additional creature for each slot level above 1st. " +
                        "The creatures must be within 30 feet of each other when you target them ");
                    break;
                }
            case "Comprehend Languages":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A pinch of soot and salt");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("For the duration, you understand the literal meaning of any spoken language that you hear. " +
                        "You also understand any spoken language that you hear. " +
                        "You also understand any written language that you see, but you must be touching the surface of which the words are written." +
                        " It takes about 1 minute to read one page of text. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell doesn’t decode secret messages in a text or glyph, such as an arcane sigil, that isn’t part of a written language. ");
                    break;
                }
            case "Create or Destroy Water":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A drop of water if creating water");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A few grains of sand if destroying it");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You either create or destroy water: \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Create Water: You create up to 10 gallons of clean water within range in an open container. " +
                        "Alternatively, the water falls as rain in a 30-foot cube within range, extinguishing exposed flames in the area. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Destroy Water: You destroy up to 10 gallons of water in an open container within range. " +
                        "Alternatively, you destroy fog in a 30-foot cube within range.  \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you create or destroy 10 additional gallons of water, or the size of the cube increases by 5 feet, for each slot level above 1st. ");
                    break;
                }
            case "Cure Wounds":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature you touch regains a number of hit points equal to 1d8 + your spellcasting ability modifier. " +
                        "This spell has no effect on undead or constructs. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d8 for each slot level above 1st. ");
                    break;
                }
            case "Detect Evil and Good":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("For the duration, you know if there is an aberration, celestial, elemental, fey, fiend, or undead within 30 feet of you, as well as where the creature is located. " +
                        "Similarly, you know if there is a place or object within 30 feet of you that has been magically consecrated or desecrated. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The spell can penetrate most barriers, but it is blocked by 1 foot of stone, 1 inch of common metal, " +
                        "a thin sheet of lead, or 3 feet of wood or dirt.");
                    break;
                }
            case "Detect Magic":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("For the duration, you sense the presence of magic within 30 feet of you. " +
                        "If you sense magic in this way, you can use your action to see a faint aura around any visible creature or object in the area that bears magic, and you learn its school of magic, if any. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The spell can penetrate most barriers, but is blocked by 1 foot of stone, 1 inch of common metal, " +
                        "a thin sheet of lead, or 3 feet of wood or dirt.");
                    break;
                }
            case "Detect Poison and Disease":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A yew leaf");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("For the duration, you can sense the presence and location of poisons, poisonous creatures, and diseases within 30 feet of you. " +
                        "You also identify the kind of poison, poisonous creature, or disease in each case. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The spell can penetrate most barriers, but is blocked by 1 foot of stone, 1 inch of common metal, " +
                        "a thin sheet of lead, or 3 feet of wood or dirt.");
                    break;
                }
            case "Disguise Self":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Illusion;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You make yourself–including your clothing, armor, weapons, and other belongings on your person–look different until the spell ends or until you use your action to dismiss it. " +
                        "You can seem 1 foot shorter or taller and can appear thin, fat, or in between. " +
                        "You can’t change your body type, so you must adopt a form that has the same basic arrangement of limbs. " +
                        "Otherwise, the extent of the illusion is up to you. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The changes wrought by this spell fail to hold up to physical inspection. " +
                        "For example, if you use this spell to add a hat to your outfit, objects pass through the hat, and anyone who touches it would feel nothing or would feel your head and hair. " +
                        "If you use this spell to appear thinner than you are, the hand of someone who reaches out to touch you would bump into you while it was seemingly still in midair. " +
                        "To discern that you are disguised, a creature can use its action to inspect your appearance and must succeed on an Intelligence (Investigation) check against your spell save DC.");
                    break;
                }
            case "Dissonant Whispers":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You whisper a discordant melody that only one creature of your choice within range can hear, wracking it with terrible pain. " +
                        "The target must make a Wisdom saving throw. " +
                        "On a failed save, it takes 3d6 psychic damage and must immediately use its reaction , if available, to move as far as its speed allows away from you. " +
                        "The creature doesn’t move into obviously dangerous ground, such as a fire or a pit. " +
                        "On a successful save, the target takes half as much damage and doesn’t have to move away. " +
                        "A deafened creature automatically succeeds on the save. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st.");
                    break;
                }
            case "Entangle Spell":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "90 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Grasping weeds and vines sprout from the ground in a 20-foot square starting from a point within range. " +
                        "For the duration, these plants turn the ground in the area into difficult terrain. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature in the area when you cast the spell must succeed on a Strength saving throw or be restrained by the entangling plants until the spell ends. " +
                        "A creature restrained by the plants can use its action to make a Strength check against your spell save DC. " +
                        "On a success, it frees itself. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("When the spell ends, the conjured plants wilts away.");
                    break;
                }
            case "Expeditious Retreat":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Bonus Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell allows you to move at an incredible pace. " +
                        "When you cast this spell, and then as a bonus action on each of your turns until the spell ends, you can take the Dash action.");
                    break;
                }
            case "False Life":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Necromancy;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A small amount of alcohol or distilled spirits");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Bolstering yourself with a necromantic facsimile of life, " +
                        "you gain 1d4 + 4 temporary hit points for the duration. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you gain 5 additional temporary hit points for each slot level above 1st.");
                    break;
                }
            case "Feather Fall":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "Special";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A small feather or piece of down");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Reaction: When you or a creature within 60 feet of you falls. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Choose up to five falling creatures within range. A falling creature’s rate of descent slows to 60 feet per round until the spell ends. " +
                        "If the creature lands before the spell ends, it takes no falling damage and can land on its feet, and the spell ends for that creature.");
                    break;
                }
            case "Find Familiar":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Hour";
                    spellCheckbox.GetComponent<Spell>().Range = "10 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("10 GP worth of charcoal, incense, and herbs that must be consumed by fire in a brass brazier");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You gain the service of a familiar, a spirit that takes an animal form you choose: bat, cat, crab, frog (toad), hawk. lizard, octopus, owl, poisonous snake, fish (quipper), rat, raven, sea horse, spider, or weasel. " +
                        "Appearing in an unoccupied space within range, the familiar has the statistics of the chosen form, though it is a celestial, fey or fiend (your choice) instead of a beast.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Your familiar acts independently of you, but it always obeys your commands. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("When the familiar drops to 0 hit points, it disappears, leaving behind no physical form. " +
                        "It reappears after you cast this spell again.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You can communicate with you familiar telepathically while within 100 feet" +
                        "Additionally, as an action, you can see through your familiar’s eyes and hear what it hears until the start of your next turn, gaining benefits the familiar has. " +
                        "Becuase of this, you are deaf and blind to your own senses.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("As an action, you can temporarily dismiss your familiar into a pocket dimension until called back. " +
                        "Alternatively, you can dismiss it forever. " +
                        "As an action while it is dismissed, it reappear in any unoccupied space within 30 feet of you.\n");
                    break;
                }
            case "Floating Disk":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A drop of mercury");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1 inch thick, that floats 3 feet above the ground in an unoccupied space of your choice that you can see within range. " +
                        "The disk remains for the duration, and can hold up to 500 pounds. " +
                        "If more weight is placed on it, the spell ends, and everything on the disk falls to the ground.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The disk is immobile while you are within 20 feet of it. " +
                        "If you move more than 20 feet away from it, the disk follows you so that it remains within 20 feet of you. It can move across uneven terrain, up or down stairs, slopes and the like, but it can't cross an elevation change of 10 feet or more. " +
                        "For example, the disk can't move across a 10-foot-deep pit, nor could it leave such a pit if it was created at the bottom. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you move more than 100 feet from the disk (typically because it can't move around an obstacle to follow you), the spell ends.");
                    break;
                }
            case "Fog Cloud":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create a 20-foot-radius sphere of fog centered on a point within range. The sphere spreads around corners, and its area is heavily obscured. " +
                        "It lasts for the duration or until a wind of moderate or greater speed (at least 10 miles per hour) disperses it.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the radius of the fog increases by 20 feet for each slot level above 1st.");
                    break;
                }
            case "Goodberry":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A sprig of mistletoe");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Up to ten berries appear in your hand and are infused with magic for the duration. " +
                        "A creature can use its action to eat one berry. " +
                        "Eating a berry restores 1 hit point, and the berry provides enough nourishment to sustain a creature for one day.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The berries lose their potency if they have not been consumed within 24 hours of the casting of this spell.");
                    break;
                }
            case "Grease":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A bit of pork rind or butter");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add(
                        "Slick grease covers the ground in a 10-foot square centered on a point within range and turns it into difficult terrain for the duration.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("When the grease appears, each creature standing in its area must succeed on a Dexterity saving throw or fall prone. " +
                        "A creature that enters the area or ends its turn there must also succeed on a Dexterity saving throw or fall prone.");
                    break;
                }
            case "Guiding Bolt":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A flash of light streaks toward a creature of your choice within range. Make a ranged spell attack against the target. " +
                        "On a hit, the target takes 4d6 radiant damage, and the next attack roll made against this target before the end of your next turn has advantage, " +
                        "thanks to the mystical dim light glittering on the target until then.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d6 for each slot level above 1st.");
                    break;
                }
            case "Healing Word":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Bonus Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature of your choice that you can see within range regains hit points equal to 1d4 + your spellcasting ability modifier. " +
                        "This spell has no effect on undead or constructs.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the healing increases by 1d4 for each slot level above 1st.");
                    break;
                }
            case "Hellish Rebuke":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "When Taking Damage";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You point your finger, and the creature that damaged you is momentarily surrounded by hellish flames. " +
                        "The creature must make a Dexterity saving throw. " +
                        "It takes 2d10 fire damage on a failed save, or half as much damage on a successful one.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d10 for each slot level above 1st.");
                    break;
                }
            case "Heroism":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A willing creature you touch is imbued with bravery. " +
                        "Until the spell ends, the creature is immune to being frightened and gains temporary hit points equal to your spellcasting ability modifier at the start of each of its turns. " +
                        "When the spell ends, the target loses any remaining temporary hit points from this spell.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.");
                    break;
                }
            case "Hex":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Bonus Action";
                    spellCheckbox.GetComponent<Spell>().Range = "90 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("The petrified eye of a newt");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You place a curse on a creature that you can see within range. " +
                        "Until the spell ends, you deal an extra 1d6 necrotic damage to the target whenever you hit it with an attack. " +
                        "Also, choose one ability when you cast the spell. " +
                        "The target has disadvantage on ability checks made with the chosen ability.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If the target drops to 0 hit points before this spell ends, " +
                        "you can use a bonus action on a subsequent turn of yours to curse a new creature.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A remove curse cast on the target ends this spell early.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 3rd or 4th level, you can maintain your concentration on the spell for up to 8 hours. " +
                        "When you use a spell slot of 5th level or higher, you can maintain your concentration on the spell for up to 24 hours.");
                    break;
                }
            case "Hideous Laughter":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("Tiny tarts and a feather that is waved in the air");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature of your choice that you can see within range perceives everything as hilariously funny and falls into fits of laughter if this spell affects it. " +
                        "The target must succeed on a Wisdom saving throw or fall prone, becoming incapacitated and unable to stand up for the duration. " +
                        "A creature with an Intelligence score of 4 or less isn't affected.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At the end of each of its turns, and each time it takes damage, the target can make another Wisdom saving throw. " +
                        "The target has advantage on the saving throw if it's triggered by damage. On a success, the spell ends.");
                    break;
                }
            case "Identify":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Minute";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A pearl worth at least 100 GP and an owl feather");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You choose one object that you must touch throughout the casting of the spell. " +
                        "If it is a magic item or some other magic-imbued object, you learn its properties and how to use them, whether it requires attunement to use, and how many charges it has, if any. " +
                        "You learn whether any spells are affecting the item and what they are. " +
                        "If the item was created by a spell, you learn which spell created it.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you instead touch a creature throughout the casting, you learn what spells, " +
                        "if any, are currently affecting it.");
                    break;
                }
            case "Illusory Script":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Illusion;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Minute";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A lead-based ink worth at least 10GP, which the spell consumes");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You write on parchment, paper, " +
                        "or some other suitable writing material and imbue it with a potent illusion that lasts for the duration.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("To you and any creatures you designate when you cast the spell, the writing appears normal, written in your hand," +
                        " and conveys whatever meaning you intended when you wrote the text. " +
                        "To all others, the writing appears as if it were written in an unknown or magical script that is unintelligible. " +
                        "Alternatively, you can cause the writing to appear to be an entirely different message, written in a different hand and language, though the language must be one you know.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Should the spell be dispelled, the original script and the illusion both disappear.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature with truesight can read the hidden message.");
                    break;
                }
            case "Inflict Wounds":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Necromancy;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Make a melee spell attack against a creature you can reach. " +
                        "On a hit, the target takes 3d10 necrotic damage.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d10 for each slot level above 1st.");
                    break;
                }
            case "Jump":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A grasshopper's hind leg");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch a creature. The creature's jump distance is tripled until the spell ends.");
                    break;
                }
            case "Longstrider":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A pinch of dirt");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch a creature. The target's speed increases by 10 feet until the spell ends.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, you can target one additional creature for each slot level above 1st.");
                    break;
                }
            case "Mage Armor":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Touch";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A piece of cured leather");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You touch a willing creature who isn't wearing armor, and a protective magical force surrounds it until the spell ends. The target's base AC becomes 13 + its Dexterity modifier. " +
                        "The spell ends if the target dons armor or if you dismiss the spell as an action.\n");
                    break;
                }
            case "Magic Missile":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create three glowing darts of magical force. " +
                        "Each dart hits a creature of your choice that you can see within range. " +
                        "A dart deals 1d4 + 1 force damage to its target. " +
                        "The darts all strike simultaneously, and you can direct them to hit one creature or several.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the spell creates one more dart for each slot level above 1st.");
                    break;
                }
            case "Protection from Evil and Good":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "120 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("Holy water or powdered silver and iron, which the spell consumes");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Until the spell ends, one willing creature you touch is protected against certain types of creatures: \n" +
                        "aberrations, celestials, elementals, fey, fiends, and undead.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The protection grants several benefits. " +
                        "Creatures of those types have disadvantage on attack rolls against the target. " +
                        "The target also can't be charmed, frightened, or possessed by them. " +
                        "If the target is already charmed, frightened, or possessed by such a creature, the target has advantage on any new saving throw against the relevant effect.");
                    break;
                }
            case "Purify Food and Drink":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Transmutation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "10 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("All nonmagical food and drink within a 5-foot-radius sphere centered on a point of " +
                        "your choice within range is purified and rendered free of poison and disease.");
                    break;
                }
            case "Ray of Sickness":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Necromancy;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A ray of sickening greenish energy lashes out toward a creature within range.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Make a ranged spell attack against the target. " +
                        "On a hit, the target takes 2d8 poison damage and must make a Constitution saving throw. " +
                        "On a failed save, it is also poisoned until the end of your next turn.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st.");
                    break;
                }
            case "Sanctuary":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Bonus Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A small silver mirror");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You ward a creature within range against attack. " +
                        "Until the spell ends, any creature who targets the warded creature with an attack or a harmful spell must first make a Wisdom saving throw. " +
                        "On a failed save, the creature must choose a new target or lose the attack or spell. " +
                        "This spell doesn't protect the warded creature from area effects, such as the explosion of a fireball.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If the warded creature makes an attack, casts a spell that affects an enemy, " +
                        "or deals damage to another creature, this spell ends.");
                    break;
                }
            case "Shield of Faith":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Bonus Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A small parchment with a bit of holy text written on it");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A shimmering field appears and surrounds a creature of your choice within range, " +
                        "granting it a +2 bonus to AC for the duration.");
                    break;
                }
            case "Shield":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Abjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "When Taking Damage";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("An invisible barrier of magical force appears and protects you. " +
                        "Until the start of your next turn, you have a +5 bonus to AC, including against the triggering attack, and you take no damage from magic missile.");
                    break;
                }
            case "Silent Image":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Illusion;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A bit of fleece");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You create the image of an object, a creature, or some other visible phenomenon that is no larger than a 15-foot cube. " +
                        "The image appears at a spot within range and lasts for the duration. " +
                        "The image is purely visual; it isn't accompanied by sound, smell, or other sensory effects.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You can use your action to cause the image to move to any spot within range. " +
                        "As the image changes location, you can alter its appearance so that its movements appear natural for the image. " +
                        "For example, if you create an image of a creature and move it, you can alter the image so that it appears to be walking.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Physical interaction with the image reveals it to be an illusion, because things can pass through it. " +
                        "A creature that uses its action to examine the image can determine that it is an illusion with a successful Intelligence (Investigation) check against your spell save DC. " +
                        "If a creature discerns the illusion for what it is, the creature can see through the image.");
                    break;
                }
            case "Sleep":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "90 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A pinch of fine sand, rose petals, or a cricket");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell sends creatures into a magical slumber. " +
                        "Roll 5d8; the total is how many hit points of creatures this spell can affect. " +
                        "Creatures within 20 feet of a point you choose within range are affected in ascending order of their current hit points (ignoring unconscious creatures).\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Starting with the creature that has the lowest current hit points, each creature affected by this spell falls unconscious until the spell ends, " +
                        "the sleeper takes damage, or someone uses an action to shake or slap the sleeper awake. " +
                        "Subtract each creature's hit points from the total before moving on to the creature with the next lowest hit points. " +
                        "A creature's hit points must be equal to or less than the remaining total for that creature to be affected.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Undead and creatures immune to being charmed aren't affected by this spell.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, roll an additional 2d8 for each slot level above 1st.");
                    break;
                }
            case "Speak with Animals":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Divination;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("You gain the ability to comprehend and verbally communicate with beasts for the duration. " +
                        "The knowledge and awareness of many beasts is limited by their intelligence, but at minimum, beasts can give you information about nearby locations and monsters, including whatever they can perceive or have perceived within the past day. " +
                        "You might be able to persuade a beast to perform a small favor for you, at the DM's discretion.");
                    break;
                }
            case "Tasha's Hideous Laughter":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Enchantment;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("Tiny tarts and a feather that is waved in the air");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A creature of your choice that you can see within range perceives everything as hilariously funny and falls into fits of laughter if this spell affects it. " +
                        "The target must succeed on a Wisdom saving throw or fall prone, becoming incapacitated and unable to stand up for the duration. " +
                        "A creature with an Intelligence score of 4 or less isn’t affected.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At the end of each of its turns, and each time it takes damage, the target can make another Wisdom saving throw. " +
                        "The target has advantage on the saving throw if it's triggered by damage. On a success, the spell ends.");
                    break;
                }
            case "Tenser's Floating Disk":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A drop of mercury");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell creates a circular, horizontal plane of force, 3 feet in diameter and 1 inch thick, " +
                        "that floats 3 feet above the ground in an unoccupied space of your choice that you can see within range.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The disk remains for the duration, and can hold up to 500 pounds. " +
                        "If more weight is placed on it, the spell ends, and everything on the disk falls to the ground.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("The disk is immobile while you are within 20 feet of it. If you move more than 20 feet away from it, the disk follows you so that it remains within 20 feet of you. " +
                        "It can move across uneven terrain, up or down stairs, slopes and the like, but it can’t cross an elevation change of 10 feet or more. " +
                        "For example, the disk can’t move across a 10-foot-deep pit, nor could it leave such a pit if it was created at the bottom.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you move more than 100 feet from the disk " +
                        "(typically because it can’t move around an obstacle to follow you), the spell ends.");
                    break;
                }
            case "Thunderwave":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "Self & 15-foot cube";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A wave of thunderous force sweeps out from you. " +
                        "Each creature in a 15-foot cube originating from you must make a Constitution saving throw. " +
                        "On a failed save, a creature takes 2d8 thunder damage and is pushed 10 feet away from you. " +
                        "On a successful save, the creature takes half as much damage and isn’t pushed.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("In addition, unsecured objects that are completely within the area of effect are automatically pushed 10 feet away from you by the spell’s effect, " +
                        "and the spell emits a thunderous boom audible out to 300 feet.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the damage increases by 1d8 for each slot level above 1st.");
                    break;
                }
            case "Unseen Servant":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Conjuration;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "60 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A bit of string and of wood");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("This spell creates an invisible, mindless, shapeless, Medium force that performs simple tasks at your command until the spell ends. " +
                    "The servant springs into existence in an unoccupied space on the ground within range. " +
                    "It has AC 10, 1 hit point, and a Strength of 2, and it can't attack. " +
                    "If it drops to 0 hit points, the spell ends.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Once on each of your turns as a bonus action, you can mentally command the servant to move up to 15 feet and interact with an object. " +
                        "The servant can perform simple tasks that a human servant could do, such as fetching things, cleaning, mending, folding clothes, lighting fires, serving food, and pouring wine. " +
                        "Once you give the command, the servant performs the task to the best of its ability until it completes the task, then waits for your next command.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("If you command the servant to perform a task that would move it more than 60 feet away from you, the spell ends.");
                    break;
                }
            case "Witch Bolt":
                {
                    spellCheckbox.GetComponent<Spell>().SpellName = $"{SpellName}";
                    spellCheckbox.GetComponent<Spell>().SpellLevel = 1;
                    spellCheckbox.GetComponent<Spell>().SchoolType = SchoolTypes.Evocation;
                    spellCheckbox.GetComponent<Spell>().CastingTime = "1 Action";
                    spellCheckbox.GetComponent<Spell>().Range = "30 Feet";
                    spellCheckbox.GetComponent<Spell>().Components.Add("V,S,M");
                    spellCheckbox.GetComponent<Spell>().Components.Add("A twig from a tree that has been struck by lightning");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("A beam of crackling, blue energy lances out toward a creature within range, " +
                        "forming a sustained arc of lightning between you and the target.\n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("Make a ranged spell attack against that creature. " +
                        "On a hit, the target takes 1d12 lightning damage, and on each of your turns for the duration, you can use your action to deal 1d12 lightning damage to the target automatically. " +
                        "The spell ends if you use your action to do anything else. " +
                        "The spell also ends if the target is ever outside the spell’s range or if it has total cover from you. \n");
                    spellCheckbox.GetComponent<Spell>().DescriptionParagraphs.Add("At Higher Levels: \n" +
                        "When you cast this spell using a spell slot of 2nd level or higher, the initial damage increases by 1d12 for each slot level above 1st.");
                    break;
                }
        }
    }
    #endregion

}
