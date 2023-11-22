using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        idle,
        active
    }
    public static GameState state = GameState.idle;

    public static GameManager gameManager;
    public ScreenManager screenManager;
    public DataManager dataManager;
    public GarageManager garageManager;
    public ArmouryManager armouryManager;
    public SchoolManager schoolManager;

    static bool paused = false;
    public static bool Paused { get { return paused; } set { paused = value; } }
    static bool quit = false;
    public static bool Quit { set { quit = value; } }
    static int gameLevel;
    public static int GameLevel { get { return gameLevel; } set { gameLevel = value; } }
    private static bool gameLoaded = false;
    public static bool GameLoaded { get { return gameLoaded; } set { gameLoaded = value; } }

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        gameLevel = 0;
        garageManager.SetupGarage();
        armouryManager.SetupArmoury();
        schoolManager.SetupSchool();
        screenManager.SetupScreens();

        // Application.Quit();
    }

    private void Update()
    {
        if (quit) Application.Quit();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "GameplayScene")
        {
            TrackManager.SetupTrack();
            RaceManager.SetupRacers();
            state = GameState.active;
            Time.timeScale = 1;

            ScreenManager.SetScreen(ScreenManager.Screen.raceStart);
        }
        if (scene.name == "TitleScene")
        {
            state = GameState.idle;
            gameLevel = 0;

            ScreenManager.SetScreen(ScreenManager.Screen.title);
        }
    }

    public static void Pause()
    {
        if (!paused)
        {
            RaceManager.UpdateVolume(0);
            Time.timeScale = 0;
            ScreenManager.SetScreen(ScreenManager.Screen.pause);
            paused = true;
        }
        else if (paused)
        {
            RaceManager.UpdateVolume(ScreenManager.SoundVolume);
            Time.timeScale = 1;
            ScreenManager.SetScreen(ScreenManager.Screen.HUD);
            paused = false;
        }
    }
}
