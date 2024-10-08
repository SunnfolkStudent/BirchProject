using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    //Horizontal Direction
    public Vector2 direction;

    public GameObject body;

    private bool leaveBody = true;

    void OnApplicationQuit()
    {
        leaveBody = false;
    }
    
    void OnDestroy()
    {
        if (leaveBody)
        {
            Instantiate(body, transform.position, Quaternion.identity);
        }
    }
    
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}
