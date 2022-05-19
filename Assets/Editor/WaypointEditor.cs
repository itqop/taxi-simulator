using Cinemachine;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void OnDrawSceneGizmo(WayPoint wayPoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.yellow;
        }
        else
        {
            Gizmos.color = Color.yellow * 0.5f;
        }
        
        Gizmos.DrawSphere(wayPoint.transform.position, .1f);
        
        Gizmos.color = Color.white;
        Gizmos.DrawLine(wayPoint.transform.position + (wayPoint.transform.right * wayPoint.width / 2f),
            wayPoint.transform.position - (wayPoint.transform.right * wayPoint.width / 2f));

        if (wayPoint.prevWaypoint != null)
        {
            Gizmos.color = Color.cyan;
            Vector3 offset = wayPoint.transform.right * wayPoint.width / 2f;
            Vector3 offsetTo = wayPoint.prevWaypoint.transform.right * wayPoint.prevWaypoint.width / 2f;

            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.prevWaypoint.transform.position + offsetTo);
        }

        if (wayPoint.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Vector3 offset = wayPoint.transform.right * -wayPoint.width / 2f;
            Vector3 offsetTo = wayPoint.nextWaypoint.transform.right * -wayPoint.nextWaypoint.width / 2f;

            Gizmos.DrawLine(wayPoint.transform.position + offset, wayPoint.nextWaypoint.transform.position + offsetTo);
        }

        if (wayPoint.branches != null)
        {
            foreach (WayPoint branch in wayPoint.branches)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(wayPoint.transform.position,branch.transform.position);
            }
        }
    }
}
