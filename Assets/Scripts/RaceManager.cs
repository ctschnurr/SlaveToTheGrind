using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceManager : MonoBehaviour
{
    public enum State
    {
        prep,
        countdown,
        racing,
        done
    }

    protected static State state = State.prep;

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

    // Start is called before the first frame update
    void Start()
    {
        Racer.OnFinished += FinishQueue;
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
                    if (countDown > 0)
                    {
                        ScreenManager.CountDown(countDown.ToString());
                        timer = timerReset;
                        countDown--;
                    }
                    else if (countDown == 0)
                    {
                        ScreenManager.CountDown("GO!");
                        timer = timerReset;
                        countDown--;

                    }
                    else if (countDown == -1)
                    {
                        ScreenManager.CountDown(" ");
                        timer = timerReset;

                        state = State.racing;
                    }
                }
                break;

            case State.racing:
                List<GameObject> checkForFinishers = new List<GameObject>();
                foreach (GameObject racer in racers)
                {
                    Racer racer1 = racer.GetComponent<Racer>();
                    Racer.State racerState = racer1.GetState();
                    if (racerState == Racer.State.finished || racerState == Racer.State.dead) checkForFinishers.Add(racer);
                }
                if(checkForFinishers.Count == racers.Count)
                {
                    state = State.done;
                    Debug.Log("Race has concluded.");
                }
                break;

            case State.done:

                break;
        }
    }

    public static void SetupRace()
    {
        finishers = new List<Racer>();
        finishLine = TrackManager.GetFinishline();

        // will likely substantiate racers in the future
        player1 = GameObject.Find("PlayerRacer");
        player2 = GameObject.Find("EnemyRacer1");
        player3 = GameObject.Find("EnemyRacer2");
        player4 = GameObject.Find("EnemyRacer3");

        racers = new List<GameObject>();

        racers.Add(player1);
        racers.Add(player2);
        racers.Add(player3);
        racers.Add(player4);

        ranking = new List<GameObject>(racers);

        foreach (GameObject racer in racers)
        {
            Racer temp = racer.GetComponent<Racer>();
            temp.SetupRacer();
        }
    }

    public static void StartRace()
    {
        state = State.countdown;
    }
    public static int GetPlace()
    {
        List<GameObject> racersCopy = new List<GameObject>(racers);
        ranking = new List<GameObject>();

        while (racersCopy.Count > 0)
        {
            float closest = Mathf.Infinity;
            foreach (GameObject racer in racersCopy)
            {
                float distanceToEnd = Vector2.Distance(racer.transform.position, new Vector2(racer.transform.position.x, finishLine));
                if (distanceToEnd < closest)
                {
                    ranker = racer;
                    closest = distanceToEnd;
                }

            }
            racersCopy.Remove(ranker);
            ranking.Add(ranker);
        }

        int place;
        place = ranking.IndexOf(player1);
        place++;

        Racer playerRacer = player1.GetComponent<Racer>();
        Racer.State playerState = playerRacer.GetState();
        if (playerState == Racer.State.finished || playerState == Racer.State.dead) place = 0;

        return place;
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
        string name = finisher.GetName();
        Debug.Log(name + " Finished!");

        finishers.Add(finisher);
    }
}