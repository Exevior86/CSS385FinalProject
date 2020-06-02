using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalDifficultyScaler : MonoBehaviour
{
    [SerializeField]
    private MainController mainController = null;

    [SerializeField]
    private VirusAggressionController virusAggression = null;

    [SerializeField]
    private ObjectPool virusPool = null;

    [SerializeField]
    private float increaseFrequency = 30;
    [SerializeField]
    private float agressionIncreaseAmount = 0.1f;
    [SerializeField]
    private float numberIncreaseAmount = 10;

    private float secondsSinceLastIncrease = 0;

    // Update is called once per frame
    void Update()
    {
        secondsSinceLastIncrease += Time.deltaTime;
        if (secondsSinceLastIncrease > increaseFrequency)
        {
            secondsSinceLastIncrease = 0;

            virusAggression.IncrementAggresion(0.1f);
            virusPool.IncreaseCapacity(10);
            Debug.Log("difficulty increase");
        } 
    }
}
