using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (LivesUI.lives >= 10)
                ;
            else
            {
                LivesUI.lives += 5;
                SoundManagerScript.PlaySound("HealthUp");
                Destroy(this.gameObject);
            }
        }
    }
}
