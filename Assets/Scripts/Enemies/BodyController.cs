using UnityEngine;
public class DevilBodyController : MonoBehaviour
{
    public float deathTime = 3f;

    // Update is called once per frame
    void Update()
    {
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
