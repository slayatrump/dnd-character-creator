﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class ParseXML : MonoBehaviour {

	// Use this for initialization
	void Start () {

        List<Dictionary<string, string>> allTextDic = parseFile();
        foreach (Dictionary<string, string> dic in allTextDic)
        {
            Debug.Log(dic["riddle"]);
            Debug.Log(dic["ans"]);
        }
    }

    public List<Dictionary<string, string>> parseFile()
    {
        TextAsset txtXmlAsset = Resources.Load<TextAsset>("riddles");
        var doc = XDocument.Parse(txtXmlAsset.text);

        var allDict = doc.Element("document").Elements("row");
        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
        foreach (var oneDict in allDict)
        {
            var twoStrings = oneDict.Elements("string");
            XElement element1 = twoStrings.ElementAt(0);
            XElement element2 = twoStrings.ElementAt(1);
            string first = element1.ToString().Replace("<string>", "").Replace("</string>", "");
            string second = element2.ToString().Replace("<string>", "").Replace("</string>", "");

            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("riddle", first);
            dic.Add("ans", second);

            allTextDic.Add(dic);
        }

        return allTextDic;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
