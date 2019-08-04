using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public Slider volumeSlider;
    public float volumeValue;

    public AudioSource soundtrack;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
            volumeValue = PlayerPrefs.GetFloat("Volume");

        else
            PlayerPrefs.SetFloat("Volume", 1);

        volumeSlider.value = volumeValue;
        soundtrack.volume = volumeValue;
    }

    public void btPlay()
    {
        anim.SetTrigger("play");
    }

    public void btCredits()
    {
        anim.SetBool("credits", !anim.GetBool("credits"));
    }

    public void btConfig()
    {
        anim.SetBool("config", !anim.GetBool("config"));
    }

    public void changeVolume()
    {
        volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        soundtrack.volume = volumeValue;
    }

    public void btExit()
    {
        Application.Quit();
    }

    public void btSamurai()
    {
        SceneManager.LoadScene("LevelSamurai");
    }

    public void btCangaceiro()
    {
        SceneManager.LoadScene("LevelCangaceiro");
    }
}
