using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float livingTime;

    private void Start()
    {
        Destroy(gameObject, livingTime);
        direction.Normalize();
    }

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime), Space.World);
    }
}