using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    public int health = 2;
    public float mProbabilityOfTargetingPlayer = 0.25f;
    public float mMovementSpeed = 0.5f;
    public MainController mMainController;
    public float secondsSinceLastMove = 0.0f;
    public float secondsUntilNextMove = 0.0f;

    private Transform mTarget;

    // Start is called before the first frame update
    void Start()
    {
        mMainController = GameObject.Find("GameManager").GetComponent<MainController>();
        Debug.Assert(mMainController != null);
        SelectTarget();
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastMove += Time.deltaTime;

        if (secondsSinceLastMove > secondsUntilNextMove)
        {
            transform.position += (mTarget.position - transform.position).normalized * mMovementSpeed * Time.deltaTime;
            Vector2 direction = (mTarget.position - transform.position).normalized;
            direction += (Random.insideUnitCircle);
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(direction * mMovementSpeed, ForceMode2D.Impulse);

            secondsSinceLastMove = 0.0f;
            secondsUntilNextMove = Random.value;
        }

        if (mTarget.CompareTag("Cell"))
        {
            if (Vector3.Distance(transform.position, mTarget.position) < 0.05f)
            {
                SelectTarget();
            }
        }
    }

    private void SelectTarget()
    {
        if(Random.value > mProbabilityOfTargetingPlayer)
        {
            mTarget = mMainController.GetRandomCell().transform;
        }
        else
        {
            mTarget = mMainController.GetPlayer().transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            --health;
            if (health <= 0)
            {
                //Destroy(this.gameObject);
                gameObject.SetActive(false);
            }
            //Destroy(collision.gameObject);
        }
    }
}
