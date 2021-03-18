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

            Debug.Log("Game Loaded");

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
    //Name of the savefile
    public string saveName;

    //Ability Scores and their Modifiers
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

    //Race Selection
    public string raceName;
    public int raceASIncrease1;
    public int raceASIncrease2;
    public string raceASType1;
    public string raceASType2;
    public List<string> raceLanguages;
    public List<string> raceFeatures;
    public int raceSpeed;
    public string raceBuild;
}