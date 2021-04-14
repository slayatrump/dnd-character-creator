using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassFeaturesMenuController : MonoBehaviour
{
    ClassFeaturesController featureList;

    // Start is called before the first frame update
    void Start()
    {
        featureList = FindObjectOfType<ClassFeaturesController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*Basics of this method:
     * Checks which child list panel is active, then checks if the selection is empty,
     * then goes through each choice to see which has a matching child object (s1, s2, s3, etc.)
     * then Sets choice1 if its anything but the second domain for cleric
     * If it is the first domain for cleric, saves the choice and enables a second choice panel
     */
    public void FetauresToSpells()
    {
        string selectedName;

        //if on the first cleric domain choice
        if (featureList.gameObject.transform.GetChild(0).gameObject.activeSelf)
        {
            selectedName = featureList.gameObject.transform.GetChild(0).GetComponentInChildren<SelectionController>().selected;

            if (selectedName == "")
            {
                return;
            }

            for(int i = 0; i < 7; i++)
            {
                if (featureList.gameObject.transform.GetChild(0).GetChild(i).GetChild(1).name == selectedName)
                {
                    SaveManager.instance.gameData.classFeaturesChoice1 = featureList.gameObject.transform.GetChild(0).GetChild(i).name;
                    break;
                }
            }
            Debug.Log($"{SaveManager.instance.gameData.classFeaturesChoice1}");


            //disable first choice panel and enable second choice panel
            featureList.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            featureList.gameObject.transform.GetChild(4).gameObject.SetActive(true);
            return;
        }

        //Cleric part 2
        else if (featureList.gameObject.transform.GetChild(4).gameObject.activeSelf)
        {
            selectedName = featureList.gameObject.transform.GetChild(4).GetComponentInChildren<SelectionController>().selected;

            if (selectedName == "")
            {
                return;
            }

            for (int i = 0; i < 7; i++)
            {
                if (featureList.gameObject.transform.GetChild(4).GetChild(i).GetChild(1).name == selectedName)
                {
                    SaveManager.instance.gameData.classFeaturesChoice2 = featureList.gameObject.transform.GetChild(4).GetChild(i).name;
                    break;
                }
            }
            Debug.Log($"{SaveManager.instance.gameData.classFeaturesChoice2}");

            SceneManager.LoadScene("Spells");
            return;
        }

        //Fighter
        else if (featureList.gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            selectedName = featureList.gameObject.transform.GetChild(1).GetComponentInChildren<SelectionController>().selected;

            if (selectedName == "")
            {
                return;
            }

            for (int i = 0; i < 6; i++)
            {
                if (featureList.gameObject.transform.GetChild(1).GetChild(i).GetChild(1).name == selectedName)
                {
                    SaveManager.instance.gameData.classFeaturesChoice1 = featureList.gameObject.transform.GetChild(1).GetChild(i).name;
                    break;
                }
            }
            Debug.Log($"{SaveManager.instance.gameData.classFeaturesChoice1}");

            SceneManager.LoadScene("Spells");
            return;
        }

        //Sorcerer
        else if (featureList.gameObject.transform.GetChild(2).gameObject.activeSelf)
        {
            selectedName = featureList.gameObject.transform.GetChild(2).GetComponentInChildren<SelectionController>().selected;

            if (selectedName == "")
            {
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                if (featureList.gameObject.transform.GetChild(2).GetChild(i).GetChild(1).name == selectedName)
                {
                    SaveManager.instance.gameData.classFeaturesChoice1 = featureList.gameObject.transform.GetChild(2).GetChild(i).name;
                    break;
                }
            }
            Debug.Log($"{SaveManager.instance.gameData.classFeaturesChoice1}");

            SceneManager.LoadScene("Spells");
            return;
        }

        //Warlock
        else if (featureList.gameObject.transform.GetChild(3).gameObject.activeSelf)
        {
            selectedName = featureList.gameObject.transform.GetChild(3).GetComponentInChildren<SelectionController>().selected;

            if (selectedName == "")
            {
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (featureList.gameObject.transform.GetChild(3).GetChild(i).GetChild(1).name == selectedName)
                {
                    SaveManager.instance.gameData.classFeaturesChoice1 = featureList.gameObject.transform.GetChild(3).GetChild(i).name;
                    break;
                }
            }
            Debug.Log($"{SaveManager.instance.gameData.classFeaturesChoice1}");

            SceneManager.LoadScene("Spells");
            return;
        }

    }
}
