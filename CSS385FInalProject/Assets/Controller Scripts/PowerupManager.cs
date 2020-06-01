using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public float timer = 10f;
    public GameObject player;
    private static Vector2 screenBounds;
    private static string newpowerup;
    private static Vector3 newpos;
    private static PowerupManager instance;
    private float currentTime;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        //Determine how much are wanted
        //determine time intervals to create
        //currentTime = Time.deltaTime;
        int wide = (ScoreScript.VirusKilled + 1) % 7;
        int rapid = (ScoreScript.VirusKilled + 1) % 11;
        int heart = (ScoreScript.VirusKilled + 1) % 13;
        newpos = player.transform.position;
        if (wide == 0)
        {
            newpowerup = "Prefabs/RapidFire";
            SpawnReal();
        }
        else if (rapid == 0)
        {
            newpowerup = "Prefabs/powerupWide";
            SpawnReal();
        }
        else if (heart == 0)
        {
            newpowerup = "Prefabs/Health";
            SpawnReal();
        }
    }

    public static void Spawn(string powerup, Vector3 pos)
    {
        newpowerup = powerup;
        newpos = pos;
        instance.Invoke("SpawnReal", instance.timer);
    }

    public void SpawnReal()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bool powerupSpawned = false;
        while (!powerupSpawned)
        {
            Vector3 powerupPosition = new Vector3(Random.Range(0, screenBounds.x), Random.Range(0, screenBounds.y), 0f);
            if ((powerupPosition - newpos).magnitude < 3)
            {
                continue;
            }
            else
            {
                Object loaded = Resources.Load(newpowerup);
                Instantiate(loaded, powerupPosition, Quaternion.identity);
                powerupSpawned = true;
            }
        }
    }
}
