using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(TileManager))]
public class TileManagerEditor : Editor{


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TileManager manager = (TileManager)target;

        if (GUILayout.Button("Spawn Top Tile"))
        {
            manager.SpawnTopTile();
        }

        if (GUILayout.Button("Spawn Left Tile"))
        {
            manager.SpawnLeftTile();
        }

    }
}
