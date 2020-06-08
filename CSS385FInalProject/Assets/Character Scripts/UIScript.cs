using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static int level = 1;

    private void Awake()
    {
        LevelController.difficulty = 1;
    }

    public void GotoSettings()
    {
        SceneManager.LoadScene("Scenes/UI/Settings");
    }

    public void GotoInstructions()
    {
        SceneManager.LoadScene("Scenes/UI/instructions");
    }

    public void GotoHighscores()
    {
        SceneManager.LoadScene("Scenes/UI/Highscores");
    }

    public void GotoGame()
    {
        LevelController.killCount = LevelController.difficulty * level *100;
        LevelController.survival = false;
        Debug.Log("Difficulty = " + LevelController.difficulty);
        Debug.Log("Killcount = " + LevelController.killCount);
        Cursor.visible = false;
        ResetCharacter();
        SceneManager.LoadScene("Scenes/Level1A");
    }

    public void GotoIntro()
    {
        LevelController.lastLevel = false;
        LevelController.survival = false;
        LevelController.killCount = 75;

        level = 1;
        SceneManager.LoadScene("Scenes/UI/Intro UI");
    }

    public void GotoSurvival()
    {
        LevelController.survival = true;
        ResetCharacter();
        level = 6;
        Cursor.visible = false;
        SceneManager.LoadScene("Scenes/LevelSurvival");
    }

    public void GotoWin()
    {
        SceneManager.LoadScene("Scenes/UI/WinUI");
    }

    public void GotoLevelComplete()
    {
        SceneManager.LoadScene("Scenes/UI/LevelComplete");
    }

    public void ChangeLevel()
    {
        ResetCharacter();
        Cursor.visible = false;
        switch (level)
        {
            case 1:
                SceneManager.LoadScene("Scenes/Level1A");
                break;
            case 2:
                SceneManager.LoadScene("Scenes/Level2A");       
                break;
            case 3: 
                SceneManager.LoadScene("Scenes/Level3A");
                break;
            case 4:
                SceneManager.LoadScene("Scenes/level4B");
                break;
            case 5:
                LevelController.lastLevel = true;
                SceneManager.LoadScene("Scenes/level5B");
                break;
            default:
                level = 1;
                Cursor.visible = true;
                GotoIntro();
                break;
        }
    }

    public void ResetCharacter()
    {
        LivesUI.lives = 5;
        ScoreScript.CellsCured = 0;
        ScoreScript.VirusKilled = 0;
        Shoot.bombs = 3;
        Shoot.bombCooldown = 0;
        Shoot.wideShot = false;
        Shoot.rapidFire = false;
        Movement.sprintEnergy = 100;
        Movement.mHeroSpeed = 10;
    }

    public void Quit()
    {
        Application.Quit();
    }
}