using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordRPC : MonoBehaviour
{
    Discord.Discord discord;
    private long unixTimeUnreset;
    void Start()
    {
        discord = new Discord.Discord(1333840279895146627, (ulong)Discord.CreateFlags.NoRequireDiscord);

        if(SceneManager.GetActiveScene().name == "FlarpMain")
            {
                unixTimeUnreset = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            }

        ChangeActivity();
    }
    void OnDisable()
    {
        discord.Dispose();
    }
    public void ChangeActivity()
    {
        var activityManager = discord.GetActivityManager();
        Scene scene = SceneManager.GetActiveScene();
        long unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    
        switch(scene.name)
        {
            case "FlarpMain":
            {
                var activity = new Discord.Activity()
                {
                        State = $"Playing {PlayerPrefs.GetString("Mode")} Mode - {PlayerPrefs.GetInt("flarpsThisRoundOnly")} Flarps",
                        Details = $"In Game",
                        Timestamps = {Start = unixTimeUnreset}
                };

                activityManager.UpdateActivity(activity, (res) => {});

                break;
            }
            case "OptionsMenu":
            {
                var activity = new Discord.Activity
                {
                        State = $"In Options Menu",
                        Timestamps = {Start = unixTime}
                };

                activityManager.UpdateActivity(activity, (res) => {});

                break;
            }
            case "MainMenu":
            {
                var activity = new Discord.Activity
                {
                        State = $"In Main Menu",
                        Timestamps = {Start = unixTime}
                };

                activityManager.UpdateActivity(activity, (res) => {});

                break;
            }
            case "LevelMenu":
            {
                var activity = new Discord.Activity
                {
                        State = $"In Level Menu",             
                        Timestamps = {Start = unixTime}
                };

                activityManager.UpdateActivity(activity, (res) => {});

                break;
            }
        }
    }

    void Update()
    {
        discord.RunCallbacks();
    }

}
