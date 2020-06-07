using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBehavior : MonoBehaviour
{
    public int mMaxHealth = 2;
    private int mCurrentHealth = 1;
    public static int damage = 1;
    public float mProbabilityOfTargetingPlayer = 0.25f;
    public Transform mTarget;
    public MainController mMainController;
    public SwimMovement mMovement;
    private float mInsantiationTime = 0.0f;
    [SerializeField]
    private ParticleSystem virusKillParticleSystem = null;
    [SerializeField]
    private ParticleSystem virusKillParticleSystem2 = null;

    private bool mDestroyed = false;
    private float mSecondsDestroyed = 0.0f;
    private const float kDestructionDelay = 3;

    private bool mIsDamaging = false;
    private float mSecondsSinceInstantiation = 0;
    [SerializeField]
    private float mSecondsBeforeDamaging = 2;

    //private float mSecondsSinceTargetChange = 0.0f;
    //[SerializeField]
    //private float kSecondsUntilTargetChange = 12;

    // Start is called before the first frame update
    void Start()
    {
        mMainController = GameObject.Find("GameManager").GetComponent<MainController>();
        Debug.Assert(mMainController != null);
        mCurrentHealth = mCurrentHealth * LevelController.difficulty;
    }

    void OnEnable()
    {
        //Start();
        mIsDamaging = false;
        mSecondsSinceInstantiation = 0;
        GetComponent<SwimTemporaryWander>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        mDestroyed = false;
        mCurrentHealth = mMaxHealth;
        //mSecondsSinceTargetChange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mDestroyed)
        {
            mSecondsDestroyed += Time.deltaTime;
            if (mSecondsDestroyed > kDestructionDelay)
            {
                mSecondsDestroyed = 0.0f;
                gameObject.SetActive(false);
            }
        }

        if (!mIsDamaging)
        {
            mSecondsSinceInstantiation += Time.deltaTime;
            if (mSecondsSinceInstantiation > mSecondsBeforeDamaging)
            {
                mIsDamaging = true;
            }
        }

        //mSecondsSinceTargetChange += Time.deltaTime;
        //if (mSecondsSinceTargetChange > kSecondsUntilTargetChange)
        //{
        //    SelectTarget();
        //    mSecondsSinceTargetChange = 0;
        //}

        if (mTarget != null && mTarget.CompareTag("Cell"))
        {
            if (mTarget.GetComponent<CellBehavior>().IsInfected())
            {
                SelectTarget();
            }
        }
    }

    public bool isDamaging()
    {
        return mIsDamaging;
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

    public void Kill()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        virusKillParticleSystem.Play();
        virusKillParticleSystem2.Play();
        mDestroyed = true;
        ScoreScript.VirusKilled++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            virusKillParticleSystem2.Play();
            mCurrentHealth -= Shoot.damage;
            if (mCurrentHealth <= 0)
            {
                SoundManagerScript.PlaySound("VirusDie");
                Kill();
            }
            Destroy(collision.gameObject);
        }
    }

    public Transform GetTarget()
    {
        return mTarget;
    }
}
