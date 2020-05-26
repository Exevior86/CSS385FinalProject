﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public static int lives = 10;
    public static float scoreTime;
    private float percentageSubtract = 1f / 10f;
    private float energyPercent = 1f / 100f;
    private float startTime;

    public Image bar;
    public Image energyBar;
    public Text score;
    public Text enemies;
    public Text Bombs;
    public Text killsNeeded;

    void Update()
    {
        scoreTime = Time.time - startTime;
        score.text = "Score: " + scoreTime;
        enemies.text = "Virus Defeated: " + ScoreScript.VirusKilled;
        Bombs.text = "Bombs: " + Shoot.bombs;
        killsNeeded.text = "Kills Needed: " + LevelController.killCount;

        FillEnergyBar();
        FillLives();
    }

    void Start()
    {
        startTime = Time.time;
        ClearStats();
    }

    public void LowerLives()
    {
        if (lives <= 1)
        {
            SceneManager.LoadScene("Scenes/UI/DefeatUI");
        }
        else
        {
            lives--;
        }
    }

    public void FillEnergyBar()
    {
        energyBar.fillAmount = Movement.sprintEnergy * energyPercent;
    }

    public void FillLives()
    {
        bar.fillAmount = lives * percentageSubtract;
    }

    private void ClearStats()
    {
        ScoreScript.VirusKilled = 0;
        ScoreScript.CellsCured = 0;
    }
}
