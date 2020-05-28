﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKiller : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
