using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    [Header("Audio")]
    public AudioClip[] shootingSound;
    public AudioClip[] coolLineSound;
    public AudioClip playerFlapSound;
    private AudioSource _audioSource;

    [Header("Flap")]
    public float flapTime = 0.7f;
    private float _flapTimer;

    [Header("Halo")]
    public float haloSpeed;
    public GameObject halo;
    public Vector2 haloSpawn;
    public static int EnemyDeathCounter;

    [Header("Components")]
    private Input_Actions _input;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (EnemyDeathCounter > 4)
        {
            _audioSource.PlayOneShot(coolLineSound[Random.Range(0, coolLineSound.Length)]);
            EnemyDeathCounter = 0;
        }

        if (_flapTimer < Time.time)
        {
            _audioSource.PlayOneShot(playerFlapSound);
            _flapTimer = Time.time + flapTime + playerFlapSound.length;
        }

        //Flip Sprite if Facing left 
        //_spriteRenderer.flipX = _input.MoveDirection.x < 0;
    }

    public void Shoot()
    {
        var dir = PlayerAnimationController.PreviousShootDirection;
        _audioSource.PlayOneShot(shootingSound[Random.Range(0, shootingSound.Length)]);

        var projectileClone = Instantiate(halo, UpdateSpawnPosition(), Quaternion.identity);

        projectileClone.GetComponent<Rigidbody2D>().linearVelocity = dir * haloSpeed;

        if (dir == Vector2.left)
        {
            projectileClone.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (dir == Vector2.up)
        {
            projectileClone.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (dir == Vector2.down)
        {
            projectileClone.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        Destroy(projectileClone, 4f);
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