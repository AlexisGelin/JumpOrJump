using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStart = false;
    public static float money = 0;

    private void Update()
    {

    }
    public static void GameOver()
    {
        isGameOver = true;
    }
}
