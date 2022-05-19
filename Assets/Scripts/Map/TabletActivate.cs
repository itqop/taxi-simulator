using System;
using UnityEngine;
using UnityEngine.SceneManagement;


//! vklutenie telefona 
public class TabletActivate : MonoBehaviour
{
    [Header("TabletUI")]
    public GameObject _tablet;

    private bool checkShop;
    
    private void Awake()
    {
        
        checkShop = false;
    }

    private void Update()
    {   if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            if (Input.GetButtonUp("Shop"))
            {
                checkShop = !checkShop;
                if (!checkShop)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }

            
            if (checkShop)
            {
                _tablet.SetActive(true);
            }
            
            if (!checkShop)
            {
                _tablet.SetActive(false);
            }
        } 
    }
}
