using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SendToStart());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("StartMenuScene");
    }
    
}
