using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float _spawnLimitXLeft = 10f;
    private float _spawnLimitXRight = 12f;
    private float _spawnPosY = 0;

    private float _startDelay = 1.0f;
    private float _spawnInterval = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomBall), _startDelay, _spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    private void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        var spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight), _spawnPosY, 0);
        var i = Random.Range(0, ballPrefabs.Length);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);
    }
}
