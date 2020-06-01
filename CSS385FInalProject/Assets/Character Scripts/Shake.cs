using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    private float amplitude = 1;
    [SerializeField]
    private float durationSeconds = 2;
    [SerializeField]
    private float cycles = 4;

    private float secondsSinceShakeStart = 0;

    private bool shaking = false;

    private float dx, dy;


    private float dampedHarmonicFunction(float t)
    {
        return Mathf.Pow((durationSeconds - t), 2) * Mathf.Cos(2 * Mathf.PI * t * cycles) * amplitude;
    }

    public Vector3 GetDeltaVec()
    {
        if (!shaking)
        {
            return Vector3.zero;
        }

        return new Vector3(dx, dy, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (shaking)
        {
            secondsSinceShakeStart += Time.deltaTime;
            if (secondsSinceShakeStart > durationSeconds)
            {
                shaking = false;
            }
            else
            {
                dx = dampedHarmonicFunction(secondsSinceShakeStart) * Random.Range(-1, 1);
                dy = dampedHarmonicFunction(secondsSinceShakeStart) * Random.Range(-1, 1);
                if (Random.value > 0.5)
                {
                    dx = -dx;
                }
                if (Random.value > 0.5)
                {
                    dy = -dy;
                }
            }
        }

    }

    public void Play(float amplitude, float duration, float cycles)
    {
        if (shaking)
        {
            this.amplitude += (0.33f * amplitude);
        }
        else
        {
            this.amplitude = amplitude;
        }

        durationSeconds = duration;
        this.cycles = cycles;

        secondsSinceShakeStart = 0;
        shaking = true;
    }
}
