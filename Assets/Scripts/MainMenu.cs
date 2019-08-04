using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
    public GameObject loadingScreen;
    public Slider volumeSlider;
    public float volumeValue;
    public TextMeshProUGUI txtLoading;

    public AudioSource soundtrack;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
            volumeValue = PlayerPrefs.GetFloat("Volume");

        else
            PlayerPrefs.SetFloat("Volume", 1);

        volumeSlider.value = volumeValue;
        soundtrack.volume = volumeValue;

        loadingScreen.SetActive(false);
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
        StartCoroutine(LoadNewScene("Samurai_Arena"));
    }

    public void btCangaceiro()
    {
        StartCoroutine(LoadNewScene("Cangaceiro_Arena"));
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation operation = new AsyncOperation();
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            loadingScreen.SetActive(true);
            txtLoading.text = "Loading";
            for (int i = 0; i < 3; i++)
            {
                txtLoading.text += ".";
                yield return new WaitForSeconds(0.5f);
            }
        }

        for (int i = 5; i >= 0; i--)
        {
            yield return new WaitForSeconds(1);
            txtLoading.text = i.ToString();
        }
        operation.allowSceneActivation = true;
    }
}
