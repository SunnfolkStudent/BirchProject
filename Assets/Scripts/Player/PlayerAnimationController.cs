using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator _animator;

    public float animationCooldown = 0;

    private Input_Actions _input;
    private Vector2 _previousShootDirection;

    void Start()
    {
        _input = GetComponent<Input_Actions>();
        _animator = GetComponent<Animator>();
    }

    private void UpdateAnimation()
    {
        if (_input.Throw)
        {
            //Half Second cooldown on attacks
            animationCooldown = Time.time + 0.5f;

            if (_input.MoveDirection == Vector2.zero)
            {
                if (_previousShootDirection == Vector2.up)
                {
                    _animator.Play("Boc_Up_Throw");
                }
                else if (_previousShootDirection == Vector2.down)
                {
                    _animator.Play("Boc_Down_Throw");
                }
                else
                {
                    _animator.Play("Boc_Side_Throw");
                }
            }
            else
            {
                if (_input.MoveDirection.y > 0)
                {
                    _animator.Play("Boc_Up_Throw");
                    _previousShootDirection = Vector2.up;
                }
                else if (_input.MoveDirection.y < 0)
                {
                    _animator.Play("Boc_Down_Throw");
                    _previousShootDirection = Vector2.down;
                }
                else
                {
                    _animator.Play("Boc_Side_Throw");
                    _previousShootDirection = Vector2.right;
                }
            }
        }
        else
        {
            _animator.Play("Boc_Flying");
        }
    }

    void Update()
    {
        if (Time.time > animationCooldown)
        {
            UpdateAnimation();
        }
    }
}