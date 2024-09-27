using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    //Horizontal Direction
    public Vector3 hDirection = Vector3.left;
    //Vertical Direction
    public Vector3 vDirection = Vector3.up;

    void Update()
    {
        transform.Translate(hDirection * moveSpeed * Time.deltaTime);
        transform.Translate(vDirection * moveSpeed * Time.deltaTime);
    }
}
