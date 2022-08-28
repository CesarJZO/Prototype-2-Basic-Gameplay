using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.CompareTag("Player")) return;
        Destroy(other.gameObject);
    }
}
