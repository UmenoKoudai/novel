using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TalkData))]
public class TalkDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TalkData data = target as TalkData;
        if(GUILayout.Button("Add"))
        {
            data.Add();
        }
    }
}
