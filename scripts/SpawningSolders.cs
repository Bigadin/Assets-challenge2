using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;


public class SpawningSolders : MonoBehaviour
{
    [SerializeField] int infantryAmount = 20, ArcherAmount = 10,trapAmount = 5, amountChecker;
    GameObject solderToSpawn;
    [SerializeField] List<GameObject> solders;
    [SerializeField] Transform parent;
    [SerializeField] Transform EnemySpawner;
    public List<Solder> solderSpawned;

    [SerializeField]float TimerForRespawn = 10f;
    float CurrentTimerForRespawn;
    bool startTimer;


    [Header("UI")]
    [SerializeField]TextMeshProUGUI SoldersAmountUI;
    [SerializeField]TextMeshProUGUI infantryAdd;
    [SerializeField]TextMeshProUGUI mageAdd;
    [SerializeField]TextMeshProUGUI trapAmountui;
    private void Start()
    {
        CurrentTimerForRespawn = TimerForRespawn;
    }
    private void Update()
    {
        SoldersAmountUI.text = "Solders : " + solderSpawned.Count;
        mageAdd.text = " + " + ArcherAmount;
        infantryAdd.text = " + " + infantryAmount;
        trapAmountui.text = " + " + trapAmount;

        if(startTimer)
        {
            if(TimerForRespawn > 5)
                TimerForRespawn -= Time.deltaTime * 0.05f;
            CurrentTimerForRespawn -= Time.deltaTime;
            if(CurrentTimerForRespawn <= 0)
            {
                int rnd = Random.Range(0, 2);
                if(rnd == 0 )
                    infantryAmount++;
                if(rnd == 1)
                    ArcherAmount++;

                CurrentTimerForRespawn = TimerForRespawn;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(amountChecker > 0)
            {
                amountChecker--;
                RefreshCounters();
                GameObject gb = Instantiate(solderToSpawn,GetMousePositionInWorld(),solderToSpawn.transform.rotation,parent).gameObject;
                solderSpawned.Add(gb.GetComponent<Solder>());
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            amountChecker = infantryAmount;
            solderToSpawn = solders[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            amountChecker = ArcherAmount;
            solderToSpawn = solders[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            amountChecker = trapAmount;
            solderToSpawn = solders[2];
        }
    }
    void RefreshCounters()
    {
        if(solderToSpawn == solders[0])
        {
            infantryAmount = amountChecker;
        }
        else if(solderToSpawn == solders[1])
        {
            ArcherAmount = amountChecker;
        }
        else
        {
            trapAmount = amountChecker;
        }
    }
 
    public Vector3 GetMousePositionInWorld()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity,LayerMask.GetMask("Ground")))
        {
            return new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        return Vector3.zero; 
    }

    public void StartGame()
    {
        startTimer = true;
        EnemySpawner.gameObject.SetActive(true);
    }

  
}
