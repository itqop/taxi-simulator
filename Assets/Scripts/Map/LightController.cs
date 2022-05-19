using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Cont _cont;
    public Light Rlight, Llight,BRlight, BLlight;
    public bool TurnOn;
    private void Start()
    {
        _cont = GetComponent<Cont>();
        TurnOn = false;
    }
    //! turn on light
    private void Update()
    {
        if (Input.GetButtonUp("TurnOnLight"))
        {
            TurnOn = !TurnOn;
        }
        Light();
    }
    //! intensity light
    void Light()
    {
        if (!_cont.startCar)
        {
            Rlight.intensity = 0;
            Llight.intensity = 0;
            BRlight.intensity = 0;
            BLlight.intensity = 0;
        }
        else
        {
            if (_cont.StopLightIntens)
            {
                BRlight.intensity = 100;
                BLlight.intensity = 100;
            }else if (TurnOn)
            {
               Rlight.intensity = 15;
               Llight.intensity = 15;
               BRlight.intensity = 55;
               BLlight.intensity = 55;
            }
            if (!TurnOn && !_cont.StopLightIntens)
            {
                Rlight.intensity = 0;
                Llight.intensity = 0;
                BRlight.intensity = 0;
                BLlight.intensity = 0;
            }
        }
    }
}
