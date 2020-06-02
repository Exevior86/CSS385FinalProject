using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer fadeTexture = null;

    private Action callback;
    private bool fading = false;
    private float fadeDuration = 0;
    private float secondsSinceFadeStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(fadeTexture != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            secondsSinceFadeStart += Time.deltaTime;

            if(secondsSinceFadeStart > fadeDuration)
            {
                fading = false;
                if (callback != null)
                {
                    callback();
                }
            }
            else
            {
                Color temp = fadeTexture.color;
                temp.a = secondsSinceFadeStart / fadeDuration;
                fadeTexture.color = temp;
            }
        }
    }

    public void PlayFade(Color color, float duration, Action callback)
    {
        Color temp = color;
        temp.a = 0;
        fadeTexture.color = temp;

        fadeDuration = duration;
        this.callback = callback;

        secondsSinceFadeStart = 0;
        fading = true;
    }
}
