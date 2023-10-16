using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static bool paused = false;
    static string playerName = "Ratt";
    // Start is called before the first frame update
    void Start()
    {
        TrackManager.SetupTrack();
        RaceManager.SetupRacers();
        ScreenManager.SetupScreens();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRace()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.HUD);
        RaceManager.StartRace();
    }

    public void Restart()
    {
        RaceManager.ResetRace();
        ScreenManager.SetScreen(ScreenManager.Screen.HUD);
        Time.timeScale = 1;
    }

    public static void Pause()
    {
        if(!paused)
        {
            Time.timeScale = 0;
            ScreenManager.SetScreen(ScreenManager.Screen.pause);
            paused = true;
        }
        else if (paused)
        {
            Time.timeScale = 1;
            ScreenManager.SetScreen(ScreenManager.Screen.HUD);
            paused = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowUpgrades()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.upgrades);
    }

    public static string GetPlayerName()
    {
        return playerName;
    }
}
