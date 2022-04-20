using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UIManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject PlayUI;
    public GameObject GameOverMenu;

    public GameObject SettingsMenu;
    public GameObject PauseMenu;

    public GameObject moneyGO;

    public TextMeshProUGUI moneyText;

    private void Start()
    {
        StartMenu.SetActive(true);
        PlayUI.SetActive(false);
        GameOverMenu.SetActive(false);
        moneyGO.SetActive(true);
        GameManager.money = PlayerPrefs.GetInt("Money");

    }

    private void Update()
    {
        if (GameManager.isGameOver)
        {
            PlayUI.SetActive(false);
            GameOverMenu.SetActive(true);
            moneyGO.SetActive(false);
        } 
        if (GameManager.isGameStart && GameManager.isGameOver == false)
        {
            StartMenu.SetActive(false);
            GameOverMenu.SetActive(false);
            PlayUI.SetActive(true);
            moneyGO.SetActive(true);
        }
        moneyText.text = GameManager.money.ToString();
    }

    public void SetActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void SetUnactive(GameObject obj)
    {
        obj.SetActive(false);
    }


    public void OpenPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        PauseMenu.SetActive(false );
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        GameManager.GameOver();
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowLeaderboards()
    {
        Social.ShowLeaderboardUI();
    }


}
