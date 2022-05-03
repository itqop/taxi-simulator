using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject _StartMenu;
    public Text TimeStart;
    public float time;
    public Text highScore;

    private void Start()
    {
        time = 5;
        highScore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("score");
    }

    private void FixedUpdate()
    {
        if (!_StartMenu.activeSelf)
        {
            time -= Time.deltaTime;
            if (time > 0f)
            {
                time -= Time.deltaTime;
            }
            else
            {
                TimeStart.gameObject.SetActive(false);
                time = 0;
            }
            TimeStart.text = "TIMEtoSTART " + (int)time;
        }
    }

    public void ClickStart()
    {
        _StartMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
