using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData gameData;

    public bool hasLoaded;

    public bool hasSaved;

    public void Awake()
    {
        instance = this;

        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + gameData.saveName + ".dat"))
        {
            Load();
        }
    }

    public void Save()
    {
        string savePath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));

        var stream = new FileStream(savePath + "/" + gameData.saveName + ".dat", FileMode.Create);

        serializer.Serialize(stream, gameData);

        stream.Close();

        Debug.Log("Game Saved");
    }

    public void Load()
    {
        string savePath = Application.persistentDataPath;

        if(File.Exists(savePath + "/" + gameData.saveName + ".dat"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));

            var stream = new FileStream(savePath + "/" + gameData.saveName + ".dat", FileMode.Open);

            gameData = serializer.Deserialize(stream) as SaveData;

            stream.Close();

            Debug.Log("Game Loaded: " + savePath);

            hasLoaded = true;
        }
    }

    public void DeleteSavedData()
    {
        string savePath = Application.persistentDataPath;

        if (File.Exists(savePath + "/" + gameData.saveName + ".dat"))
        {
            File.Delete(savePath + "/" + gameData.saveName + ".dat");
            
            Debug.Log("Saved data has been cleared");
        }
    }
}

[System.Serializable]
public class SaveData
{
    [Header("Save Data Name")]
    //Name of the savefile
    public string saveName;

    [Header("Ability Score and Modifier Save Data")]
    //Ability Scores and their Modifiers Info
    public string asMethodChoice;
    public int strScore;
    public int strMod;
    public int dexScore;
    public int dexMod;
    public int conScore;
    public int conMod;
    public int intScore;
    public int intMod;
    public int wisScore;
    public int wisMod;
    public int chaScore;
    public int chaMod;

    [Header("Race Info Save Data")]
    //Race Selection Info
    public string raceName;
    public string raceASType1;
    public string raceASType2;
    public int raceASIncrease1;
    public int raceASIncrease2;
    public int raceSpeed;
    public string raceBuild;
    public List<string> raceLanguages;
    public List<string> raceFeatures;

    [Header("Class Info Save Data")]
    //Class Selection Info
    public string className;
    public int hitDieType;
    public string ASTypeSavingThrow1;
    public string ASTypeSavingThrow2;
    public List<string> armorPreficiencies;
    public List<string> weaponPreficiencies;
    public List<string> classFeatures;
    public List<string> skillPreficiencies;
    public List<string> equipmentChoices;
    public bool canUseSpellsAtLvlOne;

    [Header("Background Info Save Data")]
    //Background Selection Info
    public string backgroundName;
    public int goldAmount;
    public string additionalSkill1;
    public string additionalSkill2;
    public int extraLanguageOptions;
    public List<string> toolPreficiencies;
    public string backgroundFeatures;
    public List<string> extraEquipment;

    [Header("Class Features Info Save Data")]
    //Class Features Selection Info
    public string classFeaturesChoice1;
    public string classFeaturesChoice2;

    [Header("Personality Info Save Data")]
    public string characterName;
    public string playerName;
    public string personalityTraits;
    public string ideals;
    public string bonds;
    public string flaws;

    [Header("Spells and Cantrips Save Data")]
    public List<string> spellList;
    public List<string> cantripList;
}