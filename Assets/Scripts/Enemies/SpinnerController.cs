using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float rotationSpeed = 10f;
    //Horizontal Direction
    public Vector2 hDirection = Vector2.left;
    //Vertical Direction
    public Vector2 vDirection = Vector2.up;
    //Direction of Rotation
    public Vector3 rDirection = Vector3.forward;

    void Update()
    {
        transform.Translate(hDirection * moveSpeed * Time.deltaTime);
        transform.Translate(vDirection * moveSpeed * Time.deltaTime);
        transform.Rotate(rDirection * rotationSpeed * Time.deltaTime);
    }
}