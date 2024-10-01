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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
