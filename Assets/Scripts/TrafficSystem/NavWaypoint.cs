using UnityEngine;
using Random = UnityEngine.Random;

public class NavWaypoint : MonoBehaviour
{
    public PedCharContr _controller;
    public WayPoint currentWayPoint;

    [SerializeField]private int dir;
    private void Awake()
    {
        _controller = GetComponent<PedCharContr>();
    }

    private void Start()
    {
        dir = Mathf.RoundToInt(Random.Range(0f, 1f));
        _controller.SetDestination(currentWayPoint.GetPosition());
    }

    private void Update()
    {
        if (_controller.reachedDestination)
        {
            bool shouldBranch = false;

            if (currentWayPoint.branches != null && currentWayPoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWayPoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                currentWayPoint = currentWayPoint.branches[Random.Range(0, currentWayPoint.branches.Count - 1)];
            }
            else
            {
                if (dir == 0)
                {
                    if (currentWayPoint.nextWaypoint != null)
                    {
                        currentWayPoint = currentWayPoint.nextWaypoint;
                    }
                    else
                    {
                        currentWayPoint = currentWayPoint.prevWaypoint;
                        dir = 1;
                    }
                    
                }
                else if(dir == 1)
                {
                    if (currentWayPoint.prevWaypoint != null)
                    {
                        currentWayPoint = currentWayPoint.prevWaypoint;
                    }
                    else
                    {
                        currentWayPoint = currentWayPoint.nextWaypoint;
                        dir = 0;
                    }
                }
            }
            
            
            
            _controller.SetDestination(currentWayPoint.GetPosition());
        }
    }
}
