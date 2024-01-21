using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    //public AudioSource source1;
    public AudioManager source;
    public AudioClip[] clip;

    private void Start()
    {
        //source1 = GetComponent<AudioSource>();

        source.Play("BGM1");
        //source.PlayOneShot(clip[0]);
        DontDestroyOnLoad(gameObject);
    }

    public void Bgm1()
    {
        source.Play("BGM1");
        //source.PlayOneShot(clip[0]);

    }

    public void Bgm2()
    {
        source.Play("BGM2");;
        //source.PlayOneShot(clip[1]);
    }

    public void Bgm3()
    {
        source.Play("BGM3");
        //source.PlayOneShot(clip[2]);
    }
}
