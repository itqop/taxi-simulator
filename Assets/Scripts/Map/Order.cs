using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


//!  ACTIVATIA ZAKAZA
public class Order : MonoBehaviour
{

    public RandomWayPoint _wayPoint;
    public OrderTaxi _order;
    public Stats _stats;
    public Text _timer;
    private float time;
    private void Start()
    {
        _wayPoint = GameObject.Find("GameManager").GetComponent<RandomWayPoint>();
        _order = GameObject.Find("GameManager").GetComponent<OrderTaxi>();
        _stats = GameObject.Find("GameManager").GetComponent<Stats>();
        _timer = GameObject.Find("TimerForOrder").transform.GetChild(0).GetComponent<Text>();
        time = Random.Range(60,90);
    }

    private void FixedUpdate()
    {
        if (_order.AcceptOrder)
        {
            _timer.gameObject.SetActive(true);
            time -= Time.deltaTime;
            _timer.text = "TIME LEFT: " + (int)time;
        }

        if (time < 0)
        {
            _timer.gameObject.SetActive(false);
            _order.AcceptOrder = false;
            _wayPoint.Points[0].gameObject.SetActive(false);
            _wayPoint.Points[1].gameObject.SetActive(false);
            _wayPoint._wayPointUI.img.gameObject.SetActive(false);
            time = Random.Range(60,90);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_order.AcceptOrder)
        {
            if (other.name == _wayPoint.Points[0].name)
            {
                //change waypoint
                _wayPoint.Points[0].gameObject.SetActive(false);
                _wayPoint.Points[1].gameObject.SetActive(true);
                _wayPoint._wayPointUI.target = _wayPoint.Points[1].transform;
            }
            if (other.name == _wayPoint.Points[1].name)
            {
                if (_order.AcceptOrder)
                {
                    _order.AcceptOrder = false;
                    _stats.Money += _order.price;
                    time = Random.Range(60,90);
                    _timer.gameObject.SetActive(false);
                    _wayPoint.Points[1].gameObject.SetActive(false);
                    _wayPoint._wayPointUI.img.gameObject.SetActive(false);
                    _order.timeLeft = -1;
                }
            }
        }
        
    }

    
}
