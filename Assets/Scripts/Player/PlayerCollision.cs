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

    public BocAnimationController animationController;

    public GameObject bottomBorder;
    
    private Rigidbody2D _rigidbody2D;
    private Input_Actions _input;
    private PlayerMovement _playerMovement;
    private Animator _animator;

    public GameObject enemySpawner;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
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
            _animator.Play("Boc_Hurt");
            animationController.animationCooldown = Time.time + 0.3f;

        }
        if (playerHealth == 0)
        {
            playerIsDead = true;
            _input.enabled = false;
            _playerMovement.enabled = false;
            Destroy(enemySpawner);
            Destroy(bottomBorder);
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
