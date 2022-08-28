using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float delay;
    private float _initialTime;
    private float _totalTime;

    // Update is called once per frame
    void Update()
    {
        // On space bar press, send dog
        if (Time.time > _totalTime && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _initialTime = Time.time;
            _totalTime = _initialTime + delay;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
