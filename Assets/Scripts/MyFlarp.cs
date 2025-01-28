using TMPro;
using UnityEngine;

public class MyFlarp : MonoBehaviour
{
    public TMP_Text tdtext;
    public TMP_Text highscoretext;
    public TMP_Text leveltext;
    public TMP_Text flarpname;
    public TMP_Text totflarps;
    public TMP_Text levelSubtitle;

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
        if(PlayerPrefs.GetInt("level") >= 1000)
        {
            levelSubtitle.text = $"LEVEL: {PlayerPrefs.GetString("levelTitle")} BIRB (1K+)";
        }
        else
        {
            levelSubtitle.text = $"LEVEL: {PlayerPrefs.GetString("levelTitle")} BIRB ({PlayerPrefs.GetInt("level")})";
        }
        tdtext.text = "TIMES DIED: " + PlayerPrefs.GetInt("timesdead").ToString();
        highscoretext.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore").ToString();
        leveltext.text = "LEVEL: " + PlayerPrefs.GetInt("level").ToString();
        flarpname.text = PlayerPrefs.GetString("flarpname");
    }
}
