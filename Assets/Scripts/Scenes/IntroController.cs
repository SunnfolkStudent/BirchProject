using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SendToStart());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainScene");
    }
    
}
