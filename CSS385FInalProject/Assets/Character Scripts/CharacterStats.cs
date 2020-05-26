using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static int enemiesDestroyed = 0;
    public static int health = 5;
    public static int score = 0;

    private MainController mainController = null;


    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        Debug.Assert(mainController != null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            Debug.Log("Player Health = " + health);
            mainController.LowerLives();
        }
    }

}
