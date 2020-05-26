using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int killCount = 100;
    public static int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        UpdateKillAmount();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript.VirusKilled >= killCount)
        {
            SceneManager.LoadScene("Scenes/UI/WinUI");
            Cursor.visible = true;
            UpdateKillAmount();
        }
    }

    private void UpdateKillAmount()
    {
        killCount = killCount + (50 * currentLevel);
    }
}
