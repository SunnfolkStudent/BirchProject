using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioClip VictoryMusic;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(VictoryMusic);
        StartCoroutine(SendToStart());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene("StartMenuScene");
    }
    
}
