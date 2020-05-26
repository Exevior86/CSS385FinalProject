using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    int level = LevelController.currentLevel;
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
        SceneManager.LoadScene("Scenes/levelTest");
    }

    public void GotoIntro()
    {
        SceneManager.LoadScene("Scenes/UI/Intro UI");
    }

    public void ChangeLevel()
    {
        switch (level)
        {
            case 1:
                LevelController.currentLevel++;
                Debug.Log("Level = " + level);
                SceneManager.LoadScene("Scenes/Level2A");
                break;
            case 2:
                LevelController.currentLevel++;
                Debug.Log("Level = " + level);
                SceneManager.LoadScene("Scenes/Level3A");
                break;
            default:
                LevelController.currentLevel = 1;
                SceneManager.LoadScene("Scenes/UI/Intro UI");
                break;
        }
      
    }
}