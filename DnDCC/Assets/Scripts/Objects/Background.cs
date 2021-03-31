using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalEnums;

public class Background : MonoBehaviour
{
    #region Background Prefab Info
    //Background objects should be saved as "[background name] Background Object"

    public string Name;
    
    public SkillType SkillProficiency1;
    public SkillType SkillProficiency2;

    //"None" if its empty in the excel sheet
    public string[] ToolProficiencies;

    public int ExtraLanguagesKnown;

    public string[] Equipment;

    public int Gold;

    public string BackgroundFeature;
    #endregion

    #region Background UI Functionality

    #endregion
}
