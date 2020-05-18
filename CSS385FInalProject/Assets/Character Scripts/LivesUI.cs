﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public int lives = 5;
    public Image bar;
    public Text score;
    public static float scoreTime;
    private float percentageSubtract = 1f / 5f;
    private float startTime;

    void Update()
    {
        scoreTime = Time.time - startTime;
        score.text = "Score: " + scoreTime;
    }

    void Start()
    {
        startTime = Time.time;
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
            bar.fillAmount = lives * percentageSubtract;
        }
    }
}
