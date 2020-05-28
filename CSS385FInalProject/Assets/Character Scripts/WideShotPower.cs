using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideShotPower : MonoBehaviour
{
    public float cooldown = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Shoot.wideShot || Shoot.rapidFire)
                ;
            else
            {
                Shoot.wideShot = true;
                Shoot.powerUpCdTimer += cooldown;
                SoundManagerScript.PlaySound("PowerUpSound");
                SpawnPowerup();
                Destroy(this.gameObject);
            }
        }
    }

    public void SpawnPowerup()
    {
        PowerupManager.Spawn("Prefabs/powerupWide", transform.position);
    }
}
