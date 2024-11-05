using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using World;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    
    public GameObject tutorialScreen, gameOverScreen, gameWonScreen;

    [Header("Checks")] 
    private bool _tutorialOpen;
    
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EndGame.OnGameWin += HandleGameWin;
    }

    private void OnDisable()
    {
        EndGame.OnGameWin -= HandleGameWin;
    }

    private void Start()
    {
        Time.timeScale = 1;
        _tutorialOpen = true;
        tutorialScreen.SetActive(_tutorialOpen);
        gameOverScreen.SetActive(false);
        gameWonScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HandleTutorial();
        }
    }

    private void HandleGameWin()
    {
        Time.timeScale = 0;
        gameWonScreen.SetActive(true);
    }
    
    /// <summary>
    /// Show or Hide the tutorial screen
    /// </summary>
    public void HandleTutorial()
    {
        _tutorialOpen = !_tutorialOpen;
        tutorialScreen.SetActive(_tutorialOpen);
    }
    
    /// <summary>
    /// Display the game over screen
    /// </summary>
    public void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
    
    /// <summary>
    /// Restart The Game
    /// </summary>
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
