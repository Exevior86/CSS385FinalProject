using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentBar : MonoBehaviour
{
    public Transform mFiledBar = null;

    private float mAlpha = 0;

    public void SetValue(float value)
    {
        mAlpha = Mathf.Clamp(value, 0, 1);
        mFiledBar.localScale = new Vector3(1 - mAlpha, mFiledBar.transform.localScale.y, mFiledBar.transform.localScale.z);
        mFiledBar.localPosition = new Vector3(0.5f * mFiledBar.transform.localScale.x - 0.5f, mFiledBar.transform.localPosition.y, mFiledBar.transform.localPosition.z);
    }
}
