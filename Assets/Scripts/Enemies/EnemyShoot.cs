using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public Vector3 shootDirection;
    public float cooldown = 0.5f;
    private float cooldownCounter = 0f;
    
    public GameObject projectile;

    //Give projectile direction of shootDirection
    void Start()
    {
    }
    
    void Update()
    {
        if (cooldownCounter >= cooldown)
        {
            Instantiate(projectile, transform.position + shootDirection, transform.rotation);
            cooldownCounter = 0f;
        }
        cooldownCounter += Time.deltaTime;
    }
}
