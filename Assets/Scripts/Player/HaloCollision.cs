using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class KillBoxController : MonoBehaviour
{
    [Header("Audio")]
    
    public AudioClip[] enemyDeath;
    public AudioClip haloHit;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if other object is a killbox
        if (other.gameObject.CompareTag("KillBox"))
        {
            Destroy(this.gameObject);
        }
        // If other object is an Enemy
        
        if (other.gameObject.layer == 3)
        {
            AudioSource.PlayClipAtPoint(haloHit, transform.position);
            StartCoroutine(nameof(PlayAudio));
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.15f);
            _spriteRenderer.enabled = false;
            _collider2D.enabled = false;
            PlayerMovement.enemyDeathCounter++;
        }
    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(0.1f);
        AudioSource.PlayClipAtPoint(enemyDeath[Random.Range(0, enemyDeath.Length)], transform.position);
    }
}
