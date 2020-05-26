using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    [SerializeField]
    private Transform mTarget = null;
    [SerializeField]
    private Vector3 mTargetOffset = Vector3.zero;
    [SerializeField]
    private float mSpeed = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, mTarget.position + mTargetOffset, Time.deltaTime * mSpeed);
    }

    public void SetTarget(Transform position)
    {
        mTarget = position;
    }

    public void SetTargetOffset(Vector3 offset)
    {
        mTargetOffset = offset;
    }

    public void SetSpeed(float speed)
    {
        mSpeed = speed;
    }
}
