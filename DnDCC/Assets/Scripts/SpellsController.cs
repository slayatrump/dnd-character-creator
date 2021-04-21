using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellsController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SaveManager.instance.gameData.canUseSpellsAtLvlOne == false)
        {
            SceneManager.LoadScene("Personality");
        }
    }
}
