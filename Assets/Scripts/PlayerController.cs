using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public float smoothTime;

    [Header("Boundaries")]
    public float maxDistance;
    
    // Input
    private float _rawInput;
    private float _smoothInput;
    private float _inputVelocity;

    private Vector3 _clampedPos;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private void Awake()
    {
        var position = transform.position;
        _clampedPos = new Vector3(0, position.y, position.z);
        
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    private void Update()
    {
        _rawInput = _moveAction.ReadValue<float>();
        _smoothInput = Mathf.SmoothDamp(_smoothInput, _rawInput, ref _inputVelocity, smoothTime);

        var t = transform;
        t.Translate(Vector3.right * (_smoothInput * speed * Time.deltaTime));

        _clampedPos.x = Mathf.Clamp(t.position.x, -maxDistance, maxDistance);
        transform.position = _clampedPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxDistance * 2f, 0f, 5f));
    }
}