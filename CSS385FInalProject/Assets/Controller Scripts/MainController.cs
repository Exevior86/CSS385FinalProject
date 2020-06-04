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

    private FlashManager mFlashManager = null;
    private FadeManager mFadeManager = null;
    private RingWaveManager mRingWaveManager = null;

    private bool mGameOver = false;

    void Awake()
    {
        mVirusPool = GameObject.Find("VirusPool").GetComponent<ObjectPool>();
        Debug.Assert(mVirusPool != null);

        //Debug.Assert(mPlayer != null);
        mVirusPool.SetObjectType(Resources.Load("Prefabs/virus_0") as GameObject);
    }

    void Start()
    {
        mCellManager = GameObject.Find("CellManager").GetComponent<CellManager>();
        Debug.Assert(mCellManager != null);
        mPlayer = GameObject.FindWithTag("Player");
        Debug.Assert(mPlayer != null);

        mCloneManager = GameObject.Find("CloneManager").GetComponent<PlayerCloneController>();
        Debug.Assert(mCloneManager != null);
        mFlashManager = GameObject.Find("FlashManager").GetComponent<FlashManager>();
        Debug.Assert(mFlashManager != null);
        mFadeManager = GameObject.Find("FadeManager").GetComponent<FadeManager>();
        Debug.Assert(mFadeManager != null);
        mRingWaveManager = GameObject.Find("RingWaveManager").GetComponent<RingWaveManager>();
        Debug.Assert(mRingWaveManager != null);


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
            SoundManagerScript.PlaySound("TakeDamage");
            mMainCamera.gameObject.GetComponent<Shake>().Play(0.4f, 1, 1.33f);
            mFlashManager.PlayFlash(Color.red, 0.5f, 0.05f);
        }
    }

    public void PlayBombEffects()
    {
        mMainCamera.gameObject.GetComponent<Shake>().Play(0.1f, 2, 1.33f);
        mFlashManager.PlayFlash(Color.white, 0.1f, 0.07f);
        mRingWaveManager.Play(mPlayer.transform);
    }

    public void PlayDefeatEffects(Action callback)
    {
        SoundManagerScript.PlaySound("Death");
        Color fadeColor = 0.2f * Color.red;
        mFadeManager.PlayFade(fadeColor, 3, callback);
        mMainCamera.gameObject.GetComponent<Shake>().Play(1, 3, 1);
    }

    public void PlayWinEffects(Action callback)
    {
        SoundManagerScript.PlaySound("WinningSound");
        Color fadeColor = Color.white;
        mFadeManager.PlayFade(fadeColor, 1.45f, callback);
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

    private void RunWinProcess()
    {
        Cursor.visible = true;
        UIScript.level++;
        SceneManager.LoadScene("Scenes/UI/WinUI");
    }

    private void DisablePlayer()
    {
        mPlayer.GetComponent<Rigidbody2D>().simulated = false;
        mPlayer.GetComponent<Movement>().enabled = false;
        mPlayer.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SignalDefeat()
    {
        if (mGameOver)
        {
            return;
        }

        mGameOver = true;

        PlayDefeatEffects(RunEndProcess);
        DisablePlayer();
        GameObject.Find("Canvas").SetActive(false);
    }

    public void SignalWin()
    {
        PlayWinEffects(RunWinProcess);
        DisablePlayer();
        GameObject.Find("Canvas").SetActive(false);
    }
}
