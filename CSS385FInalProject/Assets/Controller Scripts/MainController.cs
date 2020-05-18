using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private ObjectPool mVirusPool = null;

    [SerializeField]
    private CellManager mCellManager = null;

    [SerializeField]
    private GameObject mPlayer = null;

    [SerializeField]
    private LivesUI mLivesUI = null;

    void Awake()
    {
        Debug.Assert(mVirusPool != null);
        //Debug.Assert(mPlayer != null);
        mVirusPool.SetObjectType(Resources.Load("Prefabs/virus_0") as GameObject);
    }

    void Start()
    {
        Debug.Assert(mVirusPool != null);
    }

    public bool SpawnVirus(Transform transform)
    {
        return mVirusPool.InstantiateObject(transform);
    }

    public GameObject GetRandomCell()
    {
        return mCellManager.GetRandomCell();
    }

    public GameObject GetRandomCell(Transform transform)
    {
        return mCellManager.GetRandomCloseCell(transform);
    }

    public GameObject GetPlayer()
    {
        return mPlayer;
    }

    public void LowerLives()
    {
        mLivesUI.LowerLives();
    }
}
