using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    [SerializeField]
    private int kMaxClones = 0;

    [SerializeField]
    private float averageDistanceFromPlayer = 0;
    [SerializeField]
    private float distanceFromPlayerVariance = 0;

    [SerializeField]
    private float averageSpeed = 0;
    [SerializeField]
    private float speedVariance = 0;

    public bool CreateClone(Transform transform)
    {
        if (gameObject.transform.childCount >= kMaxClones)
        {
            return false;
        }
        GameObject newClone = GameObject.Instantiate(Resources.Load("Prefabs/WhiteBloodCellCopy") as GameObject);
        newClone.transform.parent = gameObject.transform;
        newClone.transform.position = transform.position;
        FollowMovement movementScript = newClone.GetComponent<FollowMovement>();
        movementScript.SetTarget(transform);
        movementScript.SetTargetOffset(Random.insideUnitCircle * (averageDistanceFromPlayer + Random.Range(-distanceFromPlayerVariance, distanceFromPlayerVariance)));
        movementScript.SetSpeed(averageSpeed + Random.Range(-speedVariance, speedVariance));
        return true;
    }

    public void DeleteClone()
    {
        if (transform.childCount > 0)
        {
            GameObject.Destroy(transform.GetChild(0).gameObject);
        }
    }

    public int GetNumberOfClones()
    {
        return transform.childCount;
    }
}
