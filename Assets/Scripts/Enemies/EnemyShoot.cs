using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public Vector3 shootDirection;
    public float cooldown = 0.5f;
    private float cooldownCounter = 0f;
    private float shootSpeed = 5f;
    
    public GameObject projectile;
    
    void Update()
    {
        if (cooldownCounter >= cooldown)
        {
            var projectileClone = Instantiate(projectile, transform.position + shootDirection/2, transform.rotation);
            projectileClone.GetComponent<Rigidbody2D>().linearVelocity =
                shootDirection * shootSpeed;
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                projectileClone.GetComponent<SpriteRenderer>().flipX = true;
            }
            cooldownCounter = 0f;
        }
        cooldownCounter += Time.deltaTime;
    }
}
