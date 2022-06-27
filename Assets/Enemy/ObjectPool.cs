using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 5;

    private GameObject[] pool;

    private void Awake()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSecondsRealtime(spawnTimer);
        }
    }

    private void EnableObjectInPool()
    {
        foreach(GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy)
                continue;

            enemy.SetActive(true);
            return;
        }
    }
}
