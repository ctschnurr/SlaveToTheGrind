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
        if (GameLoaded == true) GameLoaded = false;

        ScreenManager.Colors.Remove(ScreenManager.PlayerExampleColor.color);

        DataManager.NewSave();

        DataManager.PlayerSave.money = 0;
        string rgba = ScreenManager.PlayerExampleColor.color.r.ToString() + "," + ScreenManager.PlayerExampleColor.color.g.ToString() + "," + ScreenManager.PlayerExampleColor.color.b.ToString() + "," + ScreenManager.PlayerExampleColor.color.a.ToString();
        DataManager.PlayerSave.racerColor = rgba;
        DataManager.PlayerSave.racerName = ScreenManager.PlayerExampleName.text;

        DataManager.PlayerSave.gameLevel = 0;

        DataManager.SaveGame();

        SwitchToGameplay();
    }

    public void ContinueGame()
    {
        GameLoaded = true;
        DataManager.LoadGame();

        GameLevel = DataManager.PlayerSave.gameLevel;

        SwitchToGameplay();
    }

    public void ShowControlsScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.controls);
    }

    public void ShowRaceStartScreen()
    {
        if(GameLevel != 4)
        {
            RaceManager.ResetRace();
            ScreenManager.SetScreen(ScreenManager.Screen.raceStart);
        }
        else ScreenManager.SetScreen(ScreenManager.Screen.storyEnd);
    }

    public void CheckGameEnd()
    {
        if (GameLevel != 4)
        {
            ScreenManager.SetScreen(ScreenManager.Screen.shop);
        }
        else ScreenManager.SetScreen(ScreenManager.Screen.storyEnd);
    }

    public void GoToChooseSaveSlot()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.saveSlot);
    }
    public void GoToEarnings()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.earnings);
    }

    public void CheckCupWinner()
    {
        if (RaceManager.PlayerPlace == 0)
        {
            GameLevel++;
            ScreenManager.SetScreen(ScreenManager.Screen.cupWinner);
        }
        else ScreenManager.SetScreen(ScreenManager.Screen.shop);
    }

    public void ShowUpgradesScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.shop);
    }

    public void ShowArmouryScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.armoury);
    }

    public void ShowSchoolScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.school);
    }

    public void GoToCustomizePlayer()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.customizePlayer);
    }

    public void ShowStoryScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.story);
    }

    public void CustomizePlayerName()
    {
        if (ScreenManager.PlayerNameInput.text != "" && ScreenManager.PlayerNameInput.text != " ") ScreenManager.PlayerExampleName.text = ScreenManager.PlayerNameInput.text;
    }

    public void SwitchToGameplay()
    {
        ScreenManager.ClearScreens();
        SceneManager.LoadScene(1);
    }

    public void QuitToTitle()
    {
        ScreenManager.ClearScreens();
        SceneManager.LoadScene(0);
    }
    public void StartRace()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.HUD);
        RaceManager.StartRace();
    }

    public void Restart()
    {
        RaceManager.ResetRace();
        ScreenManager.SetScreen(ScreenManager.Screen.raceStart);
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

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void ShowOptions()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.options);

    }

    public void ShowTitleScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.title);
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

    public void NextRace()
    {
        ShowRaceStartScreen();
    }
}
