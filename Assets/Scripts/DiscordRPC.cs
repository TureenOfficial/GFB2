using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordRPC : MonoBehaviour
{
    Discord.Discord discord = new Discord.Discord(1333840279895146627, (ulong)Discord.CreateFlags.NoRequireDiscord);    
    string state_ = "Playing Great Flarp Birb 2";
    string details_ = "";
    string name_ = "Great Flarp Birb 2";
    public Scene scene;
    public void Start()
    {
        scene = SceneManager.GetActiveScene();

        if(PlayerPrefs.GetInt("rpcOn") == 1)
        {
            ChangeActivity();
        }
        else
        {
            print($"could not change: rpc = {PlayerPrefs.GetInt("rpcOn")}");
        }
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

        long startupUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds() - (long)Time.realtimeSinceStartup;


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
                    details_ = "Do You Even Flarp Bro?";
                }
                else
                {
                    details_ = "100% Flarpious Certified";
                };
                break;
            }
            case "OptionsMenu":
            {
                state_ = $"Editing Options";
                details_ = "Flarping the Settings...";
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
                        Name = name_,
                        Timestamps = {Start = startupUnixTimestamp},
                        State = state_,
                        Details = details_
                };
                activityManager.UpdateActivity(activity, (res) => {});
    }

}
