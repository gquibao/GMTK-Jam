using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
}
