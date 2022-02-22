using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    private float maxSpawnTimer = 10f;
    public float spawnTimer = 10f;
    //public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Spawn();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }

        if (spawnTimer <= 0)
        {
            Spawn();
            spawnTimer += maxSpawnTimer;
        }
    }

    void Spawn()
    {
        //enemyCount++;
        //Debug.Log("spawned");
        //Debug.Log(enemyCount);

        float randX = Random.Range(-1.5f, 1.5f);
        float randY = Random.Range(1f, 2f);
        Instantiate(enemy, new Vector3(randX, randY), enemy.transform.rotation);
    }

    public void DecreaseTimer()
    {
        spawnTimer -= 4f;
    }
}
