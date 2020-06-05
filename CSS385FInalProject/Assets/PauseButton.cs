using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }
    public void Pause()
    {
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
