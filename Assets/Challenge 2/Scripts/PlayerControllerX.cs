using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float delay;
    private float _timer;

    // Update is called once per frame
    void Update()
    {
        // On space bar press, send dog
        if (_timer < 0 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _timer = delay;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }

        _timer -= Time.deltaTime;
    }
}
