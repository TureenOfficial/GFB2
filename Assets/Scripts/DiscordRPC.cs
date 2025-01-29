using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class DiscordRPC : MonoBehaviour
{
    Discord.Discord discord;

    public void Start()
    {
        discord = new Discord.Discord(1333840279895146627, (ulong)Discord.CreateFlags.NoRequireDiscord);
        ChangeActivity();
    }
    public void OnDisable()
    {
        discord!?.Dispose();
    }
    public void Update()
    {
        discord.RunCallbacks();
    }
    public void ChangeActivity()
    {
        var activityManager = discord.GetActivityManager(); 
        Scene scene = SceneManager.GetActiveScene();
        long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        long startupUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - (long)Time.realtimeSinceStartup;
        string state_ = "Playing Great Flarp Birb 2";
        string details_ = "Flarping Everywhere";


        switch(scene.name)
        {
            case "FlarpMain":
            {
                state_ = $"Playing {PlayerPrefs.GetString("Mode")} Mode - {PlayerPrefs.GetInt("flarpsThisRoundOnly"), 0} Flarps";
                details_ = "Flarping Everywhere";
                break;
            }
            case "LevelMenu":
            {
                state_ = $"Viewing Level - Level {PlayerPrefs.GetInt("level")}";
                if(PlayerPrefs.GetInt("level") < 1)
                {
                    details_ = "Do you even Flarp bro?";
                }
                else
                {
                    details_ = "100% Flarpious";
                };
                break;
            }
            case "MainMenu":
            {
                state_ = "In The Menus";
                break;
            }
            default: 
            {
                state_ = "Playing Great Flarp Birb 2";
                details_ = "Flarping Everywhere";
                break;
            }
        }

                var activity = new Discord.Activity()
                {
                        Timestamps = {Start = startupUnixTimestamp},
                        State = state_,
                        Details = details_
                };
                activityManager.UpdateActivity(activity, (res) => {UnityEngine.Debug.Log("success");});

            
    }

}
