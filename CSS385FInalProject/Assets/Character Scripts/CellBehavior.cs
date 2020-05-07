using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehavior : MonoBehaviour
{
    public static float cooldown = 1f;
    public static float cooldownTimer = 0;
    public GameObject enemyToSpawn;
    public bool infected = true;


    public float infectionTime = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (cooldownTimer <= 0 && infected)
        {
            Debug.Log("Been doing it mang");
            SpawnVirus();
            cooldownTimer = cooldown;
        }       
    }

    private void SpawnVirus()
    {
        GameObject enemy = Instantiate(enemyToSpawn) as GameObject;
        enemy.transform.position = transform.position;
    }
}
