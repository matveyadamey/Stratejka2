using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private static GameObject _winScreen;

    public static void SetWinScreen(GameObject winScreen)
    {
        _winScreen = winScreen;
    }
    
    public static void ShowWinScreen()
    {
        print("Win");
        //Instantiate(_winScreen);
        //Time.timeScale = 0;
    }
}
