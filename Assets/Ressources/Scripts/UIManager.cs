using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject StartMenu;
    public GameObject PlayUI;
    public GameObject GameOverMenu;

    private void Start()
    {
        StartMenu.SetActive(true);
        PlayUI.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.isGameOver)
        {
            PlayUI.SetActive(false);
            GameOverMenu.SetActive(true);
        }
        if (GameManager.isGameStart && !GameManager.isGameOver)
        {
            StartMenu.SetActive(false);
            PlayUI.SetActive(true);
        }
    }


}
