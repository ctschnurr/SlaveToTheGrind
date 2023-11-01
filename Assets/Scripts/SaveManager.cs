using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SaveManager : MonoBehaviour
{
    static int saveSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSaveInfo(int slotNum)
    {

    }

    public void SaveGame()
    {

        if(saveSlot == 1)
        {

        }
        switch (GameManager.saveSlot)
        {
            case 0:

                break;
            case 1:
                FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
                break;
                BinaryFormatter bf = new BinaryFormatter();
                PlayerData data = new PlayerData();
                data.health = health;
                data.experience = experience;
                data.score = score;
                data.gold = gold;
                data.potions = potions;
                data.kills = kills;
                data.saveSceneIndex = SceneManager.GetActiveScene().buildIndex;

                bf.Serialize(file, data);
                file.Close();
                break;

        }
    }
}

[Serializable]
class SaveData
{
    public Racer player;
}
