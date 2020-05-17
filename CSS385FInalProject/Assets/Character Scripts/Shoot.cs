using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   // public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject crosshairs;
    public float bulletSpeed = 15.0f;

    public static float cooldown = .1f;
    public static float cooldownTimer = 0;
    public static float powerUpCdTimer = 0;

    public static int damage = 1;
    private Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        difference.Normalize();
        if (powerUpCdTimer > 0)
        {
            powerUpCdTimer -= Time.deltaTime;
        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0))
        {
            if (cooldownTimer <= 0)
            {
                if (powerUpCdTimer > 0)
                {
                    fireWide(difference, rotationZ);
                }
                else
                {
                    fireBullet(difference, rotationZ);
                }
                cooldownTimer = cooldown;
            }
           
        }
    }

    void fireBullet(Vector3 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = transform.position;
        b.transform.up = direction;
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(b.gameObject, 2);
    }

    void fireWide(Vector3 direction, float rotationZ)
    {
        GameObject a = Instantiate(bulletPrefab) as GameObject;
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        GameObject c = Instantiate(bulletPrefab) as GameObject;
        Vector3 eulerAngles;
        Vector3 newForce = direction * bulletSpeed;
        eulerAngles.x = 0;
        eulerAngles.y = 0;

        // Shoot forward
        a.transform.position = transform.position;
        a.transform.up = direction;
        a.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        Destroy(a.gameObject, 2);

        // Shoot left of mouse 15 degrees
        b.transform.position = transform.position;
        b.transform.up = direction;
        eulerAngles.z = 15;
        newForce = Quaternion.Euler(eulerAngles) * newForce;
        b.GetComponent<Rigidbody2D>().AddForce(newForce, ForceMode2D.Impulse);
        Destroy(b.gameObject, 2);


        // Shoot right of the mouse 15 degrees
        c.transform.position = transform.position;
        c.transform.up = direction;
        eulerAngles.z = -30;
        newForce = Quaternion.Euler(eulerAngles) * newForce;
        c.GetComponent<Rigidbody2D>().AddForce(newForce, ForceMode2D.Impulse);
        Destroy(c.gameObject, 2);
    }

    void rapidFire(Vector3 direction, float rotationZ)
    {
        
    }
}
