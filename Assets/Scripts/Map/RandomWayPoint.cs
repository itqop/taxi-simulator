using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


//! RANDOMIZATSIA TO4EK 
public class RandomWayPoint : MonoBehaviour
{
    public GameObject[] AllPoints;
    public GameObject[] Points;
    public List<int> randomList = new List<int>();
    public WayPointUI _wayPointUI;

    private void Start()
    {
        _wayPointUI = GameObject.Find("Main Camera").GetComponent<WayPointUI>();
    }

    public void randomPoints()
    {
        for (; randomList.Count < 2;)
        {
            var random = Random.Range(0, AllPoints.Length - 1);
            if (!randomList.Contains(random))
            {
                randomList.Add(random); 
            }
        }
        
        Points[0] = AllPoints[randomList[0]];
        Points[1] = AllPoints[randomList[1]];
        randomList.Clear();
        Points[0].gameObject.SetActive(true);
        _wayPointUI.target = Points[0].gameObject.transform;
        _wayPointUI.img.gameObject.SetActive(true);
    }
}
