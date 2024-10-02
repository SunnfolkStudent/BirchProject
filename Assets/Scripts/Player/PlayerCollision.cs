using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int playerHealth = 3;
    public bool playerIsDead;
    public float fallSpeed = 10f;
    public float deathTime = 2f;
    public float invincibilityTime = 1f;
    public float timerInvinc = 0f;
    
    private Rigidbody2D _rigidbody2D;
    private Input_Actions _input;
    private PlayerMovement _playerMovement;

    public GameObject enemySpawner;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();
        _playerMovement = GetComponent<PlayerMovement>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Halo")) return;
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
            if (timerInvinc > 0)
            {
                return;
            }
            playerHealth--;
            timerInvinc = invincibilityTime;
        }
        if (playerHealth == 0)
        {
            playerIsDead = true;
            _input.enabled = false;
            _playerMovement.enabled = false;
            Destroy(enemySpawner);
            // Disable PlayerAnimation Controller
            // Play FallingAnimation
        }
    }

    private void FixedUpdate()
    {
        if (playerIsDead)
        {
            _rigidbody2D.linearVelocity = Vector2.down * fallSpeed;
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        timerInvinc -= Time.deltaTime;
    }
}
