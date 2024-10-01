using UnityEngine;

public class HaloMovement : MonoBehaviour
{
    public float moveSpeed = -10f;
    public float despawnTime = 5f;
    
    private Rigidbody2D _rigidbody2D;
    private Transform _transform;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        Destroy(gameObject, despawnTime);
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
        if (_rigidbody2D.linearVelocityY > _rigidbody2D.linearVelocityX)
        {
            _transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            print("Halo");
        }
    }
}
