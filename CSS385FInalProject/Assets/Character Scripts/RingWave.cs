using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingWave : MonoBehaviour
{
    private float mTotalDuration = 0.5f;
    private float mTotalSize = 20;
    private float mSecondsInstantiated = 0;
    private SpriteRenderer renderer = null;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mSecondsInstantiated += Time.deltaTime;
        if (mSecondsInstantiated > mTotalDuration)
        {
            Destroy(gameObject);
        }

        UpdateAlpha();
        UpdateSize();
    }

    private void UpdateAlpha()
    {
        Color tempColor = renderer.color;
        tempColor.a = 1 - (mSecondsInstantiated / mTotalDuration);
        renderer.color = tempColor;
    }

    private void UpdateSize()
    {
        float newSize = mTotalSize * (mSecondsInstantiated / mTotalDuration);
        transform.localScale = new Vector3(newSize, newSize, 1);
    }

    public void SetDuration(float duration)
    {
        mTotalDuration = duration;
    }
}
