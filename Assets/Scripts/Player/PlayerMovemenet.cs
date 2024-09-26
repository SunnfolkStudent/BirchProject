using UnityEngine;

public class PlayerMovemenet : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    private Transform _transform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
