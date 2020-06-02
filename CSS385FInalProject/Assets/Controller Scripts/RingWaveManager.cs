using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingWaveManager : MonoBehaviour
{

    private GameObject ringWave = null;

    private Transform origin = null;

    private bool playing = false;
    [SerializeField]
    private float distance = 40;
    [SerializeField]
    private float frequency = 5;
    [SerializeField]
    private float duration = 2;
    private float secondsSincePlayStart = 0;

    [SerializeField]
    private float epsilon = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ringWave = Resources.Load("Prefabs/RingWave") as GameObject;
    }

    private float HarmonicFunction(float t)
    {
        return Mathf.Sin(t * t * frequency);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            secondsSincePlayStart += Time.deltaTime;
            if (secondsSincePlayStart > duration)
            {
                playing = false;
            }
            else
            {
                if (Mathf.Abs(HarmonicFunction(secondsSincePlayStart)) < epsilon)
                {
                    float p = HarmonicFunction(secondsSincePlayStart);
                    p = Mathf.Abs(p);
                    GameObject newWave = Instantiate(ringWave) as GameObject;
                    newWave.transform.position = origin.position;
                    newWave.GetComponent<RingWave>().SetDuration(duration - secondsSincePlayStart);
                }
            }
        }
    }

    public void Play(Transform transform)
    {
        origin = transform;
        secondsSincePlayStart = 0;
        playing = true;
    }
}
