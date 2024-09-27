using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    //Horizontal Direction
    public Vector3 hDirection = Vector3.left;
    //Vertical Direction
    public Vector3 vDirection = Vector3.up;

    private void OnCollisionEnter2D(Collision2D Border)
    {
        if (Border.gameObject.CompareTag("ScreenBorder"))
        {
            vDirection = vDirection * -1;
        }
    }

    void Update()
    {
        transform.Translate(hDirection * moveSpeed * Time.deltaTime);
        transform.Translate(vDirection * moveSpeed * Time.deltaTime);
    }
}
