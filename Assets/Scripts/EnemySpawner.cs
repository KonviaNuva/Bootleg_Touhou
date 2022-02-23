using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = FindObjectsOfType<EnemyBehavior>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyBehavior>().Length;

        if (enemyCount == 0)
        {
            SpawnNewWave(3);
        }
    }

    void SpawnNewWave(int enemyNumber)
    {
        for (int i = 0; i < 3; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        float randX = Random.Range(-1.5f, 1.5f);
        float randY = Random.Range(1f, 2f);
        Instantiate(enemy, new Vector3(randX, randY), enemy.transform.rotation);
    }
}
