using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public WayPoint prevWaypoint;
    public WayPoint nextWaypoint;

    [Range(0, 5)] public float width = 1f;
    
    public List<WayPoint> branches = new List<WayPoint>();

    [Range(0f, 1f)] public float branchRatio = 0.5f;
    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(minBound,maxBound,Random.Range(0f,1f));
    }
}
