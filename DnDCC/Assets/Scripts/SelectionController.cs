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
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;
    public Button b9;
    public Button b10;

    public List<Button> buttons;

    string selected;
    int size;

    void Start()
    {
        // Checking each button object to see if there is a reference in them
        // then changes the buttons starting color
        if (b1 != null)
        {
            b1.GetComponent<Image>().color = Color.green;
            buttons.Add(b1);
        }
        if (b2 != null)
        {
            b2.GetComponent<Image>().color = Color.green;
            buttons.Add(b2);
        }
        if (b3 != null)
        {
            b3.GetComponent<Image>().color = Color.green;
            buttons.Add(b3);
        }
        if (b4 != null)
        {
            b4.GetComponent<Image>().color = Color.green;
            buttons.Add(b4);
        }
        if (b5 != null)
        {
            b5.GetComponent<Image>().color = Color.green;
            buttons.Add(b5);
        }
        if (b6 != null)
        {
            b6.GetComponent<Image>().color = Color.green;
            buttons.Add(b6);
        }
        if (b7 != null)
        {
            b7.GetComponent<Image>().color = Color.green;
            buttons.Add(b7);
        }
        if (b8 != null)
        {
            b8.GetComponent<Image>().color = Color.green;
            buttons.Add(b8);
        }
        if (b9 != null)
        {
            b9.GetComponent<Image>().color = Color.green;
            buttons.Add(b9);
        }
        if (b10 != null)
        {
            b10.GetComponent<Image>().color = Color.green;
            buttons.Add(b10);
        }
    }

    public void Selected()
    {
        selected = EventSystem.current.currentSelectedGameObject.name;
        size = buttons.Count;

        if (size == 3)
        {
            switch (selected)
            {
                case "s1":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.white;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.green;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.green;
                        }
                        break;
                    }
                case "s2":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.green;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.white;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.green;
                        }
                        break;
                    }
                case "s3":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.green;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.green;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.white;
                        }
                        break;
                    }
            }
        }
        if (size == 4)
        {
            switch (selected)
            {
                case "s1":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.white;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.green;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.green;
                        }
                        if (b4 != null)
                        {
                            b4.GetComponent<Image>().color = Color.green;
                        }
                        break;
                    }
                case "s2":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.green;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.white;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.green;
                        }
                        if (b4 != null)
                        {
                            b4.GetComponent<Image>().color = Color.green;
                        }
                        break;
                    }
                case "s3":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.green;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.green;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.white;
                        }
                        if (b4 != null)
                        {
                            b4.GetComponent<Image>().color = Color.green;
                        }
                        break;
                    }
                case "s4":
                    {
                        if (b1 != null)
                        {
                            b1.GetComponent<Image>().color = Color.green;
                        }
                        if (b2 != null)
                        {
                            b2.GetComponent<Image>().color = Color.green;
                        }
                        if (b3 != null)
                        {
                            b3.GetComponent<Image>().color = Color.green;
                        }
                        if (b4 != null)
                        {
                            b4.GetComponent<Image>().color = Color.white;
                        }
                        break;
                    }
            }
        }
    }
}
