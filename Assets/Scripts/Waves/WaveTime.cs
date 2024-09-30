using UnityEngine;

public class WaveTime : MonoBehaviour
{
    public float waveTime;
    private float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waveTime)
        {
            Destroy(this.gameObject);
        }
    }
}
