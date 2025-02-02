﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public static bool survival;
    public static bool lastLevel;
    public static int killCount = 100;
    public static int currentLevel = 1;
    public static int difficulty = 2;
    public Slider Slider;
    private MainController mainController = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.Find("GameManager");
        mainController = temp?.GetComponent<MainController>();
        currentLevel = UIScript.level;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript.VirusKilled >= killCount)
        {
            mainController.SignalWin();
            UpdateKillAmount();
        }
    }

    static void UpdateKillAmount()
    {
        killCount += (75 * currentLevel * (int)difficulty);
    }

    public void ChangeValue()
    {
        difficulty = (int)Slider.value;
    }
    
}
