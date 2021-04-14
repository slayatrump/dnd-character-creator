using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeatureDescriptionController : MonoBehaviour
{
    Text desc;

    // Start is called before the first frame update
    void Start()
    {
        desc = transform.GetComponentInChildren<Text>();
        desc.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDesc(string text)
    {
        desc.text = text;
    }

}
