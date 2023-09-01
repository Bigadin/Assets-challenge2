using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _EnemyPrefab;
    private bool StopSpawningEnemy = false;
    public float tempo = 3f;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        tempo = 3f;
        while (StopSpawningEnemy == false)
        {
            if(tempo <= 0.3f)
            {
                tempo = 3f;
            }
            Vector3 RighPos = new Vector3(Random.Range(50, 65), 0, Random.Range(0, 65));
            Vector3 LeftPos = new Vector3(Random.Range(-50, -65), 0, Random.Range(0, 65));
            Vector3 BehPos = new Vector3(Random.Range(0, 65), 0, Random.Range(-50, -65));
            Vector3 towPos = new Vector3(Random.Range(0, 65), 0, Random.Range(-50, -65));
            int pos = Random.Range(1, 4);
            if (pos == 1)
            {
                Instantiate(_EnemyPrefab[RandomEnemy()], RighPos, Quaternion.identity);
            }
            else if (pos == 2)
            {
                Instantiate(_EnemyPrefab[RandomEnemy()], LeftPos, Quaternion.identity);
            }
            else if (pos == 3)
            {
                Instantiate(_EnemyPrefab[RandomEnemy()], BehPos, Quaternion.identity);
            }
            else
            {
                Instantiate(_EnemyPrefab[RandomEnemy()], towPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(tempo);
            tempo = tempo - 0.15f;
        }
    }
    private int RandomEnemy()
    {
        return Random.Range(1, 2);
    }

}