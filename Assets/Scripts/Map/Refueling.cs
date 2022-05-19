using System;
using UnityEngine;
using UnityEngine.UI;

public class Refueling : MonoBehaviour
{
    public GameObject _bg;
    public Stats _stats;
    public Cont _cont;
    public float FuelPrice;

    private void Update()
    {
        _cont = GameObject.Find("Car").GetComponent<Cont>();
        if (_bg.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _bg.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cont.checkEvents = true;
    }

    public void ConfirmRefueling()
    {
        _stats.CurrentFuel = 1;
        _bg.SetActive(false);
        _cont.checkEvents = false;
        _stats.Money = Mathf.Round((_stats.Money - (FuelPrice/2)) * 100) / 100;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Denie()
    {
        _bg.SetActive(false);
        _cont.checkEvents = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
