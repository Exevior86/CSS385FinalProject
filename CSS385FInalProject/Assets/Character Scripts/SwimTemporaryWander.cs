using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimTemporaryWander : MonoBehaviour
{
    [SerializeField]
    private SwimMovement mMovement = null;
    [SerializeField]
    private VirusBehavior mBehavior = null;
    private float mInstantiationTime = 0.0f;
    [SerializeField]
    private float kSecondsToWander = 5.0f;

    void OnEnable()
    {
        mInstantiationTime = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad - mInstantiationTime > kSecondsToWander)
        {
            mBehavior.SelectTarget();
            enabled = false;
        }
    }
}
