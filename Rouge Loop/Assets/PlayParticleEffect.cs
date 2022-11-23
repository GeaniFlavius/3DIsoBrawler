using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleEffect : MonoBehaviour
{
    public ParticleSystem particle;

    public  void PlayParticle()
    {
        particle.Play();
    }

    public void StopParticle()
    {
        particle.Stop();
        
    }
}
