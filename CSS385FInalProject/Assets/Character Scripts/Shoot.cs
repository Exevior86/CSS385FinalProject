using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   // public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 15.0f;

    public static float cooldown = .2f;
    public static float cooldownTimer = 0;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
     //   crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        difference.Normalize();

        if (Input.GetMouseButton(0))
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (cooldownTimer <= 0)
            {
                fireBullet(difference, rotationZ);
                cooldownTimer = cooldown;
            }
           
        }
    }

    void fireBullet(Vector3 direction, float rotationZ)
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = transform.position;
        b.transform.eulerAngles = new Vector3(0f, 0f, direction.z);
        b.GetComponent<Rigidbody2D>().AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
        Destroy(b.gameObject, 2);
    }

}
