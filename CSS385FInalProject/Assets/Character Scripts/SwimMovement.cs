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
    private Vector2 mLastDirection;

    private Transform mTarget;

    private ChooseDirectionMethod mChooseDirection;
    private delegate Vector2 ChooseDirectionMethod();

    private Vector2 GetRandomDirection()
    {
        return Random.insideUnitCircle;
        if ((Time.timeSinceLevelLoad - mTimeOfLastDirectionChange) >= kTimeUntilNextDirectionChange)
        {
            mLastDirection = Random.insideUnitCircle;
            mTimeOfLastDirectionChange = Time.timeSinceLevelLoad;
            return mLastDirection;
        }
        else
        {
            return mLastDirection;
        }
    }

    private Vector2 GetDirectionToTarget()
    {
        return (mTarget.position - transform.position).normalized;
    }

    void OnEnable()
    {
        mLastDirection = Random.insideUnitCircle;
        mChooseDirection = GetRandomDirection;
    }

    void Update()
    {
        mSecondsSinceLastMove += Time.deltaTime;

        if (mSecondsSinceLastMove > mSecondsUntilNextMove)
        {
            Vector2 direction = mChooseDirection();
            direction += (Random.insideUnitCircle * mDirectionNoiseStrength);
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(direction * mSpeed, ForceMode2D.Impulse);

            mSecondsSinceLastMove = 0.0f;
            mSecondsUntilNextMove = Random.value;
        }

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
