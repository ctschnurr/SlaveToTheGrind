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

            ScreenManager.SetScreen(ScreenManager.Screen.raceStart);
        }
        if (scene.name == "TitleScene")
        {
            state = GameState.idle;

            ScreenManager.SetScreen(ScreenManager.Screen.title);
        }
    }
}
