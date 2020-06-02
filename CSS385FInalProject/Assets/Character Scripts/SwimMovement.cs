using UnityEngine;

public class SwimMovement : MonoBehaviour
{
    [SerializeField]
    private float mSpeed = 0.5f;
    [SerializeField]
    private float mDirectionNoiseStrength = 1.0f;
    private float mSecondsSinceLastMove = 0.0f;
    private float mSecondsUntilNextMove = 0.0f;
    private float mTimeOfLastDirectionChange = 0.0f;
    [SerializeField]
    private float kTimeUntilNextDirectionChange = 0.0f;
    private Vector2 mDirection;

    private VirusAggressionController mVirusAggression = null;

    [SerializeField]
    private float mSecondsBetweenDirectionChecks = 0.0f;
    private float mSecondsSinceLastDirectionCheck = 0.0f;

    private float mMinTimeBetweenMoves = 0;
    [SerializeField]
    private float mMaxTimeBetweenMoves = 1;


    private Transform mTarget;

    private ChooseDirectionMethod mChooseDirection;
    private delegate Vector2 ChooseDirectionMethod();

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle;
    }

    private Vector2 GetDirectionToTarget()
    {
        return (mTarget.position - transform.position).normalized;
    }

    void Start()
    {
        mVirusAggression = GameObject.Find("VirusAggression").GetComponent<VirusAggressionController>();
        Debug.Assert(mVirusAggression != null);
    }

    void OnEnable()
    {
        mDirection = Random.insideUnitCircle;
        mChooseDirection = GetRandomDirection;
    }

    void Update()
    {
        SetAgression(mVirusAggression.GetAggression());

        mSecondsSinceLastMove += Time.deltaTime;
        mSecondsSinceLastDirectionCheck += Time.deltaTime;
        if (mSecondsSinceLastDirectionCheck > mSecondsBetweenDirectionChecks)
        {
            mDirection = mChooseDirection();
            mSecondsSinceLastDirectionCheck = 0.0f;
        }


        if (mSecondsSinceLastMove > mSecondsUntilNextMove)
        {
            Vector2 direction = mDirection += (Random.insideUnitCircle * mDirectionNoiseStrength);
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(direction * mSpeed, ForceMode2D.Impulse);

            mSecondsSinceLastMove = 0.0f;
            mSecondsUntilNextMove = Random.Range(mMinTimeBetweenMoves, mMaxTimeBetweenMoves);
        }

    }

    public void SetAgression(float aggresion)
    {
        mMaxTimeBetweenMoves = 1 / aggresion;
        mDirectionNoiseStrength = 1 / aggresion;

        mSpeed = aggresion + 4;
    }

    public void SetToTarget(Transform target)
    {
        Debug.Assert(target != null);
        mTarget = target;
        mChooseDirection = GetDirectionToTarget;
    }

    public void SetToWander()
    {
        mChooseDirection = GetRandomDirection;
    }

    public void setSpeed(float speed)
    {
        mSpeed = speed;
    }


}
