using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip sparkleSound;
    public AudioClip victoryMusic;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(victoryMusic);
        StartCoroutine(StartSparkle());
        StartCoroutine(SendToStart());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(12.5f);
        SceneManager.LoadScene("StartMenuScene");
    }
    
    private IEnumerator StartSparkle()
    {
        yield return new WaitForSeconds(2.5f);
        _audioSource.clip = sparkleSound;
        _audioSource.loop = true;
        _audioSource.Play();
        
    }
    
}
