using UnityEngine;
using System.Collections;
public class repeatingsounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip swooshSound;

    void Start()
    {
        // Call PlaySwooshSoundCoroutine to play the sound three times with a delay of 0.25 seconds.
        StartCoroutine(PlaySwooshSoundCoroutine());
    }

    IEnumerator PlaySwooshSoundCoroutine()
    {
        int numberOfSwooshes = 3;
        float delayBetweenSwooshes = 0.25f;

        for (int i = 0; i < numberOfSwooshes; i++)
        {
            audioSource.clip = swooshSound;
            audioSource.Play();

            // Wait for the specified delay before playing the sound again.
            yield return new WaitForSeconds(delayBetweenSwooshes);
        }
    }
}