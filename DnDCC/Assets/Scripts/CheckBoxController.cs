using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxController : MonoBehaviour
{
    Text txt1;
    //Text txt2;
    //Text txt3;
    //Text txt4;

    Toggle check1;
    Toggle check2;

    public GameObject csvR1;
    public GameObject csvR2;

    // Start is called before the first frame update
    void Start()
    {
        txt1 = GameObject.Find("Text1").GetComponent<Text>();
        //txt2 = GameObject.Find("Text2").GetComponent<Text>();

        check1 = GameObject.Find("CheckBox1").GetComponent<Toggle>();
        check2 = GameObject.Find("CheckBox2").GetComponent<Toggle>();

        csvR1.SetActive(false);
        csvR2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (check1.isOn == true)
        {
            csvR1.SetActive(true);
            csvR2.SetActive(false);
            check2.isOn = false;
        }
        else
        {
            csvR1.SetActive(false);
            txt1.text = "";
        }

        if (check2.isOn == true)
        {
            csvR1.SetActive(false);
            csvR2.SetActive(true);
            check1.isOn = false;
        }
    }
}
