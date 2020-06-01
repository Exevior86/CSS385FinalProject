using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int killCount = 50;
    public static int currentLevel = 0;

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
            SoundManagerScript.PlaySound("WinningSound");
            Cursor.visible = true;
            UIScript.level++;
            SceneManager.LoadScene("Scenes/UI/WinUI");
            UpdateKillAmount();
        }
    }

    private void UpdateKillAmount()
    {
        killCount = killCount + 50 + (50 * currentLevel);
    }
}
