using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AcceptOrder : MonoBehaviour
{
    public RandomWayPoint _wayPoint;
    public OrderTaxi _orderTaxi;
    public Button _button;
    
    private void Start()
    {
        _button = GetComponent<Button>();
        _orderTaxi = GameObject.Find("GameManager").GetComponent<OrderTaxi>();
        _wayPoint = GameObject.Find("GameManager").GetComponent<RandomWayPoint>();
        _button.onClick.AddListener(ConfirmOrder);
    }

    public void ConfirmOrder()
    {
        _orderTaxi.AcceptOrder = true;
        _button.interactable = false;
        //start waypoint activate
        _wayPoint.randomPoints();
    }
}
