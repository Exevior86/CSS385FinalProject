using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideShotPower : MonoBehaviour
{
    public float cooldown = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Shoot.powerUpCdTimer = cooldown;
            Debug.Log("Set shoot.powerupCD to " + Shoot.powerUpCdTimer);
            Destroy(this.gameObject);
        }
    }
}
