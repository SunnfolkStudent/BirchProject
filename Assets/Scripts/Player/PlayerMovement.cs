using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    private Input_Actions _input;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    public GameObject halo;
    public Vector2 haloSpawn;
    
    [Header("Audio")]
    
    public AudioClip[] shootingSound;
    public AudioClip[] coolLineSound;
    public AudioClip playerFlapSound;
    [Space(5)] 
    public float flapTime = 0.7f;
    private float _flapTimer;
    
    private AudioSource _audioSource;
    [Space(10)]
    public float haloSpeed;
    public float spawnTime;
    private float spawnTimeCounter;

    private Vector2 _lookVector;

    public static int enemyDeathCounter;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_lookVector == Vector2.zero)
        {
            _lookVector.x = 1;
        }
    }
    
    
    void Update()
    {

        if (enemyDeathCounter > 4)
        {
            _audioSource.PlayOneShot(coolLineSound[Random.Range(0, coolLineSound.Length)]);
            enemyDeathCounter = 0;
        }
        
        if (_flapTimer < Time.time)
        {
            _audioSource.PlayOneShot(playerFlapSound);
            _flapTimer = Time.time + flapTime + playerFlapSound.length;
        }
        
        /*if (_input.Throw)
        {
            if (!(Time.time > spawnTimeCounter)) return;

          
        }*/

        if (_input.MoveDirection != Vector2.zero)
        {
            _lookVector = _input.MoveDirection;
        }
        
        //Flip Sprite if Facing left
        if (_input.MoveDirection.x < Vector2.zero.x)
            _spriteRenderer.flipX = true;
        
        else if (_input.MoveDirection.x > Vector2.zero.x)
        {
            _spriteRenderer.flipX = false;
        }
    }

    public void Shoot()
    {
        _audioSource.PlayOneShot(shootingSound[Random.Range(0, shootingSound.Length)]);
            
        var projectileClone = Instantiate(halo, UpdateSpawnPosition(), Quaternion.identity);
        projectileClone.GetComponent<Rigidbody2D>().linearVelocity = _lookVector * haloSpeed + _rigidbody2D.linearVelocity;
            
        if (_lookVector == Vector2.left)
        {
            projectileClone.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (_lookVector == Vector2.up) projectileClone.transform.rotation = Quaternion.Euler(0, 0, 90);
                
        else if (_lookVector == Vector2.down)
        {
            projectileClone.transform.rotation = Quaternion.Euler(0, 0, 90);
            projectileClone.GetComponent<SpriteRenderer>().flipX = true;
        }
        Destroy(projectileClone, 4f);
        spawnTimeCounter = Time.time + spawnTime;
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