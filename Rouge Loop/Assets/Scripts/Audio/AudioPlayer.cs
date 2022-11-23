using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlaySound(string path)
    {
        // Paths are found in the FMOD Event Browser.
        // Plays the sound the Components Position
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
