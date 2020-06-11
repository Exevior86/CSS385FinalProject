using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public float timer = 20f;
    public GameObject player;
    private static Vector2 topRight;
    private static string newpowerup;
    private static Vector3 newpos;
    private static PowerupManager instance;
    private int currentKills;
    private bool spawned = false;
    public int killsPerSpawn = 50;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (currentKills != ScoreScript.VirusKilled)
        {
            currentKills = ScoreScript.VirusKilled;
            if (ScoreScript.VirusKilled % killsPerSpawn == 0)
            {
                SpawnCheck();
            }
        }
    }

    void SpawnCheck()
    {
        //int wide = 1;
        //int rapid = 1;
        //int heart = 1;
        //int shield = 1;

        //if (!LevelController.survival)
        //{
        //    wide = (ScoreScript.VirusKilled + 1) % 75;
        //    rapid = (ScoreScript.VirusKilled + 1) % 75;
        //    heart = (ScoreScript.VirusKilled + 1) % 75;
        //    shield = (ScoreScript.VirusKilled + 1) % 75;
        //}
        //if (LevelController.survival)
        //{
        //    wide = (ScoreScript.VirusKilled + 1) % 76;
        //    rapid = (ScoreScript.VirusKilled + 1) % 76;
        //    heart = (ScoreScript.VirusKilled + 1) % 76;
        //    shield = (ScoreScript.VirusKilled + 1) % 76;
        //}

        //newpos = player.transform.position;
        //if (wide == 0)
        //{
        //    newpowerup = "Prefabs/powerupWide";
        //    SpawnReal();
        //}
        //if (rapid == 0)
        //{
        //    newpowerup = "Prefabs/RapidFire";
        //    SpawnReal();
        //}
        //if (heart == 0)
        //{
        //    newpowerup = "Prefabs/Health";
        //    SpawnReal();
        //}
        //if (shield == 0)
        //{
        //    newpowerup = "Prefabs/Shield";
        //    SpawnReal();
        //}

        int randVal = Mathf.RoundToInt(Random.Range(0, 4));


        if (randVal == 0)
        {
            newpowerup = "Prefabs/powerupWide";
        }
        else if (randVal == 1)
        {
            newpowerup = "Prefabs/RapidFire";
        }
        else if (randVal == 2)
        {
            newpowerup = "Prefabs/Health";
        }
        else if (randVal == 3)
        {
            newpowerup = "Prefabs/Shield";
        }

        SpawnReal();

    }

    public static void Spawn(string powerup, Vector3 pos)
    {
        newpowerup = powerup;
        newpos = pos;
        instance.Invoke("SpawnReal", instance.timer);
    }

    public void SpawnReal()
    {
        Vector2 powerUpPosition = player.transform.position + ((Vector3)Random.insideUnitCircle * 10);
        Object loaded = Resources.Load(newpowerup);
        Instantiate(loaded, powerUpPosition, Quaternion.identity);
    }
}
