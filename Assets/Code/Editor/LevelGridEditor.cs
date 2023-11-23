#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelGrid), true)]
public class BaseActionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelGrid levelGrid = (LevelGrid)target;

        if (GUILayout.Button("Spawn Grid"))
        {
            levelGrid.RemoveAllGrid();
            levelGrid.SpawnGrid();
            levelGrid.SpawnRandomBrick();
        }

        if (GUILayout.Button("Remove Grid"))
        {
            levelGrid.RemoveAllGrid();
        }
    }
}
#endif