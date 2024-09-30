using UnityEngine;

public class KillBoxController : MonoBehaviour
{
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
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
