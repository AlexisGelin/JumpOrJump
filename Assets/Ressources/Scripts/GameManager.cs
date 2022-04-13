using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStart = false;
    public static float mainVolume = 1;
    public static int money;
    public static string skin = "Biker";

    private void Start()
    {
        PlayerPrefs.SetInt("skinPunk", 0);
        PlayerPrefs.SetInt("skinCyborg", 0);
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public static void GameOver()
    {
        isGameOver = true;
    }
}
