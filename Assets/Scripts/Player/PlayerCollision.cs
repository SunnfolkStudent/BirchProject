using Unity.VisualScripting;
using UnityEngine;



public class PlayerCollision : MonoBehaviour
{
    public int playerHealth = 3;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerHealth--;
        Destroy(other.gameObject);
    }
    
}
