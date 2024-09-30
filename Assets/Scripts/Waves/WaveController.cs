using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public GameObject[] myWaves;
    public int waveNum = 1;
    public GameObject currentWave;

    private void CreateNewWave()
    {
        waveNum++;
        currentWave = myWaves[waveNum - 1];
        Instantiate(currentWave, transform.position, Quaternion.identity, this.gameObject.transform);
        print(currentWave);
    }
    
    
    void Start()
    {
        CreateNewWave();
        print("Instant");
    }

    void Update()
    {
        if (this.transform.childCount == 0 && waveNum <= myWaves.Length)
        {
            CreateNewWave();
        }
    }

}
