using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer flashTexture = null;

    private float flashAlpha = 0;
    private float flashAlphaCap = 0.5f;
    private float secondsSinceFlashStart = 0;
    private float risingSeconds = 0.25f;
    private bool flashing = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(flashTexture != null);
    }

    // Update is called once per frame
    void Update()
    {
        if (flashing)
        {
            secondsSinceFlashStart += Time.deltaTime;

            flashAlpha = Mathf.Max(0, flashAlphaCap - Mathf.Abs(secondsSinceFlashStart - risingSeconds));
            if (flashAlpha == 0)
            {
                flashing = false;
            }
            Color temp = flashTexture.color;
            temp.a = flashAlpha;
            flashTexture.color = temp;
        }
    }

    public void PlayFlash(Color color, float intensity, float startingSeconds)
    {
        flashTexture.color = color;
        flashAlphaCap = intensity;
        risingSeconds = startingSeconds;
        secondsSinceFlashStart = 0;
        flashing = true;
    }
}
