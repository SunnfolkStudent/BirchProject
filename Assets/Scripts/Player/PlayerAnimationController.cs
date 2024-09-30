using UnityEngine;


public class BocAnimationController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator _animator;

    private float animationCooldown = 0;
    
    private Input_Actions _input;

    void Start()
    {
        _input = GetComponent<Input_Actions>();
    }
    
    private void UpdateAnimation()
    {
        if (_input.Throw)
        {
            print(rb2D.linearVelocityY);
            print(Vector2.zero.y);
            animationCooldown = Time.time + 0.5f;
            
            if (rb2D.linearVelocityY > Vector2.zero.y)
            {
                _animator.Play("Boc_Up_Throw");
                print("Boc_Up_Throw");
            }

            else if (rb2D.linearVelocityY < Vector2.zero.y)
            {
                _animator.Play("Boc_Down_Throw");
            }
            else
            {
                _animator.Play("Boc_Side_Throw");
            }
        }
        else if (rb2D.linearVelocity == Vector2.zero)
        {
            _animator.Play("Boc_Idle");
        }
        else
        {
            _animator.Play("Boc_Flying");
        }
    }

    void Update()
    {
        if (Time.time >= animationCooldown)
        {
            UpdateAnimation();
        }
    }
}
