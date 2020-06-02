using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public static int lives = 5;
    public static float scoreTime;
    private float percentageSubtract = 1f / 10f;
    private float energyPercent = 1f / 100f;
    private float startTime;

    public Image shieldEnergy;
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
        FillShield();
    }

    void Start()
    {
        startTime = Time.time;
    }

    public void LowerLives()
    {
        if (lives <= 1)
        {
            SoundManagerScript.PlaySound("Death");
            Cursor.visible = true;
            SceneManager.LoadScene("Scenes/UI/DefeatUI");
        }
        else
        {
            SoundManagerScript.PlaySound("TakeDamage");
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
        shieldEnergy.fillAmount = Shoot.shield * percentageSubtract;
    }
}
