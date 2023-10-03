using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timer;
    float timerReset;

    public enum GameState
    {
        inactive,
        active
    }

    public static GameState state = GameState.inactive;
    // Start is called before the first frame update
    void Start()
    {
        TrackManager.SetupTrack();
        ScreenManager.SetupScreens();
        ScreenManager.CountDown();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }
    }
}
