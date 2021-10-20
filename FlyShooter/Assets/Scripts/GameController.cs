using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemy;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }

    void SpawnEnemy()
    {
        float randXPos = Random.Range(-7.0f, 7.0f);
        Vector2 spawnPos = new Vector2(randXPos, 6.0f);

        if (enemy)
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void SetSpawnTime()
    {
        m_spawnTime = spawnTime;
    }

    public void SetGameOverState(bool state)
    {
        m_isGameOver = state;
    }

    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score ++;
    }

    public bool IsGameOver()
    {
        return m_isGameOver;
    }
}
