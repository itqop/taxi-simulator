using UnityEditor;
using UnityEngine;

public class WayPointMangr : EditorWindow
{
    [MenuItem("Tools/Waypoint Editor")]
    public static void Open()
    {
        GetWindow<WayPointMangr>();
    }

    public Transform waypointRoot;

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointRoot"));

        if (waypointRoot == null)
        {
            EditorGUILayout.HelpBox("...",MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            DrawBtn();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();

        void DrawBtn()
        {
            if(GUILayout.Button("Create Waypoint"))
                CreateWayPoint();
            if (Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<WayPoint>())
            {
                if (GUILayout.Button("Add Branch Waypoint"))
                {
                    CreateBranch();
                }
                if (GUILayout.Button("Create Waypoint Before"))
                {
                    CreateWayPointBefore();
                }

                if (GUILayout.Button("Create Waypoint After"))
                {
                    CreateWaypointAfter();
                }
                
                if (GUILayout.Button("Remove Waypoint"))
                {
                    RemoveWaypoint();
                }
            }
        }
    
        void CreateWayPoint()
        {
            GameObject waypointobj = new GameObject("Waypoint " + waypointRoot.childCount,typeof(WayPoint));
            waypointobj.transform.SetParent(waypointRoot,false);

            WayPoint wp = waypointobj.GetComponent<WayPoint>();

            if (waypointRoot.childCount > -1)
            {
                wp.prevWaypoint = waypointRoot.GetChild(waypointRoot.childCount - 2).GetComponent<WayPoint>();
                wp.prevWaypoint.nextWaypoint = wp;

                wp.transform.position = wp.prevWaypoint.transform.position;
                wp.transform.forward = wp.prevWaypoint.transform.forward;

            }

            Selection.activeGameObject = wp.gameObject;
        }

        void CreateWayPointBefore()
        {
            GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WayPoint));
            waypointObject.transform.SetParent(waypointRoot,false);

            WayPoint newWayPoint = waypointObject.GetComponent<WayPoint>();

            WayPoint selectedWP = Selection.activeGameObject.GetComponent<WayPoint>();

            waypointObject.transform.position = selectedWP.transform.position;
            waypointObject.transform.forward = selectedWP.transform.forward;

            if (selectedWP.prevWaypoint != null)
            {
                newWayPoint.prevWaypoint = selectedWP.prevWaypoint;
                selectedWP.prevWaypoint.nextWaypoint = newWayPoint;
            }

            newWayPoint.nextWaypoint = selectedWP;

            selectedWP.prevWaypoint = newWayPoint;
            
            newWayPoint.transform.SetSiblingIndex(selectedWP.transform.GetSiblingIndex());

            Selection.activeGameObject = newWayPoint.gameObject;
        }

        void CreateWaypointAfter()
        {
            GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WayPoint));
            waypointObject.transform.SetParent(waypointRoot,false);

            WayPoint newWayPoint = waypointObject.GetComponent<WayPoint>();

            WayPoint selectedWP = Selection.activeGameObject.GetComponent<WayPoint>();

            waypointObject.transform.position = selectedWP.transform.position;
            waypointObject.transform.forward = selectedWP.transform.forward;

            newWayPoint.prevWaypoint = selectedWP;

            if (selectedWP.nextWaypoint != null)
            {
                selectedWP.nextWaypoint.prevWaypoint = newWayPoint;
                newWayPoint.nextWaypoint = selectedWP.nextWaypoint;
            }

            selectedWP.nextWaypoint = newWayPoint;
            
            newWayPoint.transform.SetSiblingIndex(selectedWP.transform.GetSiblingIndex());

            Selection.activeGameObject = newWayPoint.gameObject;
        }

        void RemoveWaypoint()
        {
            WayPoint selectedWaypoint = Selection.activeGameObject.GetComponent<WayPoint>();

            if (selectedWaypoint.nextWaypoint != null)
            {
                selectedWaypoint.nextWaypoint.prevWaypoint = selectedWaypoint.prevWaypoint;
            }

            if (selectedWaypoint.prevWaypoint != null)
            {
                selectedWaypoint.prevWaypoint.nextWaypoint = selectedWaypoint.nextWaypoint;
                Selection.activeGameObject = selectedWaypoint.prevWaypoint.gameObject;
            }
            
            DestroyImmediate(selectedWaypoint.gameObject);
        }

        void CreateBranch()
        {
            GameObject waypointObject = new GameObject("Waypoint " + waypointRoot.childCount, typeof(WayPoint));
            
            waypointObject.transform.SetParent(waypointRoot,false);

            WayPoint waypoint = waypointObject.GetComponent<WayPoint>();

            WayPoint branchedFrom = Selection.activeGameObject.GetComponent<WayPoint>();
            branchedFrom.branches.Add(waypoint);

            waypoint.transform.position = branchedFrom.transform.position;
            waypoint.transform.forward = branchedFrom.transform.forward;

            Selection.activeGameObject = waypoint.gameObject;
        }
    }
}
