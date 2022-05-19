using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//! MAGAZIN MANAGER
public class Shop : MonoBehaviour
{

    public Stats _stats;
    public DonDestroyOnLoAD _donDestroy;
    public Button[] buttons;

    public UiNavTablet _nav;

    public Image _navImg;
    // Update is called once per frame

    private void Start()
    {
        _donDestroy = GameObject.Find("DonDestroyOnLoAD").GetComponent<DonDestroyOnLoAD>();
    }

    void Update()
    {
        if (_stats.Money >= 1500)
        {
            if(_donDestroy.checkCar == 0)
                buttons[0].interactable = true;
        }else
        {
            buttons[0].interactable = false;
            if (_donDestroy.checkCar != 0)
            {
                Image bg = buttons[0].GetComponent<Image>();
                bg.color = Color.green;
            }
        }

        if (_stats.Money >= 3000)
        {
            if(_donDestroy.checkCar <= 1)
                buttons[1].interactable = true;
        }
        else
        {
            buttons[1].interactable = false;
            if (_donDestroy.checkCar == 2)
            {
                Image bg = buttons[1].GetComponent<Image>();
                bg.color = Color.green;
            }
        }

        if (_nav.dist <= 30)
        {
            _navImg.gameObject.SetActive(false);
        }
    }

    public void clicktobuy()
    {
        if (_stats.Money >= 1500)
        {
            Image bg = buttons[0].GetComponent<Image>();
            buttons[0].interactable = false;
            bg.color = Color.green;
            _donDestroy.checkCar = 1;
            _stats.Money -= 1500;
        }
    }
    public void clicktobuy2()
    {
        if (_stats.Money >= 3000)
        {
            Image bg = buttons[1].GetComponent<Image>();
            buttons[1].interactable = false;
            bg.color = Color.green;
            _donDestroy.checkCar = 2;
            _stats.Money -= 3000;
        }
    }

    public void roatToGarage()
    {
        _nav.target = GameObject.FindWithTag("garage").transform;
        _navImg.gameObject.SetActive(true);
    }
    public void roatToGas()
    {
        _nav.target = GameObject.FindWithTag("gas").transform;
        _navImg.gameObject.SetActive(true);
    }
    public void teleportToGas()
    {
        _stats.Money -= 100;
        GameObject.Find("Car").transform.position = GameObject.FindWithTag("gas").transform.position;
    }
}
