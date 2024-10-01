using UnityEngine;



public class PlayerCollision : MonoBehaviour
{
    public int playerHealth = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Halo")) return;
        playerHealth--;
        Destroy(other.gameObject);
    }
    
}
