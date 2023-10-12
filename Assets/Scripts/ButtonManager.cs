using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool saveDataExists = false; // this will be held by GameManager likely in the future
    public void PlayButton()
    {
        if(saveDataExists) ScreenManager.SetScreen(ScreenManager.Screen.loadSave);
        else ScreenManager.SetScreen(ScreenManager.Screen.instructions);
    }
}
