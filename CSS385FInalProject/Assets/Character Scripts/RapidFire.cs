using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    private int cooldown = 8;
    private float modifier;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Shoot.rapidFire || Shoot.wideShot) ;
            else
            {
                modifier = Shoot.cooldown * .5f;
                Shoot.cooldown = Shoot.cooldown - modifier;
                Shoot.rapidFire = true;
                SoundManagerScript.PlaySound("PowerUpSound");
                Shoot.powerUpCdTimer += cooldown;
                //SpawnPowerup();
                Destroy(this.gameObject);
            }
        }
    }

    public void SpawnPowerup()
    {
        PowerupManager.Spawn("Prefabs/RapidFire", transform.position);
    }
}
