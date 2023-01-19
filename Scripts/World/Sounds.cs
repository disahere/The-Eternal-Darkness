using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
  private AudioSource audioSource;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
    audioSource.Play(0);
    audioSource.Pause();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player")) 
    {
      audioSource.UnPause();
    }
  }
  

  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player")) 
    {
      audioSource.Pause();
    }
  }
}