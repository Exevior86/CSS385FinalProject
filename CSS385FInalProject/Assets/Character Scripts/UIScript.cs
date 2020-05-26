using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UIScript : MonoBehaviour
{

    [SerializeField]
    private string nextLevel = "";

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

    public void GotoNextLevel()
    {
        Debug.Assert(nextLevel != "");
        SceneManager.LoadScene(nextLevel);
    }
}