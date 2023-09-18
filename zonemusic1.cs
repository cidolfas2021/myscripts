using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this is a client side process
/// </summary>

public class zonemusic1 : MonoBehaviour
{ 
public audiomaster audiomaster;
public AudioClip clip1;


void OnTriggerEnter(Collider other)
{
        if (other.CompareTag("Player"))
        {
            audiomaster.play(clip1);  //from audiomaster
            Debug.Log("you entered the collider, somehow");
        }

}

void OnTriggerExit(Collider other)
{
        if (other.CompareTag("Player"))
        {
            audiomaster.stop();
        }
    }
}



