using System;
using UnityEngine;
public class Shoot : MonoBehaviour
{
    public GameObject[] pref;
    public GameObject[] StartPos;
    public float kd;
    public Progress _Progress;
    public GameObject RoketPlace;
    public GameObject LaserPlace;
    public float kd2;
    public float kd3;
    public GameObject Shield;
    public PauseMenu _Pause;
    public float kdShield;
    private void Start()
    {
        kd = 2;
        kd2 = 2;
        kd3 = 5;
    }

    void Update()
    {
        if (_Pause.time == 0)
        {
            kd2 -= Time.deltaTime;

            if (_Progress.PrefLvl >= 5)
            {
                RoketPlace.SetActive(true);
                if (kd2 <= 0)
                {
                    Rakera();
                    kd2 = 2;
                }
            }
            
            if(_Progress.PrefLvl < 5)
            {
                RoketPlace.SetActive(false);
            }
                    
            if (_Progress.PrefLvl >= 10)
            {
                LaserPlace.SetActive(true);
                if (kd2 <= 0)
                {
                    Rakera2();
                }
            }
            if (_Progress.PrefLvl < 10)
            {
                LaserPlace.SetActive(false);
            }
            
            if (_Progress.PrefLvl >= 15)
            {
                if (kd3 == 5)
                {
                    Shield.SetActive(true);
                }
                Shield.transform.RotateAround(gameObject.transform.position, Vector3.forward, 5);
            }
            if (_Progress.PrefLvl < 15)
            {
                Shield.SetActive(false);
            }
            
            if (!Shield.activeSelf & _Progress.PrefLvl >= 15)
            {
                kdShield -= Time.deltaTime;
                if (kd3 <= 0)
                {
                    Shield.SetActive(true);
                    kd3 = 5;
                }
            }
            kd -= Time.deltaTime;
        }
    }
    void Rakera()
    {
        GameObject bult = Instantiate(pref[1],StartPos[1].transform.position,StartPos[1].transform.rotation);
        bult.name = "Raketa";
    }
    void Rakera2()
    {
        GameObject bult2 = Instantiate(pref[1],StartPos[2].transform.position,StartPos[2].transform.rotation);
        bult2.name = "Raketa";
    }
    
}
