using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioClip IntroMusic;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(IntroMusic);
        StartCoroutine(SendToStart());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainScene");
    }
    
}
