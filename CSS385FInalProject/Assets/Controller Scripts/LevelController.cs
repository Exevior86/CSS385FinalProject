using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int killCount = 50;
    public static int currentLevel = 0;

    private MainController mainController = null;

    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        UpdateKillAmount();
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

    private void UpdateKillAmount()
    {
        killCount = killCount + 50 + (50 * currentLevel);
    }
}
