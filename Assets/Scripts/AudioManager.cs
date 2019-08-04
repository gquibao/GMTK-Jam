using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource soundtrack;
    public AudioSource pMove;
    public AudioSource pClash;
    public AudioSource eMove;
    public AudioSource eClash;
    public AudioSource hit;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //soundtrack.volume = PlayerPrefs.GetFloat("Volume");
        pMove.volume = PlayerPrefs.GetFloat("Volume");
        pClash.volume = PlayerPrefs.GetFloat("Volume");
        eMove.volume = PlayerPrefs.GetFloat("Volume");
        eClash.volume = PlayerPrefs.GetFloat("Volume");
        hit.volume = PlayerPrefs.GetFloat("Volume");
    }
}
