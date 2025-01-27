using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadwearScript : MonoBehaviour
{
    List<string> dropdownCrownOption = new List<string> {"Crown"};
    List<string> dropdownDefaultOptions = new List<string> {"Stetson", "Hippie Hat"};
    public TMPro.TMP_Dropdown headwearDropdown;
    public int flarpHeadwearLocal;

    public void DeleteData()
    {
        for (int i = headwearDropdown.options.Count - 1; i >= 0; i--)
        {
            switch (headwearDropdown.options[i].text)
            {
                case "Crown": //deletes any option with "crown"
                    headwearDropdown.options.RemoveAt(i);
                    break;
            }
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
            case "Stetson":
            {
                flarpHeadwearLocal = 1;
                break;
            }
            case "Hippie Hat":
            {
                flarpHeadwearLocal = 2;
                break;
            }
            case "Crown":
            {
                flarpHeadwearLocal = 3;
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
    }
    public void AddOption()
    {
        headwearDropdown.AddOptions(dropdownDefaultOptions); //first to get added {1, 2}

        if (PlayerPrefs.GetInt("crowncanactive") == 1)
        {
            headwearDropdown.AddOptions(dropdownCrownOption); //last to get added {last option}
        }
    }
}
