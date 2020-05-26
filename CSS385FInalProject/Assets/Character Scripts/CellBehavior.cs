using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehavior : MonoBehaviour
{
    [SerializeField]
    private Color kHealthyColor = Color.white;
    [SerializeField]
    private Color kInfectedColor = Color.blue;
    [SerializeField]
    private float kSecondsToBeInfected = 1;


    public float cooldown = 1f;
    public float cooldownTimer = 0;
    public bool infected = false;

    public float percentInfected = 0;

    public PercentBar mInfectionBar = null;


    private MainController mainController;
    private CellManager cellManager;

    [SerializeField]
    private Sprite spriteHealthy = null;
    [SerializeField]
    private Sprite spriteInfected = null;

    public ParticleSystem cellCuredParticleSystem = null;
    public ParticleSystem cellInfectedParticleSystem = null;



    // Start is called before the first frame update
    void Start()
    {
        mainController = GameObject.Find("GameManager").GetComponent<MainController>();
        cellManager = GameObject.Find("CellManager").GetComponent<CellManager>();
        Debug.Assert(mainController != null);
        Debug.Assert(cellManager != null);

        if (infected)
        {
            Infect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInfectionStatus();
        UpdateHealthDisplay();
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if (IsInfected())
        {
            SpawnVirus();
            cooldownTimer = cooldown;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            Disinfect();
        }
    }

    private void UpdateHealthDisplay()
    {
        mInfectionBar.SetValue(percentInfected);
        GetComponent<Renderer>().material.color = Color.Lerp(kHealthyColor, kInfectedColor, percentInfected);
    }

    private void UpdateInfectionStatus()
    {
        percentInfected = Mathf.Clamp(percentInfected, 0, 1);
        if (!infected && percentInfected == 1)
        {
            Infect();
        }
        else if (infected && percentInfected == 0)
        {
            Disinfect();
        }
    }

    private void SpawnVirus()
    {
        //GameObject enemy = Instantiate(enemyToSpawn) as GameObject;
        //enemy.transform.position = transform.position;

        mainController.SpawnVirus(transform);
    }

    public void Infect()
    {
        percentInfected = 1;
        infected = true;
        GetComponent<Renderer>().material.color = Color.white;
        GetComponent<SpriteRenderer>().sprite = spriteInfected;
        cellInfectedParticleSystem.Play();
        cellManager.notifyOfInfectionChange(this);
    }

    public void Disinfect()
    {
        ScoreScript.CellsCured++;
        percentInfected = 0;
        infected = false;
        GetComponent<Renderer>().material.color = Color.blue;
        GetComponent<SpriteRenderer>().sprite = spriteHealthy;
        cellCuredParticleSystem.Play();
        cellManager.notifyOfInfectionChange(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            percentInfected = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Virus"))
        {
            //Infect();
            percentInfected += Time.deltaTime / kSecondsToBeInfected;
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            //Infect();
            percentInfected -= Time.deltaTime / kSecondsToBeInfected;
        }
    }

    public bool IsInfected()
    {
        return infected;
    }
}
