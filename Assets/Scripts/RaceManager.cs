using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public enum State
    {
        prep,
        countdown,
        racing,
        done
    }

    public static State state = State.prep;

    static List<Racer> finishers;

    static List<GameObject> racers;
    static List<GameObject> ranking;
    static GameObject player1;
    static GameObject player2;
    static GameObject player3;
    static GameObject player4;

    static GameObject ranker;
    static float finishLine;

    static int countDown = 3;
    static float timer = 1;
    static float timerReset = 1;

    static float playerPlace;
    public static float PlayerPlace { get { return playerPlace; } }

    // Start is called before the first frame update
    void Start()
    {
        Racer.OnFinished += FinishQueue;
        PlayerController.OnPlayerDied += PlayerDead;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.prep:

                break;

            case State.countdown:
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    if (countDown >= 0)
                    {
                        ScreenManager.CountDown(countDown);
                        timer = timerReset;
                        countDown--;
                    }
                    else if (countDown == -1)
                    {
                        ScreenManager.CountDown(countDown);
                        timer = timerReset;

                        state = State.racing;
                        countDown = 3;
                    }
                }
                break;

            case State.racing:
                // List<GameObject> checkForFinishers = new List<GameObject>();
                // foreach (GameObject racer in racers)
                // {
                //     Racer racer1 = racer.GetComponent<Racer>();
                //     Racer.State racerState = racer1.RacerState;
                //     if (racerState == Racer.State.finished || racerState == Racer.State.dead) checkForFinishers.Add(racer);
                // }
                // if(checkForFinishers.Count == racers.Count)
                // {
                //     List<GameObject> racersCopy = new List<GameObject>(racers);
                //     foreach (GameObject racer in racersCopy)
                //     {
                //         Racer checkRacer = racer.GetComponent<Racer>();
                //         bool finishedCheck = finishers.Contains(checkRacer);
                // 
                //         if (!finishedCheck) finishers.Add(checkRacer);
                //     }
                // 
                //     state = State.done;
                //     ScreenManager.SetScreen(ScreenManager.Screen.endRace);
                // }
                break;

            case State.done:

                break;
        }
    }

    public static void SetupRacers()
    {
        state = State.prep;

        finishers = new List<Racer>();

        finishLine = TrackManager.GetFinishline();

        // will likely substantiate racers in the future
        player1 = GameObject.Find("PlayerRacer");
        player2 = GameObject.Find("EnemyRacer1");
        player3 = GameObject.Find("EnemyRacer2");
        player4 = GameObject.Find("EnemyRacer3");

        racers = new List<GameObject>
        {
            player1,
            player2,
            player3,
            player4
        };

        ranking = new List<GameObject>(racers);

        EnemyController.EnemyCounter = 0;

        foreach (GameObject racer in racers)
        {
            Racer temp = racer.GetComponent<Racer>();
            temp.SetupRacer();
        }

        DataManager.SaveGame();

        EnemyController.EnemyCounter = 0;
    }

    public static void UpdateRacers()
    {
        EnemyController.EnemyCounter = 0;

        foreach (GameObject racer in racers)
        {
            Racer temp = racer.GetComponent<Racer>();
            temp.UpdateRacer();
        }

        DataManager.SaveGame();
    }

    public static void ResetRace()
    {
        UpdateRacers();

        TrackManager.ResetTrack();

        state = State.prep;
        finishers = new List<Racer>();
        ranking = new List<GameObject>(racers);
        playerPlace = -1;
        foreach(GameObject racerGO in racers)
        {
            Racer racer = racerGO.GetComponent<Racer>();
            racer.ResetRacer();
        }

        TrackManager.SpawnPickups();

        player1.GetComponent<Racer>().UpdateRacer();
        DataManager.SaveGame();
    }

    public static void UpdateVolume(float volume)
    {
        if(racers != null)
        {
            foreach(GameObject racer in racers)
            {
                racer.GetComponent<Racer>().UpdateVolume(volume);
            }
        }
    }

    public static void StartRace()
    {
        state = State.countdown;
    }
    public static int GetPlace()
    {
        ranking = new List<GameObject>();
        ranking = RankUs();

        int place;
        place = ranking.IndexOf(player1);
        place++;

        Racer playerRacer = player1.GetComponent<Racer>();
        Racer.State playerState = playerRacer.RacerState;
        if (playerState == Racer.State.finished || playerState == Racer.State.dead) place = 0;

        return place;
    }

    public static List<GameObject> RankUs()
    {
        List<GameObject> racersCopy = new List<GameObject>(racers);
        ranking = new List<GameObject>();

        while (racersCopy.Count > 0)
        {
            float closest = Mathf.Infinity;
            foreach (GameObject racer in racersCopy)
            {
                float distanceToEnd = Vector2.Distance(racer.transform.position, new Vector2(racer.transform.position.x, finishLine + 50));
                if (distanceToEnd < closest)
                {
                    ranker = racer;
                    closest = distanceToEnd;
                }

            }
            racersCopy.Remove(ranker);
            ranking.Add(ranker);
        }

        return ranking;
    }
    public static List<GameObject> GetRacers()
    {
        return racers;
    }

    public static State GetState()
    {
        return state;
    }

    public static void FinishQueue(Racer finisher)
    {
        if(finisher.RacerState != Racer.State.dead) finishers.Add(finisher);

        if (finisher.GetRacerType() == Racer.RacerType.player)
        {
            EndRace();
            ScreenManager.SetScreen(ScreenManager.Screen.finish);
        }

    }

    public static void EndRace()
    {
        ranking = new List<GameObject>();
        ranking = RankUs();

        foreach (GameObject racer in ranking)
        {
            Racer checkRacer = racer.GetComponent<Racer>();
            if (checkRacer.RacerState != Racer.State.dead)
            {
                checkRacer.RacerState = Racer.State.finished;
                bool finishedCheck = finishers.Contains(checkRacer);

                if (!finishedCheck) finishers.Add(checkRacer);
            }
        }

        foreach (GameObject racer in ranking)
        {
            Racer checkRacer = racer.GetComponent<Racer>();
            bool finishedCheck = finishers.Contains(checkRacer);

            if (!finishedCheck) finishers.Add(checkRacer);
        }

        foreach(Racer racer in finishers)
        {
            if (racer.GetRacerType() == Racer.RacerType.player) playerPlace = finishers.IndexOf(racer);
        }

        state = State.done;
    }

    public static void PlayerDead()
    {
        EndRace();
        ScreenManager.SetScreen(ScreenManager.Screen.defeat);
    }

    public static List<Racer> GetRankings()
    {
        return finishers;
    }
}
