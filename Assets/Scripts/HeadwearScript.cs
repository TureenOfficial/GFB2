using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadwearScript : MonoBehaviour
{
    List<string> dropdownCrownOption = new List<string> {"Crown"};
    //List<string> dropdownDefaultOptions = new List<string> {"Stetson", "Hippie Hat"};
    public TMPro.TMP_Dropdown headwearDropdown;
    public int flarpHeadwearLocal;

    public void DeleteData()
    {
        if(PlayerPrefs.GetInt("crowncanactive") == 1)
        {
            int crownIndex = 1; //CHANGE IF LOCATION OF CROWN INDEX CHANGES
            headwearDropdown.options.RemoveAt(crownIndex);
        }
        Load();
    }
    public void Load()
    {
        switch(PlayerPrefs.GetString("headwear"))
        {
            case "None":
            {
                flarpHeadwearLocal = 0;
                break;
            }
            case "Crown":
            {
                flarpHeadwearLocal = 1;
                break;
            }

        }

        headwearDropdown.value = flarpHeadwearLocal;
    }
    void Start()
    {
        AddOption();
        Load();
    }

    public void ChangeHeadwear()
    {
        PlayerPrefs.SetString("headwear", headwearDropdown.options[headwearDropdown.value].text);
        print(PlayerPrefs.GetString("headwear"));
    }
    public void AddOption()
    {
        //headwearDropdown.AddOptions(dropdownDefaultOptions);

        if (PlayerPrefs.GetInt("crowncanactive") == 1)
        {
            headwearDropdown.AddOptions(dropdownCrownOption);
        }
    }
}
