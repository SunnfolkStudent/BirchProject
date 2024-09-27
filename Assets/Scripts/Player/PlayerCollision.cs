using UnityEngine;



public class PlayerCollision : MonoBehaviour
{
    public int playerHealth = 3;
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Player collision");
        playerHealth--;
        Destroy(other.gameObject);
    }
    
}
