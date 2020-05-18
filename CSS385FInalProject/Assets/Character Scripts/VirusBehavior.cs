using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    public int health = 2;
    public static int damage = 1;
    public float mProbabilityOfTargetingPlayer = 0.05f;
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
            if (mTarget.GetComponent<CellBehavior>().IsInfected())
            {
                SelectTarget();
            }
        }
    }

    public void SelectTarget()
    {
        if(Random.value > mProbabilityOfTargetingPlayer)
        {
            mTarget = mMainController.GetRandomCell(transform).transform;
        }
        else
        {
            mTarget = mMainController.GetPlayer().transform;
        }
        mMovement.SetToTarget(mTarget);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= Shoot.damage;
            if (health <= 0)
            {
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
