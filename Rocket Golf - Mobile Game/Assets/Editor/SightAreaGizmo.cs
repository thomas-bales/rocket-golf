using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class SightAreaGizmo : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;

        Handles.color = Color.white;
        Handles.DrawWireDisc(fov.transform.position, fov.transform.forward, fov.sightRadius);

        Handles.color = Color.green;
        if (fov.canSeePlayer)
            Handles.DrawLine(fov.transform.position, fov.target.position);
    }
}
