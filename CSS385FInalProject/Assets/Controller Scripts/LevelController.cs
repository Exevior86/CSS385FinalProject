using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static bool survival;
    public static bool lastLevel;
    public static int killCount = 75;
    public static int currentLevel = 1;
    public static int difficulty = 1;
    public GameObject slider;

    private MainController mainController = null;

    // Start is called before the first frame update
    void Start()
    {
        killCount = killCount + (75 * currentLevel * difficulty);
        GameObject temp = GameObject.Find("GameManager");
        mainController = temp?.GetComponent<MainController>();
        currentLevel = UIScript.level;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript.VirusKilled >= killCount)
        {
            mainController.SignalWin();
            UpdateKillAmount();
        }
    }

    static void UpdateKillAmount()
    {
        killCount = killCount + (50 * currentLevel * difficulty);
    }

    public void ChangeDifficulty(int value)
    {
        difficulty = value;
    }
}
