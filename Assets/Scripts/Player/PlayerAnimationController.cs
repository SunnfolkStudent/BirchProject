using UnityEngine;


public class BocAnimationController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Animator _animator;
    
    private void UpdateAnimation()
    {
        if (rb2D.linearVelocity == Vector2.zero)
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
        UpdateAnimation();
    }
}
