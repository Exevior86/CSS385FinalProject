using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    public Text cellsText;

    void Start()
    {
        scoreText.text = "Time: " + Mathf.Round(LivesUI.scoreTime);
        timeText.text = "Virus Destroyed: " + ScoreScript.VirusKilled;
        cellsText.text = "Cells Cured: " + ScoreScript.CellsCured;
    }   
}
