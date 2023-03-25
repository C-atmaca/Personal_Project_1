using UnityEngine;

/*
    IMPLEMENTS SINGLETON PATTERN
    USES FACTORY PATTERN TO SPAWN ENEMIES
*/

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    
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
    
    private int canonCount = 0;
    private int chaserCount = 0;
    [SerializeField] private EnemyFactory enemyFactory;

    public int waveNumber = 1;
    public float canonBoundaryX = 12.0f;
    public float canonMaxBoundaryY = 4.0f;
    public float canonMinBoundaryY = -2.0f;
    public float chaserBoundaryX = 13.0f;
    public float chaserBoundaryY = 7.5f;

    // Update is called once per frame
    private void Update()
    {
        canonCount = FindObjectsOfType<Canon>().Length;
        chaserCount = FindObjectsOfType<ChasePlayer>().Length;

        if (canonCount + chaserCount <= 0)
        {
            canonCount = enemyFactory.CreateEnemy(1);
            chaserCount = enemyFactory.CreateEnemy(2);
            waveNumber++;
        }
    }
}
