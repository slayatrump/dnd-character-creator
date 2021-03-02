using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reader : MonoBehaviour
{
    public Text txt;
    string ext;

    public void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Test");

        for (int i = 0; i < data.Count; i++)
        {
            ext += ("Name " + data[i]["Name"] + " " +
                "Number " + data[i]["Number"] + " ");
        }

        txt.text = ext;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
