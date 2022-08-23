using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    public float spawnRangeX;
    public float spawnPosZ;

    private void Spawn()
    {
        var i = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[i], spawnPos, animalPrefabs[i].transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(0, 0, spawnPosZ), new Vector3(spawnRangeX * 2, 0, 0));
    }
}
