using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    private static GamePanel instance;
    public static GamePanel Instance
    {
        get
        {
            return instance;
        }
    }
    public TextMeshProUGUI countdown;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI hp;
    public Slider hpSlider;
    public TextMeshProUGUI exp;
    public Slider expSlider;
    public TextMeshProUGUI money;

    public GameObject successPanel;
    public GameObject losePanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateHp();
        UpdateExp();
        UpdateMoney();
        UpdateWave((int)LevelManager.Instance.waveTimer);
    }

    private void OnEnable()
    {
        PlayerController.PlayerHurt += UpdateHp;
    }

    private void OnDisable()
    {
        PlayerController.PlayerHurt -= UpdateHp;
    }

    public void UpdateHp()
    {
        hp.text = PlayerController.Instance.currentHp + "/" + PlayerController.Instance.maxHp;
        hpSlider.value = (float)PlayerController.Instance.currentHp / PlayerController.Instance.maxHp;
    }

    public void UpdateExp()
    {
        int level = (int)(PlayerController.Instance.exp / 12);
        exp.text = level.ToString();
        expSlider.value = (float)(PlayerController.Instance.exp % 12)/12;
    }

    public void UpdateMoney()
    {
        money.text = PlayerController.Instance.money.ToString();
    }

    public void UpdateWave(int waveTime)
    {
        wave.text = "第"+GameManager.Instance.currentWave.ToString()+"波";
        countdown.text = waveTime.ToString();
    }

    public void SuccessGame()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        successPanel.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(loadMenuScene());
    }

    public void LoseGame()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        losePanel.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(loadMenuScene());
    }

    //加载到菜单
    IEnumerator loadMenuScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
