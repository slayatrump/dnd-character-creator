using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassFeaturesController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        //TEST CODE REMOVE BEFORE DELIVERABLE
        SaveManager.instance.gameData.raceName = "Warlock";
        //END TEST CODE

        if (SaveManager.instance.gameData.raceName == "Warlock")
        {
            //enable the warlock panel
            transform.GetChild(3).gameObject.SetActive(true);

        }
        else if(SaveManager.instance.gameData.raceName == "Sorcerer")
        {
            //enable the sorcerer panel
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else if(SaveManager.instance.gameData.raceName == "Fighter")
        {
            //enable the fighter panel
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else if(SaveManager.instance.gameData.raceName == "Cleric")
        {
            //enable the cleric panel
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            //go to next scene (spells)
            Debug.Log("Class Features skipped due to class not having a feature to choose");
            SceneManager.LoadScene("Spells");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
