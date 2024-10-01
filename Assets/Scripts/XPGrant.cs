using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPGrant : MonoBehaviour
{
    public LOGIC LOGICscript;
    public int xpgranted;
    public int grantedMult;
    public int currentxp;
    public void GrantXP()
    {
        switch(PlayerPrefs.GetString("Mode"))
        {
            case "Default":
            {
                grantedMult = 5;
                break;
            }

            case "Speed":
            {
                grantedMult = 8;
                break;
            }

            case "Hard":
            {
                grantedMult = 10;
                break;
            }
        }
            currentxp = PlayerPrefs.GetInt("xp");
            xpgranted = LOGICscript.totalflarps * grantedMult;
            PlayerPrefs.SetInt("xp", currentxp + xpgranted);


        //ty brandon
    }
}
