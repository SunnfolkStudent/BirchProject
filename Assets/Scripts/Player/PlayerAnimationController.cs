using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    public float animationCooldown;
    public static Vector2 PreviousShootDirection;

    private static readonly int ThrowUp = Animator.StringToHash("Boc_Up_Throw");
    private static readonly int ThrowDown = Animator.StringToHash("Boc_Down_Throw");
    private static readonly int ThrowSide = Animator.StringToHash("Boc_Side_Throw");
    private static readonly int Fly = Animator.StringToHash("Boc_Flying");

    private Animator _animator;
    private Input_Actions _input;

    private void Start()
    {
        _input = GetComponent<Input_Actions>();
        _animator = GetComponent<Animator>();

        if (PreviousShootDirection == Vector2.zero)
        {
            PreviousShootDirection.x = 1;
        }
    }

    private void UpdateAnimation()
    {
        if (animationCooldown > Time.time) return;

        if (_input.Throw)
        {
            if (_input.MoveDirection == Vector2.zero)
            {
                if (PreviousShootDirection == Vector2.up)
                {
                    _animator.Play(ThrowUp);
                }
                else if (PreviousShootDirection == Vector2.down)
                {
                    _animator.Play(ThrowDown);
                }
                else
                {
                    _animator.Play(ThrowSide);
                }
            }
            else
            {
                PreviousShootDirection = _input.MoveDirection;

                if (_input.MoveDirection == Vector2.up)
                {
                    _animator.Play(ThrowUp);
                }
                else if (_input.MoveDirection == Vector2.down)
                {
                    _animator.Play(ThrowDown);
                }
                else
                {
                    _animator.Play(ThrowSide);
                }
            }
            animationCooldown = Time.time + 0.5f;
        }
        else
        {
            _animator.Play(Fly);
        }
    }

    private void Update()
    {
        UpdateAnimation();
    }
}