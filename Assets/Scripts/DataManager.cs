using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    static int saveSlot;
    public static int SaveSlot { get { return saveSlot; } set { saveSlot = value; } }
    static SaveData gameData;

    static RacerData playerSave;
    public static RacerData PlayerSave { get { return playerSave; } set { playerSave = value; } }
    static RacerData enemy1Save;
    public static RacerData Enemy1Save { get { return enemy1Save; } set { enemy1Save = value; } }
    static RacerData enemy2Save;
    public static RacerData Enemy2Save { get { return enemy2Save; } set { enemy2Save = value; } }
    static RacerData enemy3Save;
    public static RacerData Enemy3Save { get { return enemy3Save; } set { enemy3Save = value; } }
    protected static RacerData[] enemySaves;
    public static RacerData[] EnemySaves { get { return enemySaves; } set { enemySaves = value; } }

    // Start is called before the first frame update

    public static string[] CheckSaveData(int slotNumber)
    {
        SaveData saveData = new SaveData();
        string[] saveDataString = null;

        switch (slotNumber)
        {
            case 1:
                if (File.Exists(Application.persistentDataPath + "/save01.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream saveFile = File.Open(Application.persistentDataPath + "/save01.dat", FileMode.Open);
                    saveData = (SaveData)bf.Deserialize(saveFile);
                    RacerData playerData = saveData.playerData;
                    saveDataString = new string[4];
                    saveDataString[0] = playerData.money.ToString();
                    saveDataString[1] = playerData.racerColor;
                    saveDataString[2] = playerData.racerName;
                    saveDataString[3] = playerData.gameLevel.ToString();
                    saveFile.Close();
                }
                break;

            case 2:
                if (File.Exists(Application.persistentDataPath + "/save02.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream saveFile = File.Open(Application.persistentDataPath + "/save02.dat", FileMode.Open);
                    saveData = (SaveData)bf.Deserialize(saveFile);
                    RacerData playerData = saveData.playerData;
                    saveDataString = new string[4];
                    saveDataString[0] = playerData.money.ToString();
                    saveDataString[1] = playerData.racerColor;
                    saveDataString[2] = playerData.racerName;
                    saveDataString[3] = playerData.gameLevel.ToString();
                    saveFile.Close();
                }
                break;

            case 3:
                if (File.Exists(Application.persistentDataPath + "/save03.dat"))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream saveFile = File.Open(Application.persistentDataPath + "/save03.dat", FileMode.Open);
                    saveData = (SaveData)bf.Deserialize(saveFile);
                    RacerData playerData = saveData.playerData;
                    saveDataString = new string[4];
                    saveDataString[0] = playerData.money.ToString();
                    saveDataString[1] = playerData.racerColor;
                    saveDataString[2] = playerData.racerName;
                    saveDataString[3] = playerData.gameLevel.ToString();
                    saveFile.Close();
                }
                break;
        }

        return saveDataString;
    }
    public static void NewSave()
    {
        FileStream saveFile = null;
        if (saveSlot == 1) saveFile = File.Open(Application.persistentDataPath + "/save01.dat", FileMode.Create);
        if (saveSlot == 2) saveFile = File.Open(Application.persistentDataPath + "/save02.dat", FileMode.Create);
        if (saveSlot == 3) saveFile = File.Open(Application.persistentDataPath + "/save03.dat", FileMode.Create);

        playerSave = new RacerData();
        enemy1Save = new RacerData();
        enemy2Save = new RacerData();
        enemy3Save = new RacerData();

        enemySaves = new[] { enemy1Save, enemy2Save, enemy3Save };

        saveFile.Close();

        List<RacerData> racerDatabase = new() { playerSave, enemy1Save, enemy2Save, enemy3Save };
    }
    public static void DeleteSave()
    {
        if (saveSlot == 1) File.Delete(Application.persistentDataPath + "/save01.dat");
        if (saveSlot == 2) File.Delete(Application.persistentDataPath + "/save02.dat");
        if (saveSlot == 3) File.Delete(Application.persistentDataPath + "/save03.dat");

        ScreenManager.UpdateSaveSlots();
    }
    public static void SaveGame()
    {
        FileStream saveFile = null;

        if (saveSlot == 1) saveFile = File.Open(Application.persistentDataPath + "/save01.dat", FileMode.Open);
        if (saveSlot == 2) saveFile = File.Open(Application.persistentDataPath + "/save02.dat", FileMode.Open);
        if (saveSlot == 3) saveFile = File.Open(Application.persistentDataPath + "/save03.dat", FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();

        SaveData saveData = new SaveData();

        saveData.playerData = new RacerData();

        saveData.playerData = playerSave;
        saveData.enemy1Data = enemy1Save;
        saveData.enemy2Data = enemy2Save;
        saveData.enemy3Data = enemy3Save;

        bf.Serialize(saveFile, saveData);
        saveFile.Close();
    }

    public static void LoadGame()
    {
        FileStream loadFile = null;

        if (saveSlot == 1) loadFile = File.Open(Application.persistentDataPath + "/save01.dat", FileMode.Open);
        if (saveSlot == 2) loadFile = File.Open(Application.persistentDataPath + "/save02.dat", FileMode.Open);
        if (saveSlot == 3) loadFile = File.Open(Application.persistentDataPath + "/save03.dat", FileMode.Open);

        BinaryFormatter bf = new BinaryFormatter();
        SaveData loadData = (SaveData)bf.Deserialize(loadFile);

        playerSave = loadData.playerData;
        enemy1Save = loadData.enemy1Data;
        enemy2Save = loadData.enemy2Data;
        enemy3Save = loadData.enemy3Data;

        enemySaves = new[] { enemy1Save, enemy2Save, enemy3Save };

        loadFile.Close();
    }

    public static void SubmitNewPlayer()
    {
        ScreenManager.Colors.Remove(ScreenManager.PlayerExampleColor.color);

        NewSave();

        PlayerSave.money = 0;
        string rgba = ScreenManager.PlayerExampleColor.color.r.ToString() + "," + ScreenManager.PlayerExampleColor.color.g.ToString() + "," + ScreenManager.PlayerExampleColor.color.b.ToString() + "," + ScreenManager.PlayerExampleColor.color.a.ToString();
        PlayerSave.racerColor = rgba;
        PlayerSave.racerName = ScreenManager.PlayerExampleName.text;

        PlayerSave.gameLevel = 0;

        SaveGame();

    }
}



[Serializable]
public class RacerData
{
    public int money;
    public string racerColor;
    public string racerName;
    public int gameLevel;

    public int racerType;

    public int engineUpgradeLevel;
    public int armourUpgradeLevel;
    public int boostSpeedLevel;
    public int boostCooldownLevel;
    public int boostRechargeLevel;
    public int repairSkill;
    public int speechSkill;
    public int charmSkill;
    public int bulletClipLevel;
    public int missleClipLevel;
    public int mineClipLevel;
    public int bulletCooldownLevel;
    public int missleCooldownLevel;
    public int mineCooldownLevel;

    public int bulletAmmo;
    public int missleAmmo;
    public int mineAmmo;
}

[Serializable]
public class SaveData
{
    public RacerData playerData;
    public RacerData enemy1Data;
    public RacerData enemy2Data;
    public RacerData enemy3Data;
}
