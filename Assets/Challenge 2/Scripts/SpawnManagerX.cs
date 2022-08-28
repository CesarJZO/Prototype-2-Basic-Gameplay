using System.Threading.Tasks;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private const float SpawnLimitXLeft = 10f;
    private const float SpawnLimitXRight = 12f;
    private const float SpawnPosY = 0;

    private void Start()
    {
        SpawnRandomBall();
    }
    
    private async void SpawnRandomBall()
    {
        while (Application.isPlaying)
        {
            var spawnPos = new Vector3(Random.Range(SpawnLimitXLeft, SpawnLimitXRight), SpawnPosY, 0);
            var i = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[i], spawnPos, ballPrefabs[i].transform.rotation);

            var randomTime = Random.Range(3000, 5000);
            await Task.Delay(randomTime);
        }
    }
}
