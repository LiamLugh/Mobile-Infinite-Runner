﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    Player player = null;
    [SerializeField]
    ColourSensor colourSensor = null;
    [SerializeField]
    MapController mapSystem = null;
    [SerializeField]
    AudioSystem audioSystem = null;

    [Header("State")]
    [SerializeField]
    bool toggle = true;

    [Header("UI")]
    [SerializeField]
    Image pauseScreen = null;
    [SerializeField]
    Image gameOverScreen = null;

    // Events
    void Start()
    {
        player.gameOverEventHandler += OnGameOverEvent;
    }

    private void OnGameOverEvent(EventArgs e)
    {
        EndGamePause();
    }

    void EndGamePause()
    {
        player.Pause();
        mapSystem.Pause();
        colourSensor.Pause();
        gameOverScreen.gameObject.SetActive(true);
    }

    public void PauseToggle()
    {
        if(toggle)
        {
            PauseGame();
            pauseScreen.gameObject.SetActive(true);
        }
        else
        {
            UnpauseGame();
            pauseScreen.gameObject.SetActive(false);
        }

        toggle = !toggle;
    }

    void PauseGame()
    {
        audioSystem.PlayPauseSFX();
        player.Pause();
        mapSystem.Pause();
        colourSensor.Pause();
    }

    void UnpauseGame()
    {
        audioSystem.PlayUnpauseSFX();
        player.Unpause();
        mapSystem.Unpause();
        colourSensor.Unpause();
    }

    void GameOverPause()
    {
        audioSystem.PlayGameOverSFX();
        player.Pause();
        mapSystem.Pause();
    }
}
