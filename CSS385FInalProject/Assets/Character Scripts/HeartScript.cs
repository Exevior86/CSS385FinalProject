using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (CharacterStats.health >= 5)
                ;
            else
            {
                CharacterStats.health += 5;
                SoundManagerScript.PlaySound("HealthUp");
                Destroy(this.gameObject);
            }
        }
    }
}
