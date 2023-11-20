using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public const float oilSlickDelay = 1f;
    public const float oilSlickPenalty = 0.25f;

    public const float baseSpeed = 2000f;
    public const float baseTurnSpeed = 50f;

    public const float baseBoostSpeed = 1000f;

    public const float baseBoostCooldown = 3f;
    public const float baseBoostRecharge = 5f;

    public const float bulletSpeed = baseSpeed * 2;
    public const float missleSpeed = 200;

    public const int bulletAmmoBase = 20;
    public const int missleAmmoBase = 5;
    public const int mineAmmoBase = 5;

    public const float bulletTimerBase = .5f;
    public const float missleTimerBase = 1.5f;
    public const float mineTimerBase = 1f;

    public const int firstPlaceReward = 150;
    public const int secondPlaceReward = 125;
    public const int thirdPlaceReward = 100;
    public const int fourthPlaceReward = 75;
    public const int participationReward = 50;
    public const int eliminationReward = 50;
}
