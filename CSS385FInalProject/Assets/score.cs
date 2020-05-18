using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        Debug.Log(LivesUI.scoreTime);
        scoreText.text = "Score: " + LivesUI.scoreTime;
    }   
}
