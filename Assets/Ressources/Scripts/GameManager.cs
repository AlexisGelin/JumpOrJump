using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static bool isGameStart = false;

    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("die");
        }
    }
    public static void GameOver()
    {

        isGameOver = true;
        Debug.Log("End");
        //Show UI FIN
    }
}
