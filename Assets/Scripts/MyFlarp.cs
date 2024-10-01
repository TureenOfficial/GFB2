using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyFlarp : MonoBehaviour
{
    public TMP_Text tdtext;
    public TMP_Text highscoretext;
    public TMP_Text leveltext;
    public TMP_Text flarpname;

    void Start()
    {
        tdtext.text = "TIMES DIED: " + PlayerPrefs.GetInt("timesdead").ToString();
        highscoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        leveltext.text = "LEVEL: " + PlayerPrefs.GetInt("level").ToString();
        flarpname.text = PlayerPrefs.GetString("flarpname");
    }
}
