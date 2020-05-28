using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private PlayerCloneController mCloneManager = null;

    [SerializeField]
    private UIScript mUIManager = null;

    [SerializeField]
    private Text enemyTargetText = null;
    [SerializeField]
    private Text enemiesKiledText = null;



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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
            CreateClone();
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

    public bool CreateClone()
    {
        return mCloneManager.CreateClone(mPlayer.transform);
    }

    public void DeleteClone()
    {
        mCloneManager.DeleteClone();
    }

    public int GetNumberOfEnemiesKilled()
    {
        return ScoreScript.VirusKilled;
    }

    public int GetNumberOfClones()
    {
        return mCloneManager.GetNumberOfClones();
    }

    public void SetEnemyTarget(int target)
    {
        enemyTargetText.text = "Kills till upgrade: " + target.ToString();
        Debug.Log("Being Called in SetEnemyTarget()");
    }
}
