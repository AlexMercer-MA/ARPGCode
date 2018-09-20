
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static PlayerAudio GetInstance;

    public AudioSource runAudioSource;
    public AudioSource dieAudioSource;
    public AudioSource whooshAudioSource;
    public AudioSource hitAudioSource;
    public AudioSource crashAudioSource;
    public AudioSource jumpAudioSource;
    public AudioSource landAudioSource;

    void Awake()
    {
        GetInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActorProperty.GetInstance.IsDead)
        {
            return;
        }

        if (CharacterBehaviour.GetInstace.anim.GetFloat("fSpeed") > 2.5f && CharacterBehaviour.GetInstace.anim.GetBool("isGrounded") && !CharacterBehaviour.GetInstace.bInAction && !runAudioSource.isPlaying)
        {
            runAudioSource.Play();
        }

        if (CharacterBehaviour.GetInstace.anim.GetFloat("fSpeed") < 2.5f || !CharacterBehaviour.GetInstace.anim.GetBool("isGrounded") || CharacterBehaviour.GetInstace.bInAction)
        {
            runAudioSource.Stop();
        }
    }

    public void Die()
    {
        dieAudioSource.Play();
    }

    public void Whoosh()
    {
        whooshAudioSource.pitch = Random.Range(0.9f, 1.1f);
        whooshAudioSource.Play();
    }

    public void Hit()
    {
        hitAudioSource.pitch = Random.Range(0.9f, 1.1f);
        hitAudioSource.Play();
    }

    public void Crash()
    {
        crashAudioSource.Play();
    }

    public void Jump()
    {
        jumpAudioSource.Play();
    }

    public void Land()
    {
        landAudioSource.Play();
    }
}
