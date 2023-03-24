using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    [SerializeField] private GameObject canonEnemyPrefab;
    [SerializeField] private GameObject chaserEnemyPrefab;

    private Canon canonEnemyPrototype = new Canon();
    private ChasePlayer chaserEnemyPrototype = new ChasePlayer();

    public int CreateEnemy(int spawnIndex)
    {
        switch (spawnIndex)
        {
            case 1:
                return SpawnCanon();
            case 2:
                return SpawnChaser();
        }

        return 0;
    }

    private int SpawnCanon()
    {
        for (int i = 0; i < SpawnManager.Instance.waveNumber/2; i++)
        {
            float randomPosx = Random.Range(-SpawnManager.Instance.canonBoundaryX, SpawnManager.Instance.canonBoundaryX);
            float randomPosy = Random.Range(SpawnManager.Instance.canonMinBoundaryY, SpawnManager.Instance.canonMaxBoundaryY);
            Vector2 randomPosition = new Vector2(randomPosx, randomPosy);

            GameObject canonObject = Instantiate(canonEnemyPrefab, randomPosition, canonEnemyPrefab.transform.rotation);
            Enemy newEnemy = canonEnemyPrototype.Clone();
            newEnemy = canonObject.GetComponent<Canon>();
        }

        return (SpawnManager.Instance.waveNumber/2) - 1;
    }

    private int SpawnChaser()
    {
        for (int i = 0; i < SpawnManager.Instance.waveNumber/2/2; i++)
        {
            float randomPosx = Random.Range(-SpawnManager.Instance.canonBoundaryX, SpawnManager.Instance.chaserBoundaryX);
            float randomPosy = Random.Range(-SpawnManager.Instance.chaserBoundaryY, SpawnManager.Instance.chaserBoundaryY);
            Vector2 randomPosition = new Vector2(randomPosx, randomPosy);

            Instantiate(chaserEnemyPrefab, randomPosition, canonEnemyPrefab.transform.rotation);
        }
        
        return (SpawnManager.Instance.waveNumber/2/2) - 1;
    }
}
