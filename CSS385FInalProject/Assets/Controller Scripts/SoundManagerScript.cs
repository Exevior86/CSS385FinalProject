using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip sound;
    static AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public static void PlaySound(string soundToLoad)
    {
        sound = Resources.Load<AudioClip>(soundToLoad);
        source.PlayOneShot(sound);
    }
}
