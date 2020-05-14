using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehavior : MonoBehaviour
{
    public static float cooldown = 1f;
    public static float cooldownTimer = 0;
    public bool infected = false;


    public float infectionTime = 100;


    public MainController mainController;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mainController != null);

        if (infected)
        {
            Infect();
        }
        else
        {
            Disinfect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (infected)
        {
            SpawnVirus();
            cooldownTimer = cooldown;
        }
    }

    private void SpawnVirus()
    {
        //GameObject enemy = Instantiate(enemyToSpawn) as GameObject;
        //enemy.transform.position = transform.position;

        mainController.SpawnVirus(transform);
    }

    public void Infect()
    {
        GetComponent<Renderer>().material.color = Color.white;
        infected = true;
    }

    public void Disinfect()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        infected = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Disinfect();
        }
        else if (collision.gameObject.CompareTag("Virus"))
        {
            Infect();
        }
    }

    public bool IsInfected()
    {
        return infected;
    }
}
