using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float speed;
    public float smoothTime;
    public float shootRate;
    
    private float _initialShootTime;
    private float _totalShootTime;
    
    [Header("Boundaries")]
    public float maxHorizontalDistance;
    public float maxVerticalDistance;

    [Header("Dependencies")]
    public GameObject projectilePrefab;
    public Transform shootPos;
    private GameManager _gameManager;

    // Input
    private Vector2 _rawInput;
    private Vector2 _smoothInput;
    private Vector2 _inputVelocity;

    private Vector3 _clampedPos;
    
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _shootAction;

    private void Awake()
    {
        _clampedPos = transform.position;

        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _shootAction = _playerInput.actions["Shoot"];
    }

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    private void Update()
    {
        if (_gameManager.lives <= 0) return;

        if (_shootAction.WasPressedThisFrame() && Time.time > _totalShootTime)
        {
            _initialShootTime = Time.time;
            _totalShootTime = _initialShootTime + shootRate;
            Instantiate(projectilePrefab, shootPos.position, projectilePrefab.transform.rotation);
        }

        _rawInput = _moveAction.ReadValue<Vector2>();
        _smoothInput = Vector2.SmoothDamp(_smoothInput, _rawInput, ref _inputVelocity, smoothTime);
        
        var t = transform;
        var direction = new Vector3(_smoothInput.x, 0, _smoothInput.y);
        t.Translate(direction * (speed * Time.deltaTime));

        var p = t.position;
        _clampedPos.x = Mathf.Clamp(p.x, -maxHorizontalDistance, maxHorizontalDistance);
        _clampedPos.z = Mathf.Clamp(p.z, -maxVerticalDistance, maxVerticalDistance);
        
        transform.position = _clampedPos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(maxHorizontalDistance * 2f, 0f, maxVerticalDistance * 2f));
    }
}