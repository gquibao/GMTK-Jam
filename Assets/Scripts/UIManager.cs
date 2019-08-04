using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image gameOver;
    public Sprite victory;
    public Sprite defeat;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOver.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            returnToMenu();
        }
    }

    public void returnToMenu()
    {
        StartCoroutine(loadMenu());
    }

    public IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
