using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PlacementGenerator))]
public class PropGeneration : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        PlacementGenerator myScript = (PlacementGenerator)target;
        if (GUILayout.Button("Generate"))
        {
            myScript.Generate();
        }
        if (GUILayout.Button("Clear"))
        {
            myScript.Clear();
        }
    }
}
