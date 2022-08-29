using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnRangeX;
    public float spawnOffsetZ;

    public float spawnRangeZ;
    public float spawnOffsetX;
    
    public float spawnDelay;
    public float spawnInterval;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), spawnDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        var spawnSide = Random.Range(0, 3); // Left, Up, Right
        Vector3 spawnPos;
        float rotation;
        switch (spawnSide)
        {
            case 0:
                spawnPos = new Vector3(-spawnOffsetX, 0f, RandomRange(spawnRangeZ));
                rotation = 90f;
                break;
            case 1:
                spawnPos = new Vector3(RandomRange(spawnRangeX), 0f, spawnOffsetZ);
                rotation = 180f;
                break;
            default:
                spawnPos = new Vector3(spawnOffsetX, 0f, RandomRange(spawnRangeZ));
                rotation = 270f;
                break;
        }

        var i = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[i], spawnPos, Quaternion.Euler(0, rotation, 0));

        float RandomRange(float max) => Random.Range(-max, max);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(0f, 0f, spawnOffsetZ), new Vector3(spawnRangeX * 2, 0f, 0f));
        Gizmos.DrawWireCube(new Vector3(spawnOffsetX, 0f, 0f), new Vector3(0f, 0f, spawnRangeZ * 2));
        Gizmos.DrawWireCube(new Vector3(-spawnOffsetX, 0f, 0f), new Vector3(0f, 0f, spawnRangeZ * 2));
    }
}
