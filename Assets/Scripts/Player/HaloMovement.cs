using UnityEngine;

public class HaloMovement : MonoBehaviour
{
    public float moveSpeed = -10f;
    public float despawnTime = 5f;
    
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, despawnTime);
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocityX = moveSpeed;
    }
}
