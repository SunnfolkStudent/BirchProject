using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    private Input_Actions _input;
    private Rigidbody2D _rigidbody2D;

    public GameObject halo;
    public Vector2 haloSpawn;

    public float haloSpeed;
    public float spawnTime;
    private float spawnTimeCounter;

    private Vector2 _lookVector;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();

        if (_lookVector == Vector2.zero)
        {
            _lookVector.x = 1;
        }
    }
    
    void Update()
    {
        if (_input.Throw)
        {
            if (!(Time.time > spawnTimeCounter)) return; 
            var projectileClone = Instantiate(halo, UpdateSpawnPosition(), Quaternion.identity);
            projectileClone.GetComponent<Rigidbody2D>().linearVelocity =
                _lookVector * haloSpeed + _rigidbody2D.linearVelocity;
            
            spawnTimeCounter = Time.time + spawnTime;
            Destroy(projectileClone, 4f);
        }

        if (_input.MoveDirection != Vector2.zero)
        {
            _lookVector = _input.MoveDirection;
        }
    }

    private Vector2 UpdateSpawnPosition()
    {
        haloSpawn.x = transform.localPosition.x + (_input.MoveDirection.x / 2);
        haloSpawn.y = transform.localPosition.y + (_input.MoveDirection.y / 2);

        if (haloSpawn == Vector2.zero)
        {
            haloSpawn.x = transform.localPosition.x + 0.5f;
        }
        return haloSpawn;
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _input.MoveDirection * moveSpeed;
    }
}
