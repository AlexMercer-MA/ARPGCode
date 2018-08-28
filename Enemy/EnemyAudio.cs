using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource attackAudioSource;
    public AudioSource hitAudioSource;
    public AudioSource dieAudioSource;

    public void Die()
    {
        dieAudioSource.Play();
    }

    public void Attack()
    {
        attackAudioSource.Play();
    }

    public void Hit()
    {
        hitAudioSource.Play();
    }
}
