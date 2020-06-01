using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefeatBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        gameObject.GetComponent<Movement>().enabled = false;

        // Disable crosshair
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
