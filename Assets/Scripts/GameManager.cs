using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    private int enemyCount;
    public TMP_Text scoreText;
    public TMP_Text hpText;
    public TMP_Text waveText;
    public int score;
    public int waveCount;
    public bool gameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        waveCount = 0;
        score = -10;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == true)
        {
            FindObjectOfType<GameEnd>().ShowEndMenu();
        }

        enemyCount = FindObjectsOfType<EnemyBehavior>().Length;
        scoreText.text = "Score: " + score;
        if (gameIsOver == false)
        {
            hpText.text = "Player: " + FindObjectOfType<HeroController>().health;
        }

        if (enemyCount == 0)
        {
            waveCount++;
            score += (waveCount - 1) * 5 + 10;
            SpawnNewWave((int)(waveCount / 3) + 2);
            enemyCount = FindObjectsOfType<EnemyBehavior>().Length;
        }

        waveText.text = "Wave: " + waveCount;
    }

    void SpawnNewWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
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
