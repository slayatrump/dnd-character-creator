using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SelectionController : MonoBehaviour
{
    //References for the number of buttons in the scene
    //Not every scene uses the max number below, this just a max value
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

    //References for the number of checkmarks in the buttons in the scene
    //Not every scene uses the max number below, this just a max value
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

    //Way to check the size of these list in the inspector
    [SerializeField]
    private List<Button> buttons = new List<Button>();
    [SerializeField]
    private List<GameObject> checkmarks = new List<GameObject>();

    //Argument variables
    [HideInInspector] public string selected;
    [HideInInspector] public static bool isSelected = false;
    int size;

    void Start()
    {
        CheckingButtons();
        CheckingCheckmarks();
    }

    private void CheckingButtons()
    {
        // Checking each button object to see if there is a reference in them
        // then changes the buttons starting color and text
        // then adding them to a list of buttons
        if (b1 != null)
        {
            b1.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b1.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b1);
        }
        if (b2 != null)
        {
            b2.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b2.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b2);
        }
        if (b3 != null)
        {
            b3.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b3.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b3);
        }
        if (b4 != null)
        {
            b4.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b4.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b4);
        }
        if (b5 != null)
        {
            b5.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b5.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b5);
        }
        if (b6 != null)
        {
            buttons.Add(b6);
            b6.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b6.GetComponentInChildren<TMP_Text>().text = "X";
        }
        if (b7 != null)
        {
            buttons.Add(b7);
            b7.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b7.GetComponentInChildren<TMP_Text>().text = "X";
        }
        if (b8 != null)
        {
            b8.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b8.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b8);
        }
        if (b9 != null)
        {
            b9.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b9.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b9);
        }
        if (b10 != null)
        {
            b10.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b10.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b10);
        }
        if (b11 != null)
        {
            b11.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b11.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b11);
        }
        if (b12 != null)
        {
            b12.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b12.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b12);
        }
        if (b13 != null)
        {
            b13.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
            b13.GetComponentInChildren<TMP_Text>().text = "X";
            buttons.Add(b13);
        }
    }

    private void CheckingCheckmarks()
    {
        // Checking each checkmark object to see if there is a reference to them
        // then changes the checkmarks starting active state
        // then adding them to the list of checkmarks
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
                        b1.GetComponentInChildren<TMP_Text>().text = "_";
                        check1.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s2":
                    {
                        b2.GetComponentInChildren<TMP_Text>().text = "_";
                        check2.SetActive(true);
                        isSelected = true;

                        Deselect1();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s3":
                    {
                        b3.GetComponentInChildren<TMP_Text>().text = "_";
                        check3.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect1();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s4":
                    {
                        b4.GetComponentInChildren<TMP_Text>().text = "_";
                        check4.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect1();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s5":
                    {
                        b5.GetComponentInChildren<TMP_Text>().text = "_";
                        check5.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect1();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s6":
                    {
                        b6.GetComponentInChildren<TMP_Text>().text = "_";
                        check6.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect1();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s7":
                    {
                        b7.GetComponentInChildren<TMP_Text>().text = "_";
                        check7.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect1();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s8":
                    {
                        b8.GetComponentInChildren<TMP_Text>().text = "_";
                        check8.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect1();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s9":
                    {
                        b9.GetComponentInChildren<TMP_Text>().text = "_";
                        check9.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect1();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s10":
                    {
                        b10.GetComponentInChildren<TMP_Text>().text = "_";
                        check10.SetActive(true);
                        isSelected = true;


                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect1();
                        Deselect11();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s11":
                    {
                        b11.GetComponentInChildren<TMP_Text>().text = "_";
                        check11.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect1();
                        Deselect12();
                        Deselect13();

                        break;
                    }
                case "s12":
                    {
                        b12.GetComponentInChildren<TMP_Text>().text = "_";
                        check12.SetActive(true);
                        isSelected = true;

                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect1();
                        Deselect13();

                        break;
                    }
                case "s13":
                    {
                        b13.GetComponentInChildren<TMP_Text>().text = "_";
                        check13.SetActive(true);
                        isSelected = true;


                        Deselect2();
                        Deselect3();
                        Deselect4();
                        Deselect5();
                        Deselect6();
                        Deselect7();
                        Deselect8();
                        Deselect9();
                        Deselect10();
                        Deselect11();
                        Deselect12();
                        Deselect1();

                        break;
                    }
            }
        }
    }

    void Deselect1()
    {
        b1.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b1.GetComponentInChildren<TMP_Text>().text = "X";
        check1.SetActive(false);
    }
    void Deselect2()
    {
        b2.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b2.GetComponentInChildren<TMP_Text>().text = "X";
        check2.SetActive(false);
    }
    void Deselect3()
    {
        b3.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b3.GetComponentInChildren<TMP_Text>().text = "X";
        check3.SetActive(false);
    }
    void Deselect4()
    {
        b4.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b4.GetComponentInChildren<TMP_Text>().text = "X";
        check4.SetActive(false);
    }
    void Deselect5()
    {
        b5.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b5.GetComponentInChildren<TMP_Text>().text = "X";
        check5.SetActive(false);
    }
    void Deselect6()
    {
        b6.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b6.GetComponentInChildren<TMP_Text>().text = "X";
        check6.SetActive(false);
    }
    void Deselect7()
    {
        b7.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b7.GetComponentInChildren<TMP_Text>().text = "X";
        check7.SetActive(false);
    }
    void Deselect8()
    {
        b8.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b8.GetComponentInChildren<TMP_Text>().text = "X";
        check8.SetActive(false);
    }
    void Deselect9()
    {
        b9.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b9.GetComponentInChildren<TMP_Text>().text = "X";
        check9.SetActive(false);
    }
    void Deselect10()
    {
        b10.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b10.GetComponentInChildren<TMP_Text>().text = "X";
        check10.SetActive(false);
    }
    void Deselect11()
    {
        b11.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b11.GetComponentInChildren<TMP_Text>().text = "X";
        check11.SetActive(false);
    }
    void Deselect12()
    {
        b12.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b12.GetComponentInChildren<TMP_Text>().text = "X";
        check12.SetActive(false);
    }
    void Deselect13()
    {
        b13.GetComponentInChildren<TMP_Text>().fontStyle = FontStyles.Underline;
        b13.GetComponentInChildren<TMP_Text>().text = "X";
        check13.SetActive(false);
    }
}
