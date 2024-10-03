using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    private AudioSource _audioSource;

    public AudioClip introLine;
    public AudioClip introMusic;
    public AudioClip fireSound;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.PlayOneShot(introLine);
        _audioSource.PlayOneShot(introMusic);
        StartCoroutine(SendToStart());
        StartCoroutine(FireSounds());
    }

    private IEnumerator SendToStart()
    {
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene("MainScene");
    }
    private IEnumerator FireSounds()
    {
        yield return new WaitForSeconds(4.5f);
        _audioSource.PlayOneShot(fireSound);
    }
}
