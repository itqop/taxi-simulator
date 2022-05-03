using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject pause;

    public float time;

    public Text resum;

    public StartGame _Start;

    private void Start()
    {
        _Start = GetComponent<StartGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (_Start.time == 0)
            {
                if (!pause.activeSelf)
                {
                    pause.SetActive(true);
                    time = 3f;
                }
                else
                {
                    pause.SetActive(false);
                    resum.gameObject.SetActive(true);
                } 
            }
        }
        if (!pause.activeSelf)
        { 
            time -= Time.deltaTime;
            resum.text = "RESUME " + (int)time;
            if (time <= 0)
            {
                time = 0;
                resum.gameObject.SetActive(false);
            } 
        }
        
    }
}
