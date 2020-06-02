using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject mPrefab = null;

    [SerializeField]
    private int mPoolSize = 0;

    private LinkedList<GameObject> mPool;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(mPrefab != null);
        mPool = new LinkedList<GameObject>();
        InitalizePool();
    }


    private void InitalizePool()
    {
        for(int i = 0; i < mPoolSize; i++)
        {
            GameObject newObj = GameObject.Instantiate(mPrefab) as GameObject;
            newObj.SetActive(false);
            newObj.transform.parent = this.transform;
            mPool.AddFirst(newObj);
        }
    }

    public void IncreaseCapacity(int increaseAmount)
    {
        for (int i = 0; i < increaseAmount; i++)
        {
            GameObject newObj = GameObject.Instantiate(mPrefab) as GameObject;
            newObj.SetActive(false);
            newObj.transform.parent = this.transform;
            mPool.AddFirst(newObj);
        }
        mPoolSize += increaseAmount;
    }

    public GameObject InstantiateObject(Transform transform)
    {
        Debug.Assert(mPool.First != null);

        GameObject newObj = null;
        foreach (GameObject obj in mPool)
        {
            if (!obj.activeSelf)
            {
                newObj = obj;
                break;
            }
        }

        if (newObj != null)
        {
            newObj.SetActive(true);
            newObj.transform.position = transform.position;
            newObj.transform.rotation = transform.rotation;
        }

        return newObj;
    }

    public void SetObjectType(GameObject type)
    {
        mPrefab = type;
    }

}
