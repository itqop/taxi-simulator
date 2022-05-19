using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarAI : MonoBehaviour
{
    [SerializeField]
    private List<Vector3> path = null;
    [SerializeField]
    private float arriveDistance = .3f, lastpoint = .1f;
    [SerializeField]
    private float turningAngleOffset = 5;
    [SerializeField]
    private Vector3 currentTargetPos;

    private int index = 0;

    private bool stop;

    public bool Stop
    {
        get { return stop;}
        set { stop = value; }
    }
    
    [field: SerializeField]
    public UnityEvent<Vector2> OnDrive { get; set; }

    private void Start()
    {
        if (path == null || path.Count == 0)
        {
            Stop = true;
        }else
        {
            currentTargetPos = path[index];
        }
    }

    public void SetPath(List<Vector3> path)
    {
        if (path.Count == 0)
        {
            Destroy(gameObject);
            return;
        }

        this.path = path;
        index = 0;
        currentTargetPos = this.path[index];

        Vector3 relativepoint = transform.InverseTransformPoint(this.path[index + 1]);

        float angle = Mathf.Atan2(relativepoint.x, relativepoint.z) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0,angle,0);
        Stop = false;
    }

    private void Update()
    {
        CheckIfArrived();
        Drive();
    }

    private void Drive()
    {
        if (Stop)
        {
            OnDrive?.Invoke(Vector2.zero);
        }
        else
        {
            Vector3 relativepoint = transform.InverseTransformPoint(currentTargetPos);
            float angle = Mathf.Atan2(relativepoint.x, relativepoint.z) * Mathf.Rad2Deg;
            var rotateCar = 0;
            if (angle > turningAngleOffset)
            {
                rotateCar = 1;
            }
            else if (angle < -turningAngleOffset)
            {
                rotateCar = -1;
            }
            OnDrive?.Invoke(new Vector2(rotateCar,1));
        }
    }

    private void CheckIfArrived()
    {
        if (!Stop)
        {
            var distToCheck = arriveDistance;
            if (index == path.Count - 1)
            {
                distToCheck = lastpoint;
            }

            if (Vector3.Distance(currentTargetPos, transform.position) < distToCheck)
            {
                setNextIndex();
            }
        }
    }

    private void setNextIndex()
    {
        index++;
        if (index >= path.Count)
        {
            Stop = true;
            Destroy(gameObject);
        }
        else
        {
            currentTargetPos = path[index];
        }
    }
}
