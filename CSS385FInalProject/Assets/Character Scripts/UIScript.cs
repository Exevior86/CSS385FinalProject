using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void GotoSettings()
    {
        SceneManager.LoadScene("Scenes/Settings");
    }

    public void GotoHighscores()
    {
        SceneManager.LoadScene("Scenes/Highscores");
    }

    public void GotoGame()
    {
        SceneManager.LoadScene("Scenes/Prototype test");
    }

    public void GotoIntro()
    {
        SceneManager.LoadScene("Scenes/Intro UI");
    }
}