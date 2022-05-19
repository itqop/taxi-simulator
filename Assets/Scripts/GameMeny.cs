using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMeny : MonoBehaviour
{
    public Button _contB;
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("FirstSave") > 0)
        {
            _contB.interactable = true;
        }

        if (PlayerPrefs.GetInt("FirstSave") == 0)
        {
            _contB.interactable = false;
        }
    }
    //! EXIT
    public void exit()
    {
        Application.Quit();
    }
    
    //! NEW GAME START
    public void NewGame()
    {
        PlayerPrefs.SetInt("FirstSave",0);
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }
    
    //! CONTINYE
    public void Contin()
    {
        PlayerPrefs.SetInt("load", 1);
        SceneManager.LoadScene(3);
    }
}
