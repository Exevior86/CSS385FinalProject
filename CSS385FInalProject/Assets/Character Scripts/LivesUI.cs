using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public static int lives = 5;
    public static float scoreTime;
    private float percentageSubtract = 1f / 5f;
    private float energyPercent = 1f / 100f;
    private float startTime;

    private MainController mainController = null;

    public Image shieldEnergy;
    public Image bar;
    public Image energyBar;
    public Text score;
    public Text enemies;
    public Text Bombs;
    public Text killsNeeded;
    public Text bombCd;

    void Update()
    {
        scoreTime = Time.time - startTime;
        score.text = "Time: " + Mathf.Round(scoreTime);
        //enemies.text = "Virus Defeated: " + ScoreScript.VirusKilled;
        Bombs.text = "Count: " + Shoot.bombs;
        killsNeeded.text = "Kills Needed: " + ((int)LevelController.killCount - ScoreScript.VirusKilled);
        bombCd.text = Mathf.Round(Shoot.bombCooldown).ToString();

        FillEnergyBar();
        FillLives();
        FillShield();
    }

    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        startTime = Time.time;
    }

    public void LowerLives()
    {
        if (lives <= 1)
        {
            mainController.SignalDefeat();
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

    public void FillShield()
    {
        shieldEnergy.fillAmount = Shoot.shield * (1f/ 3f);
    }
}
