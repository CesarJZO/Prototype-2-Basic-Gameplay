using System.Threading.Tasks;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnRangeX;
    public float spawnPosZ;

    public bool allowSpawn;
    
    [Tooltip("Time in milliseconds"), Min(500)] public int timeBetweenSpawns;
    
    private void Start()
    {
        Spawn();
    }

    private async void Spawn()
    {
        while (allowSpawn && Application.isPlaying)
        {
            var i = Random.Range(0, animalPrefabs.Length);
            var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(animalPrefabs[i], spawnPos, animalPrefabs[i].transform.rotation);
            // await Task.Yield(); // Almost the same as yield return null. This is not frame-perfect
            await Task.Delay(timeBetweenSpawns);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(0, 0, spawnPosZ), new Vector3(spawnRangeX * 2, 0, 0));
    }
}
