using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryDisableCollider : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan = 1;

    private float timeAlive = 0;

    void OnEnable()
    {
        timeAlive = 0;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        Color tempColor = renderer.color;
        tempColor.a = 0.5f;
        renderer.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > lifeSpan)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            this.enabled = false;
            SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
            Color tempColor = renderer.color;
            tempColor.a = 1;
            renderer.color = tempColor;
        }
    }
}
