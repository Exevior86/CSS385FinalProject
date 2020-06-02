using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Shoot.shield = 3;
            Destroy(this.gameObject);
            SoundManagerScript.PlaySound("PowerUpSound");
        }
    }
}
