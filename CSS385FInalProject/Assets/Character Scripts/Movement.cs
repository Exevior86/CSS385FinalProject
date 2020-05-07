using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mHeroSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMotion();
    }

    private void UpdateMotion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * mHeroSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * mHeroSpeed * Time.smoothDeltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * mHeroSpeed * Time.smoothDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.up * mHeroSpeed * Time.smoothDeltaTime;
        }
        
    }
}
