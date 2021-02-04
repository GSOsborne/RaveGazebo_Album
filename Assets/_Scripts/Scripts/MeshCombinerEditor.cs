#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MeshCombinerScript))]
public class MeshCombinerEditor : Editor
{
    private void OnSceneGUI()
    {
        MeshCombinerScript mc = target as MeshCombinerScript;

        if (Handles.Button (mc.transform.position+Vector3.up*2, Quaternion.LookRotation(Vector3.up), 1, 1, Handles.CylinderHandleCap))
        {
            mc.CombineMeshes();
        }
    }
}
#endif
