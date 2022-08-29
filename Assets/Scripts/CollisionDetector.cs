using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Projectile"))
            Destroy(gameObject);

        if (CompareTag("Player") && other.CompareTag("Animal"))
            _gameManager.AddLives(-1);
        else if (other.CompareTag("Animal"))
        {
            _gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}
