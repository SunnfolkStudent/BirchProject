using UnityEngine;

public class KillBoxController : MonoBehaviour
{
    [Header("Audio")]
    
    public AudioClip[] enemyDeath;
    public AudioClip haloHit;
    //public AudioClip[] coolLineSound;
    
    [Space(5)] 
  
    private AudioSource _audioSource;
    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource = GetComponent<AudioSource>();
        //if other object is a killbox
        if (other.gameObject.CompareTag("KillBox"))
        {
            Destroy(this.gameObject);
        }
        // If other object is an Enemy
        
        if (other.gameObject.layer == 3)
        {
            AudioSource.PlayClipAtPoint(haloHit, transform.position);
            //_audioSource.PlayOneShot(haloHit);
            AudioSource.PlayClipAtPoint(enemyDeath[Random.Range(0, enemyDeath.Length)], transform.position);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            
        }
    }
    
}
