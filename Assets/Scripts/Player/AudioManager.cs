using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
   private AudioSource _audioSource;

   public AudioClip[] musicClips;

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
   }

   private void Update()
   {
      UpdateMusic(Time.time);
   }

   void UpdateMusic(float time)
   {
      if (time < 78 && _audioSource.clip != musicClips[0])
      {
         _audioSource.clip = musicClips[0];
         _audioSource.Play();
      }
     else if (time > 78 && _audioSource.clip == musicClips[0])
     {
        _audioSource.clip = musicClips[1];
        _audioSource.loop = false;
        _audioSource.Play();
        _audioSource.volume += 0.1f;
     }
      else if(_audioSource.isPlaying == false)
      {
           _audioSource.clip = musicClips[2];
           _audioSource.loop = true;
           _audioSource.Play();
           _audioSource.volume -= 0.1f;
      }
   }
}
