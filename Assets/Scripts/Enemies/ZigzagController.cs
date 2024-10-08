using UnityEngine;

public class ZigzagController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    //Horizontal Direction
    public Vector3 hDirection = Vector3.left;
    //Vertical Direction
    public Vector3 vDirection = Vector3.up;
    
    public GameObject body;

    private void OnTriggerEnter2D(Collider2D border)
    {
        if (border.gameObject.CompareTag("ScreenBorder"))
        {
            vDirection = vDirection * -1;
        }
    }
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