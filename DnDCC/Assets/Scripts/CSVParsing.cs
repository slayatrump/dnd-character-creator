using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{
    public TextAsset csvFile;
    public Text contentArea;

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter



    // Start is called before the first frame update
    void Start()
    {
        readData();
    }

    public void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            foreach (string field in fields)
            {
                contentArea.text += field + "\t";
            }
            contentArea.text += ":" + "\n";
        }
    }
}
