using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;

    private Input_Actions _input;
    private Rigidbody2D _rigidbody2D;

    public GameObject halo;
    public Transform haloSpawn;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Actions>();
    }


    void Update()
    {
        if (_input.Throw)
        {
            Instantiate(halo, haloSpawn.position, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        //_rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
        //_rigidbody2D.linearVelocityY = _input.Vertical * moveSpeed;
        _rigidbody2D.linearVelocity = _input.moveDirection * moveSpeed;
    }
}
