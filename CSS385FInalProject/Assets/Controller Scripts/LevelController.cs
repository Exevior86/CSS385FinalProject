using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int killCount = 50;
    public int currentLevel = 1;
    public static int difficulty = 1;
    public GameObject slider;

    private MainController mainController = null;

    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        UpdateKillAmount();
        Debug.Log("Difficulty = ");
        currentLevel = UIScript.level;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript.VirusKilled >= killCount)
        {
            //SoundManagerScript.PlaySound("WinningSound");
            //Cursor.visible = true;
            //UIScript.level++;
            //currentLevel++;
            //SceneManager.LoadScene("Scenes/UI/WinUI");

            mainController.SignalWin();
            UpdateKillAmount();
        }
    }

    private void UpdateKillAmount()
    {
        killCount = killCount + (25 * currentLevel * difficulty);
    }

    public void ChangeDifficulty(int value)
    {
        difficulty = value;
    }
}
