using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public const float oilSlickDelay = 1f;
    public const float oilSlickPenalty = 0.25f;

    public const float baseSpeed = 2000;
    public const float baseTurnSpeed = 50;

    public const float bulletSpeed = baseSpeed * 2;
    public const float missleSpeed = 250;

    public const int gameLevel = 1; // this will need to be in GameManager so it can be updated with level complete

    public const int firstPlaceReward = 150;
    public const int secondPlaceReward = 125;
    public const int thirdPlaceReward = 100;
    public const int fourthPlaceReward = 75;
    public const int participationReward = 50;
    public const int eliminationReward = 50;
}
