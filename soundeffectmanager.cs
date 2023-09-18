using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundeffectmanager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip secondClip;
    private float newStartTime = 0.65f; // Set the new start time in seconds.

    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        StartCoroutine(PlaySecondClipDelayed(0.75f));
    }

    IEnumerator PlaySecondClipDelayed(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.clip = secondClip;
        audioSource.time = newStartTime;
        audioSource.Play();
    }

    // You can call this function to change the start time at any point in your game.
    void ChangeStartTime(float startTime)
    {
        newStartTime = startTime;
        audioSource.time = newStartTime;
    }
}