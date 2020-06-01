using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private Camera mMainCamera = null;

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

    [SerializeField]
    private FlashManager mFlashManager = null;
    [SerializeField]
    private FadeManager mFadeManager = null;
    [SerializeField]
    private RingWaveManager mRingWaveManager = null;

    private bool mGameOver = false;

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
            PlayBombEffects();
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

    // To be called when the player is hit but not necessarily damaged. A less noticeable effect than damge
    public void PlayHitEffects()
    {
        PlayDamageEffects();
    }

    // To be callend when the player is damaged. A more noticeable effect than hit
    public void PlayDamageEffects()
    {
        if (!mGameOver)
        {
            mMainCamera.gameObject.GetComponent<Shake>().Play(0.4f, 1, 1.33f);
            mFlashManager.PlayFlash(Color.red, 0.5f, 0.05f);
        }
    }

    public void PlayBombEffects()
    {
        //mMainCamera.gameObject.GetComponent<Shake>().Play(0.1f, 2, 1.33f);
        mFlashManager.PlayFlash(Color.white, 0.1f, 0.07f);
        mRingWaveManager.Play(mPlayer.transform);
    }

    public void PlayDefeatEffects(Action callback)
    {
        Color fadeColor = 0.2f * Color.red;
        mFadeManager.PlayFade(fadeColor, 3, callback);
        mMainCamera.gameObject.GetComponent<Shake>().Play(1, 3, 1);
    }

    public void PlayWinEffects()
    {

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
        //enemyTargetText.text = target.ToString();
    }

    private void RunEndProcess()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("Scenes/UI/DefeatUI");
    }

    public void SignalDefeat()
    {
        if (mGameOver)
        {
            return;
        }

        mGameOver = true;

        PlayDefeatEffects(RunEndProcess);
        mPlayer.GetComponent<PlayerDefeatBehavior>().Play();
        GameObject.Find("Canvas").SetActive(false);
    }
}
