using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneShoot : MonoBehaviour
{
    // public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;

    private float bulletSpeed = 25.0f;


    public float cooldownTimer = 0;



    public static int shield = 0;
    public static int damage = 1;
    private Vector3 target;

    private MainController mainController = null;

    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        Debug.Assert(mainController != null);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        target = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = target - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        difference.Normalize();
        if (!PauseButton.GamePaused)
        {

            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                if (cooldownTimer <= 0)
                {
                    if (Shoot.wideShot && Shoot.powerUpCdTimer > 0)
                    {
                        fireWide(difference, rotationZ);
                    }
                    if (Shoot.rapidFire && Shoot.powerUpCdTimer > 0)
                    {
                        bulletSpeed = 35;
                        fireBullet(difference, rotationZ);
                    }
                    if (Shoot.powerUpCdTimer <= 0)
                    {
                        fireBullet(difference, rotationZ);
                    }

                    cooldownTimer = Shoot.cooldown;
                }
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

    public float radius = 10f;

   

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Virus") && collision.gameObject.GetComponent<VirusBehavior>().isDamaging())
    //    {
    //        mainController.PlayHitEffects();
    //        if (shield > 0)
    //        {
    //            SoundManagerScript.PlaySound("TakeDamage");
    //            shield--;
    //        }
    //        else
    //        {
    //            mainController.LowerLives();
    //            mainController.PlayDamageEffects();
    //        }
    //    }
    //}
}
