using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFire : MonoBehaviour
{
    private int cooldown = 5;
    private float modifier;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            modifier = Shoot.cooldown * .5f;
            Shoot.cooldown = Shoot.cooldown - modifier;
            Shoot.rapidFire = true;
            Shoot.powerUpCdTimer += cooldown;
            Destroy(this.gameObject);
        }
    }
}
