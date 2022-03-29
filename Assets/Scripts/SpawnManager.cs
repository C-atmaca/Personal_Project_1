using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject canonEnemyPrefab;
    public GameObject chaserEnemyPrefab;

    private int canonCount = 0;
    private int chaserCount = 0;
    private int waveNumber = 1;
    private float canonBoundaryX = 12.0f;
    private float canonMaxBoundaryY = 4.0f;
    private float canonMinBoundaryY = -2.0f;
    private float chaserBoundaryX = 13.0f;
    private float chaserBoundaryY = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SpawnCanon()
    {
        for (int i = 0; i < waveNumber/2; i++)
        {
            float randomPosx = Random.Range(-canonBoundaryX, canonBoundaryX);
            float randomPosy = Random.Range(canonMinBoundaryY, canonMaxBoundaryY);
            Vector2 randomPosition = new Vector2(randomPosx, randomPosy);

            Instantiate(canonEnemyPrefab, randomPosition, canonEnemyPrefab.transform.rotation);
        }
    }

    private void SpawnChaser()
    {
        for (int i = 0; i < waveNumber/2; i++)
        {
            float randomPosx = Random.Range(-chaserBoundaryX, chaserBoundaryX);
            float randomPosy = Random.Range(-chaserBoundaryY, chaserBoundaryY);
            Vector2 randomPosition = new Vector2(randomPosx, randomPosy);

            Instantiate(chaserEnemyPrefab, randomPosition, canonEnemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        canonCount = FindObjectsOfType<Canon>().Length;
        chaserCount = FindObjectsOfType<ChasePlayer>().Length;

        if (canonCount + chaserCount == 0)
        {
            SpawnCanon();
            SpawnChaser();
            waveNumber++;
        }
    }
}
