using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float _spawnLimitXLeft = 10f;
    private float _spawnLimitXRight = 12f;
    private float _spawnPosY = 0;

    private float _startDelay = 1.0f;
    private float _spawnInterval = 2f;

    private void Start()
    {
        SpawnRandomBall();
    }
    
    private async void SpawnRandomBall()
    {
        while (Application.isPlaying)
        {
            var spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight), _spawnPosY, 0);
            var i = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);

            var randomTime = Random.Range(3000, 5000);
            await Task.Delay(randomTime);
        }
    }
}
