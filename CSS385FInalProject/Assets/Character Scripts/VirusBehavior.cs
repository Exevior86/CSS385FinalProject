using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    public int health = 2;
    public static int damage = 1;
    public float mProbabilityOfTargetingPlayer = 0.25f;
    public Transform mTarget;
    public MainController mMainController;
    public SwimMovement mMovement;
    private float mInsantiationTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        mInsantiationTime = Time.timeSinceLevelLoad;
        mMainController = GameObject.Find("GameManager").GetComponent<MainController>();
        Debug.Assert(mMainController != null);
    }

    void OnEnable()
    {
        Start();
        GetComponent<SwimTemporaryWander>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mTarget != null && mTarget.CompareTag("Cell"))
        {
            if (Vector3.Distance(transform.position, mTarget.position) < 0.1f
                || mTarget.GetComponent<CellBehavior>().IsInfected())
            {
                SelectTarget();
            }
        }
    }

    public void SelectTarget()
    {
        if(Random.value > mProbabilityOfTargetingPlayer)
        {
            mTarget = mMainController.GetRandomCell().transform;
        }
        else
        {
            mTarget = mMainController.GetPlayer().transform;
        }
        Debug.Log("changing target");
        mMovement.SetToTarget(mTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= Shoot.damage;
            if (health <= 0)
            {
                //Destroy(this.gameObject);
                gameObject.SetActive(false);
                CharacterStats.enemiesDestroyed += 1;
            }
            Destroy(collision.gameObject);
        }
    }

    public Transform GetTarget()
    {
        return mTarget;
    }
}
