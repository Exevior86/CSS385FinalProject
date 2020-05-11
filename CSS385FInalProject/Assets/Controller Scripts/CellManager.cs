using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public GameObject[] mCells = null;

    // Start is called before the first frame update
    void Start()
    {

    }


    public GameObject GetRandomCell()
    {
        Debug.Assert(mCells.Length > 0);
        return mCells[Random.Range(0, mCells.Length)];
    }

}
