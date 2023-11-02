using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static void DeactivateDeleteSavePanel(bool confirmed)
    {
        if (confirmed) DataManager.DeleteSave();
        ScreenManager.ConfirmDelete.SetActive(false);
    }

    public static void NewGame()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.customizePlayer);
    }

    public void BackButton()
    {
        ScreenManager.SetScreen(ScreenManager.LastScreen);
    }
    public void SubmitNewPlayer()
    {
        ScreenManager.Colors.Remove(ScreenManager.PlayerExampleColor.color);

        DataManager.NewSave();

        DataManager.PlayerData.money = 0;
        DataManager.PlayerData.racerColor = ScreenManager.PlayerExampleColor.color.ToString();
        DataManager.PlayerData.racerName = ScreenManager.PlayerExampleName.text;
        DataManager.PlayerData.gameLevel = 0;;

        DataManager.SaveGame();

        SwitchToGameplay();
    }

    public void GoToInstructions()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.instructions);
    }

    public void GoToChooseSaveSlot()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.saveSlot);
    }
    public void GoToEarnings()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.earnings);
    }

    public void GoToUpgrades()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.upgrades);
    }

    public void GoToCustomizePlayer()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.customizePlayer);
    }

    public void CustomizePlayerName()
    {
        ScreenManager.PlayerExampleName.text = ScreenManager.PlayerNameInput.text;
    }

    public void SwitchToGameplay()
    {
        ScreenManager.ClearScreens();
        SceneManager.LoadScene(1);
    }
    public void StartRace()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.HUD);
        RaceManager.StartRace();
    }

    public void Restart()
    {
        RaceManager.ResetRace();
        ScreenManager.SetScreen(ScreenManager.Screen.instructions);
        Time.timeScale = 1;
    }

    public static void Pause()
    {
        if (!GameManager.Paused)
        {
            Time.timeScale = 0;
            ScreenManager.SetScreen(ScreenManager.Screen.pause);
            GameManager.Paused = true;
        }
        else if (GameManager.Paused)
        {
            Time.timeScale = 1;
            ScreenManager.SetScreen(ScreenManager.Screen.HUD);
            GameManager.Paused = false;
        }
    }

    public void ShowUpgrades()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.upgrades);
    }

    public void SetSaveSlot(int slotNumber)
    {
        DataManager.SaveSlot = slotNumber;
    }
    public void ChooseSaveToDelete(int slotNumber)
    {
        DataManager.SaveSlot = slotNumber;
        ScreenManager.ActivateDeleteSavePanel();
    }

    public void CustomizePlayerColor(int choice)
    {
        switch (choice)
        {
            case 1:
                ScreenManager.PlayerExampleColor.color = Color.green;
                break;

            case 2:
                ScreenManager.PlayerExampleColor.color = Color.red;
                break;

            case 3:
                ScreenManager.PlayerExampleColor.color = Color.blue;
                break;

            case 4:
                ScreenManager.PlayerExampleColor.color = Color.yellow;
                break;
        }
    }
}
