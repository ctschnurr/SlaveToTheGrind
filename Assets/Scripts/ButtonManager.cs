using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public static AudioSource buttonClick;

    private void Start()
    {
        buttonClick = GetComponent<AudioSource>();
    }
    public static void ButtonClick()
    {
        buttonClick.Play();
    }
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
        DataManager.SubmitNewPlayer();
        SwitchToGameplay();
    }

    public void ContinueGame()
    {
        GameManager.GameLoaded = true;
        DataManager.LoadGame();

        GameManager.GameLevel = DataManager.PlayerSave.gameLevel;

        SwitchToGameplay();
    }

    public void ShowControlsScreen()
    {
        ScreenManager.SetScreen(ScreenManager.Screen.controls);
    }

    public void ShowRaceStartScreen()
    {
        if(GameManager.GameLevel < 4)
        {
            RaceManager.ResetRace();
            ScreenManager.SetScreen(ScreenManager.Screen.raceStart);
        }
        else ScreenManager.SetScreen(ScreenManager.Screen.storyEnd);
    }

    public void CheckGameEnd()
    {
        if (GameManager.GameLevel < 4)
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
        Debug.Log(RaceManager.PlayerPlace);

        if (RaceManager.PlayerPlace == 0)
        {
            GameManager.GameLevel++;
            Debug.Log(GameManager.GameLevel);
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
        ScreenManager.FadeToGameplay();
    }

    public void QuitToTitle()
    {
        RaceManager.EndRace();
        RaceManager.ResetRace();
        ScreenManager.ClearScreens();
        ScreenManager.FadeToTitle();
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
