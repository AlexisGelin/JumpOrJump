using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStart = false;
    public static float mainVolume = 1;
    public static int money;
    public static string skin = "Biker";

    public static bool isConnectedToGooglePlay;

    private void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        PlayerPrefs.SetInt("skinPunk", 0);
        PlayerPrefs.SetInt("skinCyborg", 0);
        Screen.orientation = ScreenOrientation.Portrait;

        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            isConnectedToGooglePlay = true;
        }
        else
        {
            isConnectedToGooglePlay = false;
        }
    }
    public static void GameOver()
    {
        isGameOver = true;
        

    }
    
}
