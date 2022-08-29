using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float livingTime;

    private float _timer;

    private void Start()
    {
        Destroy(gameObject, livingTime);
        _timer = Time.time + livingTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        if (Time.time >= _timer)
            GameManager.instance.AddLives(-1);
    }
}