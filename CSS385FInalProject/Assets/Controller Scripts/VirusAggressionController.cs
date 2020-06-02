using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusAggressionController : MonoBehaviour
{
    [SerializeField]
    ObjectPool virusPool = null;

    [SerializeField]
    private float mAggresion = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float GetAggression()
    {
        return mAggresion;
    }

    public void IncrementAggresion(float delta)
    {
        mAggresion += delta;
    }
}
