using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float livingTime;

    private void Start()
    {
        Destroy(gameObject, livingTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}