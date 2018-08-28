using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectionAudio : MonoBehaviour
{
    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    public void Hit()
    {
        Debug.Log("FireBallHit");
        audioSource.Play();
    }
}
