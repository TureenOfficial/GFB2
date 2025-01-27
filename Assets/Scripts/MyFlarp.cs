using TMPro;
using UnityEngine;

public class MyFlarp : MonoBehaviour
{
    public TMP_Text tdtext;
    public TMP_Text highscoretext;
    public TMP_Text leveltext;
    public TMP_Text flarpname;
    public TMP_Text totflarps;

    void Start()
    {
        if(PlayerPrefs.GetInt("alltimeflarps") >= 10000)
        {
            totflarps.text = "TOTAL FLARPS: " + "10K+";
        }
        else
        {
            totflarps.text = "TOTAL FLARPS: " + PlayerPrefs.GetInt("alltimeflarps").ToString();
        }

        tdtext.text = "TIMES DIED: " + PlayerPrefs.GetInt("timesdead").ToString();
        highscoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        leveltext.text = "LEVEL: " + PlayerPrefs.GetInt("level").ToString();
        flarpname.text = PlayerPrefs.GetString("flarpname");
    }
}
