using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVParsing : MonoBehaviour
{
    public TextAsset csvFile; // Reference of CSV file
    public Text contentArea; // Reference of contentArea where records are displayed


    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ','; // It defines field seperate chracter

    void Start()
    {
        readData();
    }

    // Read data from CSV file
    private void readData()
    {
        string[] records = csvFile.text.Split(lineSeperater);
        foreach (string record in records)
        {
            string[] fields = record.Split(fieldSeperator);
            foreach (string field in fields)
            {
                contentArea.text += field + "\t";
            }
            contentArea.text += '\n';
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
