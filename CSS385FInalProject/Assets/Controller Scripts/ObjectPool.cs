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
            newObj.transform.localPosition = transform.localPosition;
            newObj.transform.localRotation = transform.localRotation;
        }

        return newObj;
    }

    public void SetObjectType(GameObject type)
    {
        mPrefab = type;
    }

}
