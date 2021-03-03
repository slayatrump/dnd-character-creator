using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionController : MonoBehaviour
{
    public Button b1;
    public Button b2;
    public Button b3;

    string selected;

    // Start is called before the first frame update
    void Start()
    {
        b1.GetComponent<Image>().color = Color.green;
        b2.GetComponent<Image>().color = Color.green;
        b3.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        //b1.onClick.AddListener(Selected);
    }

    public void Selected()
    {
        selected = EventSystem.current.currentSelectedGameObject.name;

        //if (b1)
        //{
        //    b1.GetComponent<Image>().color = Color.green;
        //    b2.GetComponent<Image>().color = Color.green;
        //    b3.GetComponent<Image>().color = Color.green;
        //}

        switch (selected)
        {
            case "BarbarianSelect":
                {
                    b1.GetComponent<Image>().color = Color.white;
                    b2.GetComponent<Image>().color = Color.green;
                    b3.GetComponent<Image>().color = Color.green;
                    break;
                }
            case "BardSelect":
                {
                    b1.GetComponent<Image>().color = Color.green;
                    b2.GetComponent<Image>().color = Color.white;
                    b3.GetComponent<Image>().color = Color.green;
                    break;
                }
            case "ClericSelect":
                {
                    b1.GetComponent<Image>().color = Color.green;
                    b2.GetComponent<Image>().color = Color.green;
                    b3.GetComponent<Image>().color = Color.white;
                    break;
                }
        }


    }
}
