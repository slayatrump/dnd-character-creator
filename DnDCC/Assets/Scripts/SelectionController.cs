using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

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
    public Button b11;
    public Button b12;
    public Button b13;

    public GameObject check1;
    public GameObject check2;
    public GameObject check3;
    public GameObject check4;
    public GameObject check5;
    public GameObject check6;
    public GameObject check7;
    public GameObject check8;
    public GameObject check9;
    public GameObject check10;
    public GameObject check11;
    public GameObject check12;
    public GameObject check13;

    [SerializeField]
    private List<Button> buttons = new List<Button>();
    [SerializeField]
    private List<GameObject> checkmarks = new List<GameObject>();

    string selected;
    int size;

    void Start()
    {
        CheckingButtons();
        CheckingCheckmarks();
    }

    private void CheckingButtons()
    {
        // Checking each button object to see if there is a reference in them
        // then changes the buttons starting color
        if (b1 != null)
        {
            b1.GetComponent<Image>().color = Color.green;
            b1.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b1.GetComponentInChildren<TMP_Text>().text = "X";
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
        if (b11 != null)
        {
            b11.GetComponent<Image>().color = Color.green;
            buttons.Add(b11);
        }
        if (b12 != null)
        {
            b12.GetComponent<Image>().color = Color.green;
            buttons.Add(b12);
        }
        if (b13 != null)
        {
            b13.GetComponent<Image>().color = Color.green;
            buttons.Add(b13);
        }
    }

    private void CheckingCheckmarks()
    {
        if (check1 != null)
        {
            check1.SetActive(false);
            checkmarks.Add(check1);
        }
        if (check2 != null)
        {
            check2.SetActive(false);
            checkmarks.Add(check2);
        }
        if (check3 != null)
        {
            check3.SetActive(false);
            checkmarks.Add(check3);
        }
        if (check4 != null)
        {
            check4.SetActive(false);
            checkmarks.Add(check4);
        }
        if (check5 != null)
        {
            check5.SetActive(false);
            checkmarks.Add(check5);
        }
        if (check6 != null)
        {
            check6.SetActive(false);
            checkmarks.Add(check6);
        }
        if (check7 != null)
        {
            check7.SetActive(false);
            checkmarks.Add(check7);
        }
        if (check8 != null)
        {
            check8.SetActive(false);
            checkmarks.Add(check8);
        }
        if (check9 != null)
        {
            check9.SetActive(false);
            checkmarks.Add(check9);
        }
        if (check10 != null)
        {
            check10.SetActive(false);
            checkmarks.Add(check10);
        }
        if (check11 != null)
        {
            check11.SetActive(false);
            checkmarks.Add(check11);
        }
        if (check12 != null)
        {
            check12.SetActive(false);
            checkmarks.Add(check12);
        }
        if (check13 != null)
        {
            check13.SetActive(false);
            checkmarks.Add(check13);
        }
    }

    public void Selected()
    {
        selected = EventSystem.current.currentSelectedGameObject.name;
        size = buttons.Count;

        if (size == 13)
        {
            switch (selected)
            {
                case "s1":
                    {
                        b1.GetComponent<Image>().color = Color.white;
                        b1.GetComponentInChildren<TMP_Text>().text = "";
                        b2.GetComponent<Image>().color = Color.green;
                        b3.GetComponent<Image>().color = Color.green;
                        b4.GetComponent<Image>().color = Color.green;
                        b5.GetComponent<Image>().color = Color.green;
                        b6.GetComponent<Image>().color = Color.green;
                        b7.GetComponent<Image>().color = Color.green;
                        b8.GetComponent<Image>().color = Color.green;
                        b9.GetComponent<Image>().color = Color.green;
                        b10.GetComponent<Image>().color = Color.green;
                        b11.GetComponent<Image>().color = Color.green;
                        b12.GetComponent<Image>().color = Color.green;
                        b13.GetComponent<Image>().color = Color.green;

                        check1.SetActive(true);
                        break;
                    }
            }
        }
    }
}
