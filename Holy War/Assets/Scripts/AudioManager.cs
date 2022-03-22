using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sfx;
    public AudioSource[] audioSource;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    public void audioShoot()
    {
        audioSource[1].PlayOneShot(sfx[2]);
    }
    public void audioDead()
    {
        audioSource[1].PlayOneShot(sfx[0]);
    }
    public void audioSupplie()
    {
        audioSource[1].PlayOneShot(sfx[1]);
    }
    public void audioShoot2()
    {
        audioSource[1].PlayOneShot(sfx[3]);
    }

    
}
