using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField]
    private MainController mainController = null;

    private int mEnemyTarget = 0;

    // Start is called before the first frame update
    void Start()
    {
        mEnemyTarget = GetNextEnemyTarget();
        mainController.SetEnemyTarget(mEnemyTarget);
    }

    private int GetNextEnemyTarget()
    {
        return (int)(Mathf.Pow(mainController.GetNumberOfClones() + 1, 2)) * 50;
    }


    private void IssueUpgrade()
    {
        mainController.CreateClone();
        mEnemyTarget = GetNextEnemyTarget();
        mainController.SetEnemyTarget(mEnemyTarget);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainController.GetNumberOfEnemiesKilled() >= mEnemyTarget)
        {
            IssueUpgrade();
        }
    }
}
