using System;
using UnityEngine;


//! ZDES YPRAVLENIE SVETOFOROM
public class TrafficLight : MonoBehaviour
{
    public bool trafficLight;

    public bool noPed;

    [SerializeField] private float timer;

    public WayPoint[] _stopPid;

    public bool fastrun;
    void Start()
    {
        timer = 10;
    }

    private void FixedUpdate()
    {
        TimerChangeLight();
    }

    private void TimerChangeLight()
    {
        if (!trafficLight)
        {
            timer -= Time.deltaTime;
            _stopPid[0].branchRatio = 0.5f;
            _stopPid[1].branchRatio = 0.5f;
            if (timer <= 0)
            {
                _stopPid[0].branchRatio = 0f;
                _stopPid[1].branchRatio = 0f;
                if (!noPed)
                {
                    trafficLight = true;
                    timer = 15;
                }
                
            }
        }

        if (trafficLight)
        {
            timer -= Time.deltaTime;
            _stopPid[0].branchRatio = 0;
            _stopPid[1].branchRatio = 0;
            if (timer <= 0)
            {
                trafficLight = false;
                timer = 10;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "pedestrian")
        {
            noPed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "pedestrian")
        {
            noPed = false;
        }
    }
}
