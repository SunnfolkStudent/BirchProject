using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    //Horizontal Direction
    public Vector2 hDirection = Vector2.left;
    //Vertical Direction
    public Vector2 vDirection = Vector2.up;

    public GameObject body;

    void OnDestroy()
    {
        Instantiate(body, transform.position, Quaternion.identity);
    }
    
    void Update()
    {
        transform.Translate(hDirection * moveSpeed * Time.deltaTime);
        transform.Translate(vDirection * moveSpeed * Time.deltaTime);
    }
}
