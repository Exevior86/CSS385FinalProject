using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static int level = LevelController.currentLevel;

    public void GotoSettings()
    {
        SceneManager.LoadScene("Scenes/UI/Settings");
    }

    public void GotoHighscores()
    {
        SceneManager.LoadScene("Scenes/UI/Highscores");
    }

    public void GotoGame()
    {
        ResetCharacter();
        SceneManager.LoadScene("Scenes/Level1A");
    }

    public void GotoIntro()
    {
        level = 0;
        SceneManager.LoadScene("Scenes/UI/Intro UI");
    }

    public void ChangeLevel()
    {
        ResetCharacter();
        Cursor.visible = false;
        switch (level)
        {
            case 0:
                SceneManager.LoadScene("Scenes/Level1A");
                break;
            case 1:
                SceneManager.LoadScene("Scenes/Level2A");       
                break;
            case 2:
                SceneManager.LoadScene("Scenes/Level3A");
                break;
            case 3:
                SceneManager.LoadScene("Scenes/Hunt");
                break;
            default:
                LevelController.currentLevel = 1;
                Cursor.visible = true;
                GotoIntro();
                break;
        }
      
    }

    public void ResetCharacter()
    {
        LivesUI.lives = 10;
        ScoreScript.CellsCured = 0;
        ScoreScript.VirusKilled = 0;
        Shoot.bombs = 3;
        Shoot.wideShot = false;
        Shoot.rapidFire = false;
        Movement.sprintEnergy = 100;

    }
}