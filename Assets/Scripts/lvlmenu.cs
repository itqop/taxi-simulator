using System;
using UnityEngine;

public class lvlmenu : MonoBehaviour
{
    public GameObject _menu;
    private bool check;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            check = !check;
            
            if (check)
            {
                _menu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (!check)
            {
                _menu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        
    }

    public void exit()
    {
        Application.Quit();
    }
}
